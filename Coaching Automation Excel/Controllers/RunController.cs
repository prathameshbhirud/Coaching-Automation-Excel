using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoachingAutomationExcel.Jobs;

namespace CoachingAutomationExcel.Controllers;

[Authorize]
[ApiController]
[Route("api/run")]
public class RunController : ControllerBase
{
    private readonly NotificationJob _job;

    public RunController(NotificationJob job)
    {
        _job = job;
    }

    // =========================
    // ATTENDANCE
    // =========================
    [HttpGet("attendance")]
    public async Task<IActionResult> Attendance()
    {
        var result = await _job.RunAttendanceNotifications();
        return Ok(result);
    }

    // =========================
    // FEES
    // =========================
    [HttpGet("fees")]
    public async Task<IActionResult> Fees()
    {
        var result = await _job.RunFeeReminders();
        return Ok(result);
    }

    // =========================
    // EXAMS
    // =========================
    [HttpGet("exams")]
    public async Task<IActionResult> Exams()
    {
        var result = await _job.RunExamReminders();
        return Ok(result);
    }

    // =========================
    // BROADCAST
    // =========================
    [HttpGet("broadcast")]
    public async Task<IActionResult> Broadcast()
    {
        var result = await _job.RunBroadcasts();
        return Ok(result);
    }
}