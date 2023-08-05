using Rub2KztRatesBot.Binance;

namespace Rub2KztRatesBot.Services;

public class BinanceP2PExchangerBusd : BinanceP2PExchanger
{
    public BinanceP2PExchangerBusd(BinanceP2PClient binanceClient) 
        : base(binanceClient, "Binance P2P (BUSD)", "BUSD")
    {
    }
}