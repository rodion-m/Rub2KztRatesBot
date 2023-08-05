using System.Text.Json.Serialization;

namespace Rub2KztRatesBot.Tinkoff;

public class Currency
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("strCode")]
    public string StrCode { get; set; }
}

public class Rate
{
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("fromCurrency")]
    public Currency FromCurrency { get; set; }

    [JsonPropertyName("toCurrency")]
    public Currency ToCurrency { get; set; }

    [JsonPropertyName("buy")]
    public double Buy { get; set; }

    [JsonPropertyName("sell")]
    public double Sell { get; set; }
}

public class Payload
{
    [JsonPropertyName("lastUpdate")]
    public LastUpdate LastUpdate { get; set; }

    [JsonPropertyName("rates")]
    public List<Rate> Rates { get; set; }
}

public class LastUpdate
{
    [JsonPropertyName("milliseconds")]
    public long Milliseconds { get; set; }
}

public class CurrencyRateResponse
{
    [JsonPropertyName("trackingId")]
    public string TrackingId { get; set; }

    [JsonPropertyName("resultCode")]
    public string ResultCode { get; set; }

    [JsonPropertyName("payload")]
    public Payload Payload { get; set; }
}
