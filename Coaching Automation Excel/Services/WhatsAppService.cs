using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Options;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;
public class WhatsAppService
{
    private readonly TwilioSettings _settings;
    private readonly ILogger<WhatsAppService> _logger;

    public WhatsAppService(IOptions<TwilioSettings> settings, ILogger<WhatsAppService> logger)
    {
        _settings = settings.Value;
        TwilioClient.Init(_settings.AccountSid, _settings.AuthToken);
        _logger = logger;
    }

    public void Send(string to, string message)
    {
        try
        {
            MessageResource.Create(
                from: new PhoneNumber(_settings.FromNumber),
                to: new PhoneNumber($"whatsapp:{to}"),
                body: message
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed sending WhatsApp message to {to}");
        }
        
    }
}