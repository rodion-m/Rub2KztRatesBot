using Rub2KztRatesBot.Binance;

namespace Rub2KztRatesBot.Services;

public class BinanceP2PExchanger : IRateProvider
{
    public string Name { get; }

    private readonly BinanceP2PClient _binanceClient;
    private readonly string _asset;
    private readonly decimal _amount;

    public BinanceP2PExchanger(
        BinanceP2PClient binanceClient, string name, string asset, decimal amount = 10_000)
    {
        _binanceClient = binanceClient ?? throw new ArgumentNullException(nameof(binanceClient));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _asset = asset ?? throw new ArgumentNullException(nameof(asset));
        _amount = amount;
    }

    public async ValueTask<decimal> GetKztPerRubRate()
    {
        var rubAdv = await _binanceClient.GetAdvertisements(
            TradeType.Buy, "RUB", _asset, "TinkoffNew", _amount);
        var minRateRubToAsset = rubAdv.Data.Min(a => a.Adv.PriceDecimal);
        await RandomPause(1000, 2000);
        var kztAmount = Math.Round(_amount * minRateRubToAsset);
        var kztAdv = await _binanceClient.GetAdvertisements(
            TradeType.Sell, "KZT", _asset, "KaspiBank", kztAmount);
        var maxRateAssetToKzt = kztAdv.Data.Max(a => a.Adv.PriceDecimal);
        //for example: 475 / 65
        var kztPerRubRate = maxRateAssetToKzt / minRateRubToAsset;
        return kztPerRubRate;
    }

    private static async Task RandomPause(int minMilliseconds, int maxMilliseconds)
    {
        var ms = Random.Shared.Next(minMilliseconds, maxMilliseconds);
        await Task.Delay(ms);
    }
}