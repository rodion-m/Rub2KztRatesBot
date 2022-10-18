namespace Rub2KztRatesBot.Services;

public class TinkoffExchanger : FixRateExchanger
{
    public TinkoffExchanger(CbrClient rateProvider) 
        : base("Тинькофф (перевод)", 0.06m, rateProvider)
    {
    }
}