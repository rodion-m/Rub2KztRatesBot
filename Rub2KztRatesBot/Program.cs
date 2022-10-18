using System.Globalization;
using Rub2KztRatesBot;
using Rub2KztRatesBot.Binance;
using Rub2KztRatesBot.Services;
using Serilog;
using Serilog.Events;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, configuration) =>
{
    configuration
        .WriteTo.Console()
        .WriteTo.File("logs/log-.txt", LogEventLevel.Debug, rollingInterval: RollingInterval.Day);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IClock, ClockMsk>();
builder.Services.AddSingleton<CbrClient>();
builder.Services.AddSingleton<BinanceP2PClient>();
builder.Services.AddSingleton<HttpValueParser>();
builder.Services.AddSingleton<IRateProvider, CbrRateProvider>();
builder.Services.AddSingleton<IRateProvider, QiwiExchanger>();
builder.Services.AddSingleton<IRateProvider, TinkoffExchanger>();
builder.Services.AddSingleton<IRateProvider, KoronaPay>();
builder.Services.AddSingleton<IRateProvider, PochtaBankRate>();
builder.Services.AddSingleton<IRateProvider, MirPayRate>();
builder.Services.AddSingleton<IRateProvider, BinanceP2PExchanger>();
builder.Services.AddSingleton<RatesService>();
//+мтс деньги
//+тинькофф мир снятие

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", (RatesService service) =>
{
    return service.GetRates();
});

app.Run();