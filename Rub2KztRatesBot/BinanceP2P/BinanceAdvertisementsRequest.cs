using System.Text.Json.Serialization;
#pragma warning disable CS8618

namespace Rub2KztRatesBot.Binance;

public class BinanceAdvertisementsRequest
{
    [JsonPropertyName("proMerchantAds")]
    public bool ProMerchantAds { get; set; }

    [JsonPropertyName("page")]
    public long Page { get; set; }

    [JsonPropertyName("rows")]
    public long Rows { get; set; }

    [JsonPropertyName("payTypes")] 
    public string[] PayTypes { get; set; } = Array.Empty<string>();

    [JsonPropertyName("countries")]
    public string[] Countries { get; set; } = Array.Empty<string>();

    [JsonPropertyName("publisherType")]
    public object? PublisherType { get; set; }

    [JsonPropertyName("transAmount")]
    public string? TransAmount { get; set; }

    [JsonPropertyName("asset")]
    public string Asset { get; set; }

    [JsonPropertyName("fiat")]
    public string Fiat { get; set; }

    [JsonPropertyName("tradeType")]
    public string TradeType { get; set; }
}