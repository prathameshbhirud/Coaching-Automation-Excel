using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoachingAutomationExcel.Services;

namespace CoachingAutomationExcel.Controllers;

[Authorize]
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