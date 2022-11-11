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
        var result = await _parser.ParseString(uri, selector);
        result.ThrowIfFailed();
        var rate = decimal.Parse(result.TextContent!, ru);
        return 1m / rate;
    }
}