namespace Rub2KztRatesBot.Services;

public class KoronaPay : IRateProvider
{
    public string Name => "Золотая корона";
    private readonly HttpClient _httpClient = new();
    public async ValueTask<decimal> GetKztPerRubRate()
    {
        const string uri = "https://koronapay.com/transfers/online/api/transfers/tariffs" +
                           "?sendingCountryId=RUS&sendingCurrencyId=810&receivingCountryId=KAZ" +
                           "&receivingCurrencyId=398&paymentMethod=debitCard&receivingAmount=10000" +
                           "&receivingMethod=cash&paidNotificationEnabled=false";
        var response = await _httpClient.GetFromJsonAsync<KoronaTariffsResponse[]>(uri);
        var rate = response![0].ExchangeRate;
        return 1m / (decimal) rate;
    }
}