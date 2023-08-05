using System.Globalization;
using Rub2KztRatesBot.Freedom;

namespace Rub2KztRatesBot.Services;

class FfinRateProvider : IRateProvider
{
    public string Name => "Фридом Финанс";
    private readonly FreedomFinanceClient _freedomFinance;

    public FfinRateProvider(FreedomFinanceClient freedomFinance)
    {
        _freedomFinance = freedomFinance ?? throw new ArgumentNullException(nameof(freedomFinance));
    }

    public async ValueTask<decimal> GetKztPerRubRate()
    {
        var rates = await _freedomFinance.GetExchangeRatesAsync();
        var kztPerRubRate = rates.Mobile.Single(it => it.BuyCode == "RUB" && it.SellCode == "KZT");
        return decimal.Parse(kztPerRubRate.BuyRate, CultureInfo.InvariantCulture);
    }
}