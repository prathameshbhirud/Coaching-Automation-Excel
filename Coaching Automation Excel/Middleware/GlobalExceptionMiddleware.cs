using System.Text.Json;

namespace CoachingAutomationExcel.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Unhandled Exception");

            context.Response.StatusCode = 500;

            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "An unexpected error occurred"
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}