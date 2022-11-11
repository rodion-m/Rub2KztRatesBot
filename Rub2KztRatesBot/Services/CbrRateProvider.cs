namespace Rub2KztRatesBot.Services;

class CbrRateProvider : IRateProvider
{
    public string Name => "ЦБ РФ (референс)";
    private readonly CbrClient _cbrClient;

    public CbrRateProvider(CbrClient cbrClient)
    {
        _cbrClient = cbrClient;
    }

    public ValueTask<decimal> GetKztPerRubRate()
        => _cbrClient.GetKztPerRubRate();
}