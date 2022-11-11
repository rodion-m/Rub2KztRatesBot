using Rub2KztRatesBot.Binance;

namespace Rub2KztRatesBot.Services;

public class BinanceP2PExchanger : IRateProvider
{
    public string Name => "Binance (P2P)";
    private readonly BinanceP2PClient _binanceClient;

    public BinanceP2PExchanger(BinanceP2PClient binanceClient)
    {
        _binanceClient = binanceClient;
    }

    public async ValueTask<decimal> GetKztPerRubRate()
    {
        var rubAdv = await _binanceClient.GetUsdtAdvertisements(
            TradeType.Buy, "RUB", "TinkoffNew", 10_000);
        var minRateRubToUsdt = rubAdv.Data.Min(a => a.Adv.PriceDecimal);
        await Pause();
        var kztAdv = await _binanceClient.GetUsdtAdvertisements(
            TradeType.Sell, "KZT", "KaspiBank", 50_000);
        var maxRateUsdtToKzt = kztAdv.Data.Max(a => a.Adv.PriceDecimal);
        //for example: 475 / 65
        var kztPerRubRate = maxRateUsdtToKzt / minRateRubToUsdt;
        return kztPerRubRate;
    }

    private static async Task Pause()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(Random.Shared.Next(1000, 2000)));
    }
}