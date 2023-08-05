namespace Rub2KztRatesBot.Services;

public sealed class PochtaBankRate : IRateProvider
{
    public string Name => "Почта Банк";
    
    private readonly HttpValueParser _parser;

    public PochtaBankRate(HttpValueParser parser)
    {
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    
    public async ValueTask<decimal> GetKztPerRubRate()
    {
        //Todo parse table
        const string uri = "https://www.pochtabank.ru/support/currencies";
        const string selector = """//*[@id="wrapper"]/div[3]/div[2]/div/div/div[5]/div/div[2]/div[2]/div[19]/div[4]/div""";
        var result = await _parser.ParseString(uri, selector);
        result.ThrowIfFailed();
        var rate = decimal.Parse(result.TextContent!);
        return 1m / rate;
    }
}