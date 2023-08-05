using Rub2KztRatesBot.Tinkoff;

namespace Rub2KztRatesBot.Services;

public class TinkoffRateProvider : IRateProvider
{
    public string Name => "Тинькофф (оплата кредиткой)";
    private readonly TinkoffClient _freedomFinance;

    public TinkoffRateProvider(TinkoffClient tinkoff)
    {
        _freedomFinance = tinkoff ?? throw new ArgumentNullException(nameof(tinkoff));
    }

    public async ValueTask<decimal> GetKztPerRubRate()
    {
        var rates = await _freedomFinance.GetCurrencyRatesAsync(from: "RUB", to: "KZT");
        var creditCards = rates.Rates.Single(it => it.Category == "CreditCardsOperations");
        return (decimal) creditCards.Buy;
    }
}