using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoachingAutomationExcel.Services;

namespace CoachingAutomationExcel.Controllers;

[Authorize]
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