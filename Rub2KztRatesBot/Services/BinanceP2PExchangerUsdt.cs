using Rub2KztRatesBot.Binance;

namespace Rub2KztRatesBot.Services;

public class BinanceP2PExchangerUsdt : BinanceP2PExchanger
{
    public BinanceP2PExchangerUsdt(BinanceP2PClient binanceClient) 
        : base(binanceClient, "Binance P2P (USDT)", "USDT")
    {
    }
}