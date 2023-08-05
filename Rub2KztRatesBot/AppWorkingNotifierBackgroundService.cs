namespace Rub2KztRatesBot;

public class AppWorkingNotifierBackgroundService : BackgroundService
{
    private readonly ILogger<AppWorkingNotifierBackgroundService> _logger;

    public AppWorkingNotifierBackgroundService(
        ILogger<AppWorkingNotifierBackgroundService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromHours(1));
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            _logger.LogInformation("App is working");
        }
    }
}