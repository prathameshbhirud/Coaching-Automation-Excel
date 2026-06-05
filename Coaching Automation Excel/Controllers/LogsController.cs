using CoachingAutomationExcel.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoachingAutomationExcel.Controllers;

[ApiController]
[Route("api/logs")]
public class LogsController : ControllerBase
{
    private readonly ActivityService _activityService;

    public LogsController(ActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet("recent")]
    public IActionResult Recent()
    {
        return Ok(_activityService.GetRecent());
    }
}