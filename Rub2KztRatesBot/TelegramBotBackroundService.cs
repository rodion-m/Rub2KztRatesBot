using Rub2KztRatesBot.Services;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Rub2KztRatesBot;

public class TelegramBotBackgroundService : BackgroundService
{
    private readonly ILogger<TelegramBotBackgroundService> _logger;
    private readonly RatesService _ratesService;
    private readonly TelegramBotClient _botClient;

    public TelegramBotBackgroundService(
        IConfiguration configuration,
        ILogger<TelegramBotBackgroundService> logger,
        RatesService ratesService)
    {
        _logger = logger;
        _ratesService = ratesService;
        var token = configuration["ASPNETCORE_ru_kz_bot_token"];
        _botClient = new TelegramBotClient(token);
    }

    private readonly ReplyKeyboardMarkup _replyMarkup = new[]
    {
        new[] { "Получить актуальные курсы" },
    }!;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await _botClient.GetMeAsync(cancellationToken: stoppingToken);
        _logger.LogInformation("Hello, World! I am user {Id} and my name is {FirstName}",
            me.Id, me.FirstName);
        StartReceiving(stoppingToken);
    }

    private void StartReceiving(CancellationToken cancellationToken)
    {
        // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
        };
        _botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cancellationToken
        );
    }

    private async Task HandleUpdateAsync(
        ITelegramBotClient botClient,
        Update update,
        CancellationToken cancellationToken)
    {
        //_logger.LogDebug("Processing an update: {@Update}", update);
        long chatId;
        if (update.Message is { } message)
            chatId = message.Chat.Id;
        else if (update.CallbackQuery is { } callbackQuery)
            chatId = callbackQuery.From.Id;
        else
            return;


        var sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: await GetBotResponse(),
            replyMarkup: _replyMarkup,
            parseMode: ParseMode.Html,
            cancellationToken: cancellationToken
        );
    }

    private async Task<string> GetBotResponse()
    {
        var rates = await _ratesService.GetRates();
        return "<strong>Курсы рубля к тенге</strong> \n"
               + string.Join('\n',
                   rates.Select(rate => $"{rate.Name}: <strong>{rate.Rate} ₸</strong>"))
               + "\n\nОбсуждение и вопросы в чате \"Переводы RU-KZ\": @ru_kz_money";
    }

    Task HandlePollingErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
        _logger.LogError(exception, errorMessage);
        return Task.CompletedTask;
    }
}