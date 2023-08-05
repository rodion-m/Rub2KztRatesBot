using System.Collections.Immutable;
using Microsoft.Extensions.Caching.Memory;

namespace Rub2KztRatesBot.Services;

public class RatesService
{
    private readonly IEnumerable<IRateProvider> _providers;
    private readonly IMemoryCache _cache;
    private readonly IClock _clock;
    private readonly ILogger<RatesService> _logger;

    public RatesService(
        IEnumerable<IRateProvider> providers, 
        IMemoryCache cache,
        IClock clock,
        ILogger<RatesService> logger)
    {
        _providers = providers;
        _cache = cache;
        _clock = clock;
        _logger = logger;
    }

    public Task<IReadOnlyCollection<RateInfo>> GetRates()
    {
        var key = _clock.CurrentDate.ToString();
        return _cache.GetOrCreateAsync(key, entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(30));
            return GetActualRates();
        });
    }

    private async Task<IReadOnlyCollection<RateInfo>> GetActualRates()
    {
        var tasks = _providers.Select(
            async p =>
            {
                try
                {
                    var rate = await p.GetKztPerRubRate();
                    return new RateInfo(p.Name, Math.Round(rate, 2));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Ошибка в провайдере {Provider}", p.Name);
                    return null;
                }
            });
        
        return (await Task.WhenAll(tasks))
            .Where(it => it is not null)
            .Cast<RateInfo>()
            .OrderByDescending(it => it.Rate)
            .ToImmutableList();
    }
}

public record RateInfo(string Name, decimal Rate);