#!/usr/bin/env python3
"""
Patches the upstream InvoiceNinja OpenAPI spec with fixes needed for code generation.

This script is idempotent - safe to run multiple times.
Uses ruamel.yaml to preserve formatting, comments, and key order.

Patches applied:
  1. Add per_page_meta/page_meta params to list endpoints that are missing them
  2. Add readOnly: true to 'id' fields on all component schemas
  3. Remove duplicate Ref schemas that are identical to their non-Ref counterparts
"""

import sys
from ruamel.yaml import YAML

yaml = YAML()
yaml.preserve_quotes = True
yaml.width = 4096  # Prevent line wrapping


def patch_pagination_params(spec) -> int:
    """Add per_page_meta and page_meta parameter refs to list endpoints."""
    count = 0

    # Endpoints that need pagination params but are missing them in upstream
    endpoints = [
        ("get", "/api/v1/bank_integrations"),
        ("get", "/api/v1/bank_transactions"),
        ("get", "/api/v1/bank_transaction_rules"),
        ("get", "/api/v1/client_gateway_tokens"),
        ("get", "/api/v1/companies"),
        ("get", "/api/v1/company_gateways"),
        ("get", "/api/v1/designs"),
        ("get", "/api/v1/documents"),
        ("get", "/api/v1/expense_categories"),
        ("get", "/api/v1/expenses"),
        ("get", "/api/v1/group_settings"),
        ("get", "/api/v1/payment_terms"),
        ("get", "/api/v1/recurring_expenses"),
        ("get", "/api/v1/recurring_quotes"),
        ("get", "/api/v1/subscriptions"),
        ("get", "/api/v1/system_logs"),
        ("get", "/api/v1/task_schedulers/"),
        ("get", "/api/v1/task_schedulers/create"),
        ("get", "/api/v1/task_statuses"),
        ("get", "/api/v1/tax_rates"),
        ("get", "/api/v1/tokens"),
        ("get", "/api/v1/users"),
        ("get", "/api/v1/webhooks"),
        ("post", "/api/v1/reports/clients"),
        ("post", "/api/v1/reports/contacts"),
        ("post", "/api/v1/reports/credit"),
        ("post", "/api/v1/reports/documents"),
        ("post", "/api/v1/reports/expense"),
        ("post", "/api/v1/reports/invoice_items"),
        ("post", "/api/v1/reports/invoices"),
        ("post", "/api/v1/reports/payments"),
        ("post", "/api/v1/reports/product_sales"),
        ("post", "/api/v1/reports/products"),
        ("post", "/api/v1/reports/profitloss"),
        ("post", "/api/v1/reports/quote_items"),
        ("post", "/api/v1/reports/quotes"),
        ("post", "/api/v1/reports/recurring_invoices"),
        ("post", "/api/v1/reports/tasks"),
        ("post", "/api/v1/templates"),
    ]

    paths = spec.get("paths", {})
    for method, path in endpoints:
        path_obj = paths.get(path)
        if not path_obj:
            continue
        details = path_obj.get(method)
        if not details:
            continue

        params = details.get("parameters")
        if params is None:
            continue

        # Check if already has per_page_meta
        has_meta = False
        for p in params:
            ref = p.get("$ref", "") if hasattr(p, "get") else ""
            if "per_page_meta" in str(ref):
                has_meta = True
                break

        if has_meta:
            continue

        params.append({"$ref": "#/components/parameters/per_page_meta"})
        params.append({"$ref": "#/components/parameters/page_meta"})
        count += 1

    return count


def patch_readonly_ids(spec) -> int:
    """Add readOnly: true to 'id' properties on all component schemas."""
    count = 0
    schemas = spec.get("components", {}).get("schemas", {})

    for schema_name, schema in schemas.items():
        if not hasattr(schema, "get"):
            continue

        props = schema.get("properties", {})
        if props and "id" in props:
            id_prop = props["id"]
            if hasattr(id_prop, "get") and not id_prop.get("readOnly"):
                id_prop["readOnly"] = True
                count += 1

        # Also check allOf schemas
        all_of = schema.get("allOf", [])
        if all_of:
            for item in all_of:
                if hasattr(item, "get"):
                    inner_props = item.get("properties", {})
                    if inner_props and "id" in inner_props:
                        id_prop = inner_props["id"]
                        if hasattr(id_prop, "get") and not id_prop.get("readOnly"):
                            id_prop["readOnly"] = True
                            count += 1

    return count


def patch_remove_duplicate_ref_schemas(spec) -> int:
    """Remove Ref schemas that are identical to their non-Ref counterparts.

    The upstream spec contains duplicate schemas like CompanyUserRef that are
    100% identical to CompanyUser. This removes the Ref variant and rewrites
    all $ref pointers to use the canonical (non-Ref) schema instead.
    """
    import json

    schemas = spec.get("components", {}).get("schemas", {})
    removed = []

    # Find all FooRef schemas that have a matching Foo schema
    for name in list(schemas.keys()):
        if not name.endswith("Ref"):
            continue
        canonical = name[:-3]  # "CompanyUserRef" -> "CompanyUser"
        if canonical not in schemas:
            continue

        # Deep compare (convert to plain dicts for comparison)
        ref_json = json.dumps(dict(schemas[name]), sort_keys=True)
        canonical_json = json.dumps(dict(schemas[canonical]), sort_keys=True)

        if ref_json == canonical_json:
            removed.append((name, canonical))

    if not removed:
        return 0

    # Rewrite all $ref pointers and remove duplicate schemas
    spec_str = json.dumps(spec, default=str)
    for ref_name, canonical_name in removed:
        old_ref = f"#/components/schemas/{ref_name}"
        new_ref = f"#/components/schemas/{canonical_name}"
        spec_str = spec_str.replace(f'"{old_ref}"', f'"{new_ref}"')

    # Parse back
    import json as json_mod

    patched = json_mod.loads(spec_str)

    # Remove the duplicate schemas
    for ref_name, _ in removed:
        if ref_name in patched["components"]["schemas"]:
            del patched["components"]["schemas"][ref_name]

    # Update spec in-place by reloading through ruamel
    # (We need to preserve ruamel's special types for the final write)
    for ref_name, canonical_name in removed:
        # Remove from ruamel-managed schemas
        if ref_name in schemas:
            del schemas[ref_name]

    # Rewrite $ref strings in the ruamel tree
    _rewrite_refs(spec, removed)

    return len(removed)


def _rewrite_refs(node, replacements):
    """Recursively rewrite $ref strings in a ruamel.yaml tree."""
    if isinstance(node, dict):
        for key in list(node.keys()):
            if key == "$ref" and isinstance(node[key], str):
                for ref_name, canonical_name in replacements:
                    old_ref = f"#/components/schemas/{ref_name}"
                    new_ref = f"#/components/schemas/{canonical_name}"
                    if node[key] == old_ref:
                        node[key] = new_ref
            else:
                _rewrite_refs(node[key], replacements)
    elif isinstance(node, list):
        for item in node:
            _rewrite_refs(item, replacements)


def main():
    spec_path = sys.argv[1] if len(sys.argv) > 1 else "specs/invoiceninja.yaml"

    print(f"Patching {spec_path}...")

    with open(spec_path, "r") as f:
        spec = yaml.load(f)

    n = patch_pagination_params(spec)
    print(f"  Pagination params: added to {n} endpoints")

    n = patch_readonly_ids(spec)
    print(f"  readOnly id fields: patched {n} schemas")

    n = patch_remove_duplicate_ref_schemas(spec)
    print(f"  Duplicate Ref schemas: removed {n}")

    with open(spec_path, "w") as f:
        yaml.dump(spec, f)

    print("Done.")


if __name__ == "__main__":
    main()
