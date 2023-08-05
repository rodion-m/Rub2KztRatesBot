using System.Net.Http.Headers;
using System.Text.Json;

namespace Rub2KztRatesBot.Binance;

//TODO asset and fiat enums
/// <summary>
/// Unoffical client for Binance P2P platform.
/// </summary>
/// <remarks>This class is thread safe.</remarks>
public class BinanceP2PClient : IDisposable
{
    private readonly HttpClient _httpClient = new(new HttpClientHandler
    {
        UseCookies = false,
    })
    {
        BaseAddress = new Uri("https://p2p.binance.com")
    };

    //https://p2p.binance.com/en/trade/all-payments/USDT?fiat=RUB
    public Task<BinanceAdvertisementsResponse> GetUsdtAdvertisements(
        TradeType tradeType, string fiat, string? paymentType, decimal? amount = null)
    {
        if (fiat == null) throw new ArgumentNullException(nameof(fiat));
        return GetAdvertisements(tradeType, fiat, "USDT", paymentType, amount);
    }
    
    public async Task<BinanceAdvertisementsResponse> GetAdvertisements(
        TradeType tradeType, string fiat, string asset, string? paymentType, decimal? amount = null)
    {
        if (fiat == null) throw new ArgumentNullException(nameof(fiat));
        if (asset == null) throw new ArgumentNullException(nameof(asset));
        var request = CreateBinanceAdvertisementsRequest(tradeType, fiat, asset, paymentType, amount);
        var requestMessage = CreateRequestMessage(request);
        using var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
        //var result = await response.Content.ReadFromJsonAsync<BinanceAdvertisementsResponse>();
        var s = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<BinanceAdvertisementsResponse>(s)!;
    }

    private static HttpRequestMessage CreateRequestMessage(BinanceAdvertisementsRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        return new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://p2p.binance.com/bapi/c2c/v2/friendly/c2c/adv/search"),
            Headers =
            {
                { "cookie", "cid=AD98273d" },
                { "authority", "p2p.binance.com" },
                { "accept", "*/*" },
                { "accept-language", "ru,en-US;q=0.9,en;q=0.8,de;q=0.7,it;q=0.6" },
                { "bnc-uuid", "f01ab3b0-625d-450a-b27c-241c7984ff39" },
                { "c2ctype", "c2c_merchant" },
                { "clienttype", "web" },
                { "csrftoken", "d41d8cd98f00b204e9800998ecf8427e" },
                {
                    "device-info",
                    "eyJzY3JlZW5fcmVzb2x1dGlvbiI6IjE5MjAsMTA4MCIsImF2YWlsYWJsZV9zY3JlZW5fcmVzb2x1dGlvbiI6IjE5MjAsMTA0MCIsInN5c3RlbV92ZXJzaW9uIjoiV2luZG93cyAxMCIsImJyYW5kX21vZGVsIjoidW5rbm93biIsInN5c3RlbV9sYW5nIjoicnUiLCJ0aW1lem9uZSI6IkdNVCs2IiwidGltZXpvbmVPZmZzZXQiOi0zNjAsInVzZXJfYWdlbnQiOiJNb3ppbGxhLzUuMCAoV2luZG93cyBOVCAxMC4wOyBXaW42NDsgeDY0KSBBcHBsZVdlYktpdC81MzcuMzYgKEtIVE1MLCBsaWtlIEdlY2tvKSBDaHJvbWUvMTA2LjAuMC4wIFNhZmFyaS81MzcuMzYgRWRnLzEwNi4wLjEzNzAuNDciLCJsaXN0X3BsdWdpbiI6IlBERiBWaWV3ZXIsQ2hyb21lIFBERiBWaWV3ZXIsQ2hyb21pdW0gUERGIFZpZXdlcixNaWNyb3NvZnQgRWRnZSBQREYgVmlld2VyLFdlYktpdCBidWlsdC1pbiBQREYiLCJjYW52YXNfY29kZSI6IjE5ZWFhYzllIiwid2ViZ2xfdmVuZG9yIjoiR29vZ2xlIEluYy4gKEFNRCkiLCJ3ZWJnbF9yZW5kZXJlciI6IkFOR0xFIChBTUQsIEFNRCBSYWRlb24oVE0pIEdyYXBoaWNzIERpcmVjdDNEMTEgdnNfNV8wIHBzXzVfMCwgRDNEMTEpIiwiYXVkaW8iOiIxMjQuMDQzNDc1Mjc1MTYwNzQiLCJwbGF0Zm9ybSI6IldpbjMyIiwid2ViX3RpbWV6b25lIjoiQXNpYS9BbG1hdHkiLCJkZXZpY2VfbmFtZSI6IkVkZ2UgVjEwNi4wLjEzNzAuNDcgKFdpbmRvd3MpIiwiZmluZ2VycHJpbnQiOiJjZWQ1ZDgzMjk5MjFhNjU1NTE5NzZjNGYwZTExMzc4NCIsImRldmljZV9pZCI6IiIsInJlbGF0ZWRfZGV2aWNlX2lkcyI6IjE2NjA2OTY3MjQwODdxSFZvS0NNU1R5OTlyR0FQekZCIn0="
                },
                { "fvideo-id", "313cc1b74101abbba0aad2443933fd0aefb76fd0" },
                { "lang", "en" },
                { "origin", "https://p2p.binance.com" },
                { "referer", "https://p2p.binance.com/en/trade/all-payments/USDT?fiat=RUB" },
                { "sec-ch-ua", "\"Chromium\";v=\"106\", \"Microsoft Edge\";v=\"106\", \"Not;A=Brand\";v=\"99\"" },
                { "sec-ch-ua-mobile", "?0" },
                { "sec-ch-ua-platform", "\"Windows\"" },
                { "sec-fetch-dest", "empty" },
                { "sec-fetch-mode", "cors" },
                { "sec-fetch-site", "same-origin" },
                {
                    "user-agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36 Edg/106.0.1370.47"
                },
                { "x-trace-id", "7d259678-0689-4af8-95c0-aff778c0bac7" },
                { "x-ui-request-trace", "7d259678-0689-4af8-95c0-aff778c0bac7" },
            },
            Content = JsonContent.Create(request)
        };
    }

    private static BinanceAdvertisementsRequest CreateBinanceAdvertisementsRequest(
        TradeType tradeType, string fiat, string asset, string? paymentType, decimal? amount)
    {
        if (fiat == null) throw new ArgumentNullException(nameof(fiat));
        if (asset == null) throw new ArgumentNullException(nameof(asset));
        return new BinanceAdvertisementsRequest()
        {
            Asset = asset,
            TradeType = tradeType == TradeType.Buy ? "BUY" : "SELL",
            Fiat = fiat,
            PayTypes = paymentType is not null 
                ? new []{ paymentType } 
                : Array.Empty<string>(),
            TransAmount = amount?.ToString(),
            Page = 1,
            Rows = 10
        };
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}