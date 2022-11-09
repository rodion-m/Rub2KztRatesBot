using System.Globalization;

namespace Rub2KztRatesBot.Services;

public class MirPayRate : IRateProvider
{
    public string Name => "МИР (снятие)";
    
    private readonly HttpValueParser _parser;
    private static readonly CultureInfo ru = new("ru");

    public MirPayRate(HttpValueParser parser)
    {
        _parser = parser;
    }

    public async ValueTask<decimal> GetKztPerRubRate()
    {
        var uri = "https://mironline.ru/support/list/kursy_mir/";
        var selector = "/html/body/div[3]/div[2]/div[1]/div/div/div/div/div[2]/table/tbody/tr[5]/td[2]/span/p";
        var sRate = await _parser.Parse(uri, selector);
        if (sRate is null) throw new NullReferenceException(nameof(sRate));
        var rate = decimal.Parse(sRate, ru);
        return 1m / rate;
    }
}