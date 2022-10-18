using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace Rub2KztRatesBot.Services;

public class KoronaTariffsResponse
{
    [JsonPropertyName("sendingCurrency")] public IngCurrency SendingCurrency { get; set; }

    [JsonPropertyName("sendingAmount")] public long SendingAmount { get; set; }

    [JsonPropertyName("sendingAmountDiscount")]
    public long SendingAmountDiscount { get; set; }

    [JsonPropertyName("sendingAmountWithoutCommission")]
    public long SendingAmountWithoutCommission { get; set; }

    [JsonPropertyName("sendingCommission")] public long SendingCommission { get; set; }

    [JsonPropertyName("sendingCommissionDiscount")]
    public long SendingCommissionDiscount { get; set; }

    [JsonPropertyName("sendingTransferCommission")]
    public long SendingTransferCommission { get; set; }

    [JsonPropertyName("paidNotificationCommission")]
    public long PaidNotificationCommission { get; set; }

    [JsonPropertyName("receivingCurrency")] public IngCurrency ReceivingCurrency { get; set; }

    [JsonPropertyName("receivingAmount")] public long ReceivingAmount { get; set; }

    [JsonPropertyName("exchangeRate")] public double ExchangeRate { get; set; }

    [JsonPropertyName("exchangeRateType")] public string ExchangeRateType { get; set; }

    [JsonPropertyName("exchangeRateDiscount")] public long ExchangeRateDiscount { get; set; }

    [JsonPropertyName("profit")] public long Profit { get; set; }

    [JsonPropertyName("properties")] public Properties Properties { get; set; }
}

public class Properties
{
}

public class IngCurrency
{
    [JsonPropertyName("id")]
    public string Id { get; set; } //int

    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}