using System.Text;
using Serilog;
using Hangfire;
using Hangfire.MemoryStorage;
using QuestPDF.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

using CoachingAutomationExcel.Services;
using CoachingAutomationExcel.Jobs;
using CoachingAutomationExcel.Models;
using CoachingAutomationExcel.Data;
using CoachingAutomationExcel.Middleware;

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    // Apply the new OpenApiSecuritySchemeReference format
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", document),
            [] // Array of scopes (can be empty for JWT Bearer)
        }
    });
});

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
builder.Services.AddScoped<NotificationJob>();
builder.Services.AddSingleton<MessageTemplateService>();
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<StatisticsService>();
builder.Services.AddScoped<ExportService>();
builder.Services.AddScoped<PdfExportService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<SettingsService>();

// Adding DbContext for SQLite
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "coaching.db");

builder.Services.AddDbContext<CoachingDbContext>(
    options => options.UseSqlite($"Data Source={dbPath}"));

// JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtSettings = jwtSection.Get<JwtSettings>()!;
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

        options.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    jwtSettings.Issuer,

                ValidAudience =
                    jwtSettings.Audience,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            jwtSettings.Key))
            };

        options.Events =
            new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    Console.WriteLine(
                        $"TOKEN RECEIVED: {context.Token}");

                    return Task.CompletedTask;
                },

                OnAuthenticationFailed = context =>
                {
                    Console.WriteLine(
                        $"JWT FAILED: {context.Exception}");

                    return Task.CompletedTask;
                }
            };
    });

// Authorization
builder.Services.AddAuthorization();

// Hangfire
builder.Services.AddHangfire(config =>config.UseMemoryStorage());

builder.Services.AddHangfireServer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
        {
            policy.WithOrigins(
                    "http://localhost:4200",
                    "https://yourfuturedomain.com") // TODO: replace with actual domain post deployment
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// TODO: remove this after testing.
Console.WriteLine(builder.Configuration["Jwt:Key"]);

// QuestPDF License
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CoachingDbContext>();
    DatabaseSeeder.SeedUsers(db);
    DatabaseSeeder.SeedAppSettings(db);
}

app.UseRouting();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Maintain order for following two middlewares
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Hangfire Dashboard
app.UseHangfireDashboard();

app.UseCors("AllowAngular");

app.Run();