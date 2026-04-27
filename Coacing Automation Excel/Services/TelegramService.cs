using Microsoft.Extensions.Options;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class TelegramService
{
    private readonly TelegramSettings _settings;
    private readonly HttpClient _http;

    public TelegramService(IOptions<TelegramSettings> settings)
    {
        _settings = settings.Value;
        _http = new HttpClient();
    }

    public async Task Send(string message)
    {
        var url = $"https://api.telegram.org/bot{_settings.BotToken}/sendMessage";

        var payload = new
        {
            chat_id = _settings.ChatId,
            text = message
        };

        await _http.PostAsJsonAsync(url, payload);
    }
}