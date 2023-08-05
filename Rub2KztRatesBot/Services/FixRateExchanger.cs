namespace Rub2KztRatesBot.Services;

public abstract class FixRateExchanger : IRateProvider
{
    public string Name { get; }
    public decimal Fee { get; }
    
    private readonly CbrClient _rateProvider;

    public FixRateExchanger(string name, decimal fee, CbrClient rateProvider)
    {
        if (fee < 0) throw new ArgumentOutOfRangeException(nameof(fee));
        _rateProvider = rateProvider ?? throw new ArgumentNullException(nameof(rateProvider));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Fee = fee;
    }
    
    public async ValueTask<decimal> GetKztPerRubRate()
    {
        var rate = await _rateProvider.GetKztPerRubRate();
        return rate * (1m - Fee);
    }
}