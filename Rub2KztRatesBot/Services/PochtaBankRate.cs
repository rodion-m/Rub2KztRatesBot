namespace Rub2KztRatesBot.Services;

public class PochtaBankRate : IRateProvider
{
    public string Name => "Почта Банк";
    
    private readonly HttpValueParser _parser;

    public PochtaBankRate(HttpValueParser parser)
    {
        _parser = parser;
    }

    
    public async ValueTask<decimal> GetKztPerRubRate()
    {
        //Todo parse table
        var uri = "https://www.pochtabank.ru/support/currencies";
        var selector = "//*[@id=\"wrapper\"]/div[2]/div[2]/div/div[5]/div/div[2]/div[2]/div[14]/div[4]/div";
        var result = await _parser.ParseString(uri, selector);
        result.ThrowIfFailed();
        var rate = decimal.Parse(result.TextContent!);
        return 1m / rate;
    }
}