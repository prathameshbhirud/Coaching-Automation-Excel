using CoachingAutomationExcel.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoachingAutomationExcel.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticsController : ControllerBase
{
    private readonly StatisticsService _stats;

    public StatisticsController(StatisticsService stats)
    {
        _stats = stats;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_stats.GetStats());
    }

    [HttpGet("attendance-trend")]
    public IActionResult AttendanceTrend()
    {
        return Ok(_stats.GetAttendanceTrend());
    }
}