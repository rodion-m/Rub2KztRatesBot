namespace Rub2KztRatesBot.Freedom;

public class GetRatesResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public RatesData Data { get; set; }
    public int Status { get; set; }
    
    public class RatesData
    {
        public List<ExchangeRate> Cash { get; set; }
        public List<ExchangeRate> Mobile { get; set; }
        public List<ExchangeRate> NonCash { get; set; }
    
        public class ExchangeRate
        {
            public string BuyCode { get; set; }
            public string SellCode { get; set; }
            public string BuyRate { get; set; }
            public string SellRate { get; set; }
        }
    }
}
