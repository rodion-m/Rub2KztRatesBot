namespace Rub2KztRatesBot.Services;

public interface IRateProvider
{
    string Name { get; }
    ValueTask<decimal> GetKztPerRubRate();
}