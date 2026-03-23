using System;
using System.Text.Json.Serialization;

namespace Apigen.InvoiceNinja.Models;

/// <summary>
/// The payment type used to complete this payment
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentType
{
    [JsonStringEnumMemberName("1")]
    _1,
    [JsonStringEnumMemberName("2")]
    _2,
    [JsonStringEnumMemberName("3")]
    _3,
    [JsonStringEnumMemberName("4")]
    _4,
    [JsonStringEnumMemberName("5")]
    _5,
    [JsonStringEnumMemberName("6")]
    _6,
    [JsonStringEnumMemberName("7")]
    _7,
    [JsonStringEnumMemberName("8")]
    _8,
    [JsonStringEnumMemberName("9")]
    _9,
    [JsonStringEnumMemberName("10")]
    _10,
    [JsonStringEnumMemberName("11")]
    _11,
    [JsonStringEnumMemberName("12")]
    _12,
    [JsonStringEnumMemberName("13")]
    _13,
    [JsonStringEnumMemberName("14")]
    _14,
    [JsonStringEnumMemberName("15")]
    _15,
    [JsonStringEnumMemberName("16")]
    _16,
    [JsonStringEnumMemberName("17")]
    _17,
    [JsonStringEnumMemberName("18")]
    _18,
    [JsonStringEnumMemberName("19")]
    _19,
    [JsonStringEnumMemberName("20")]
    _20,
    [JsonStringEnumMemberName("21")]
    _21,
    [JsonStringEnumMemberName("22")]
    _22,
    [JsonStringEnumMemberName("23")]
    _23,
    [JsonStringEnumMemberName("24")]
    _24,
    [JsonStringEnumMemberName("25")]
    _25,
    [JsonStringEnumMemberName("26")]
    _26,
    [JsonStringEnumMemberName("27")]
    _27,
    [JsonStringEnumMemberName("28")]
    _28,
    [JsonStringEnumMemberName("29")]
    _29,
    [JsonStringEnumMemberName("30")]
    _30,
    [JsonStringEnumMemberName("31")]
    _31,
    [JsonStringEnumMemberName("32")]
    _32,
    [JsonStringEnumMemberName("33")]
    _33,
}
