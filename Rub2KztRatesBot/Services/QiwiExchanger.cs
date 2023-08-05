namespace Rub2KztRatesBot.Services;

public class QiwiExchanger : IRateProvider
{
    private readonly PochtaBankRate _pochtaBank;
    public string Name => "QIWI";

    public QiwiExchanger(PochtaBankRate pochtaBank)
    {
        _pochtaBank = pochtaBank;
    }
    
    public ValueTask<decimal> GetKztPerRubRate() => _pochtaBank.GetKztPerRubRate();

}