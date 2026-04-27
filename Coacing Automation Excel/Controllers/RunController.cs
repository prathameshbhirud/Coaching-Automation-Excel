using Microsoft.AspNetCore.Mvc;
using CoachingAutomationExcel.Jobs;

namespace CoachingAutomationExcel.Controllers;

[ApiController]
[Route("api/run")]
public class RunController : ControllerBase
{
    private readonly NotificationJob _job;

    public RunController(NotificationJob job)
    {
        _job = job;
    }

    [HttpGet]
    public async Task<IActionResult> Run()
    {
        await _job.Run();
        return Ok("Done");
    }
}