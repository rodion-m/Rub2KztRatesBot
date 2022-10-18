using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Rub2KztRatesBot.Entities;

namespace Rub2KztRatesBot;

public class CbrClient
{
    private readonly IMemoryCache _cache;
    private readonly string _cacheKey = Guid.NewGuid().ToString();

    public CbrClient(IMemoryCache cache)
    {
        _cache = cache;
    }
    
    static CbrClient()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
    
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://www.cbr.ru")
    };

    public Task<ValCurs> GetRates(DateOnly? date = null)
    {
        date ??= DateOnly.FromDateTime(DateTime.Now);
        return _cache.GetOrCreateAsync(_cacheKey + date, async entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(30));
            return await GetRates(date.Value);
        });
    }
    
    private async Task<ValCurs> GetRates(DateOnly date)
    {
        var uri = $@"/scripts/XML_daily.asp?date_req={date:dd\/MM\/yyyy}";
        var response = await _httpClient.GetStringAsync(uri);
        return ValCurs.FromXml(response);
    }
    
    public async ValueTask<decimal> GetKztPerRubRate()
    {
        return (await GetRates()).Kzt;
    }
}