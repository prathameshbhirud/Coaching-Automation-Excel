using Microsoft.Extensions.Options;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class TelegramService
{
    private readonly TelegramSettings _settings;
    private readonly HttpClient _http;
    private readonly ILogger<WhatsAppService> _logger;

    public TelegramService(IOptions<TelegramSettings> settings, ILogger<WhatsAppService> logger)
    {
        _settings = settings.Value;
        _http = new HttpClient();
        _logger = logger;
    }

    public async Task Send(string message)
    {
        try
        {
            var url = $"https://api.telegram.org/bot{_settings.BotToken}/sendMessage";

            var payload = new
            {
                chat_id = _settings.ChatId,
                text = message
            };

            await _http.PostAsJsonAsync(url, payload);    
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed sending Telegram message to {message}");
        }
        
    }
}