namespace Rub2KztRatesBot.Tinkoff;

public class TinkoffClient : IDisposable
{
    private readonly HttpClient _httpClient = new();

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    public async Task<Payload> GetCurrencyRatesAsync(string from, string to)
    {
        ArgumentNullException.ThrowIfNull(from);
        ArgumentNullException.ThrowIfNull(to);
        var requestUri = $"https://api.tinkoff.ru/v1/currency_rates?from={from}&to={to}";
        var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
        request.Headers.Add("accept", "*/*");
        request.Headers.Add("accept-language", "ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
        request.Headers.Add("authority", "api.tinkoff.ru");
        request.Headers.Add("origin", "https://www.tinkoff.ru");
        request.Headers.Add("referer", "https://www.tinkoff.ru/");
        request.Headers.Add("sec-ch-ua", "\"Not/A)Brand\";v=\"99\", \"Google Chrome\";v=\"115\", \"Chromium\";v=\"115\"");
        request.Headers.Add("sec-ch-ua-mobile", "?0");
        request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
        request.Headers.Add("sec-fetch-dest", "empty");
        request.Headers.Add("sec-fetch-mode", "cors");
        request.Headers.Add("sec-fetch-site", "same-site");
        request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36");

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = (await response.Content.ReadFromJsonAsync<CurrencyRateResponse>())!;
        if (responseContent.ResultCode != "OK")
        {
            throw new InvalidOperationException(responseContent.ResultCode ?? "Unknown error");
        }
        return responseContent.Payload;
    }
}
