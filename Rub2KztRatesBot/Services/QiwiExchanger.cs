namespace Rub2KztRatesBot.Services;

public class QiwiExchanger : FixRateExchanger
{
    public QiwiExchanger(CbrClient rateProvider) 
        : base("QIWI", 0.06m, rateProvider)
    {
    }
}