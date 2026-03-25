#!/usr/bin/env python3
"""
Patches the upstream InvoiceNinja OpenAPI spec with fixes needed for code generation.

This script is idempotent - safe to run multiple times.
Uses ruamel.yaml to preserve formatting, comments, and key order.

Patches applied:
  1. Add per_page_meta/page_meta params to list endpoints that are missing them

Note: readOnly on id fields is intentionally omitted for now. Adding readOnly
causes the generator to split schemas differently, which breaks ModelConversion.
This should be revisited when the generator handles readOnly-based splits better.
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


def main():
    spec_path = sys.argv[1] if len(sys.argv) > 1 else "specs/invoiceninja.yaml"

    print(f"Patching {spec_path}...")

    with open(spec_path, "r") as f:
        spec = yaml.load(f)

    n = patch_pagination_params(spec)
    print(f"  Pagination params: added to {n} endpoints")

    # readOnly patch disabled for now - causes generator split issues
    # n = patch_readonly_ids(spec)
    # print(f"  readOnly id fields: patched {n} schemas")

    with open(spec_path, "w") as f:
        yaml.dump(spec, f)

    print("Done.")


if __name__ == "__main__":
    main()
