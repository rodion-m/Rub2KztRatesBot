using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.XPath;

namespace Rub2KztRatesBot.Services;

public class MoneySendRateProvider : IRateProvider
{
    private readonly HttpClient _httpClient = new();
    public string Name => "moneysend.money";

    public async ValueTask<decimal> GetKztPerRubRate()
    {
        //*[@id="iframe"]
        //todo load from moneysend.money via driver
        var uri = "https://customer.unido.kz/v1/merchant/542020/p2ptransfer/view?pg_payment_id=badf6ecd874079204dcfe266a0a30338";
        var src = await _httpClient.GetStringAsync(uri);
        var rate = GetRate(src);
        var fee = GetFee(src);
        return rate * (1m - fee);
    }

    private static decimal GetRate(string src)
    {
        var rateMatch = Regex.Match(src, @"CURRENCY_RATE = '(.*?)'");
        var sRate = rateMatch.Groups[1].Value;
        return decimal.Parse(sRate);
    }
    
    private static decimal GetFee(string src)
    {
        var rateMatch = Regex.Match(src, @"COMISSION = '(.*?)'");
        var sFeePercent = rateMatch.Groups[1].Value;
        return decimal.Parse(sFeePercent) / 100m;
    }
}