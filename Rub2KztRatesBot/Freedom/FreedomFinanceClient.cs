namespace Rub2KztRatesBot.Freedom;
using System.Net.Http;
using System.Threading.Tasks;

public class FreedomFinanceClient : IDisposable
{
    private readonly HttpClient _httpClient;

    public FreedomFinanceClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("authority", "bankffin.kz");
        _httpClient.DefaultRequestHeaders.Add("accept", "application/json, text/plain, */*");
        _httpClient.DefaultRequestHeaders.Add("accept-language", "ru,en-US;q=0.9,en;q=0.8");
    }

    public async Task<GetRatesResponse.RatesData> GetExchangeRatesAsync()
    {
        var response = await _httpClient.GetAsync("https://bankffin.kz/api/exchange-rates/getRates");
        response.EnsureSuccessStatusCode();
        var ratesResponse = await response.Content.ReadFromJsonAsync<GetRatesResponse>();
        if (!ratesResponse.Success)
        {
            throw new InvalidOperationException(ratesResponse.Message);
        }
        return ratesResponse.Data;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
