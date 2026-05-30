using CoachingAutomationExcel.Services;
using CoachingAutomationExcel.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using CoachingAutomationExcel.Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.Configure<TwilioSettings>(
    builder.Configuration.GetSection("Twilio"));

builder.Services.Configure<TelegramSettings>(
    builder.Configuration.GetSection("Telegram"));

builder.Services.Configure<ExcelSettings>(
    builder.Configuration.GetSection("Excel"));

// Services
builder.Services.AddSingleton<ExcelService>();
builder.Services.AddSingleton<WhatsAppService>();
builder.Services.AddSingleton<TelegramService>();
builder.Services.AddSingleton<NotificationJob>();
builder.Services.AddSingleton<MessageTemplateService>();

// Hangfire
builder.Services.AddHangfire(config =>
    config.UseMemoryStorage());

builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

// Hangfire Dashboard
app.UseHangfireDashboard();

app.Run();