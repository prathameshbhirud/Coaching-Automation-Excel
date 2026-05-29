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

    // =========================
    // ATTENDANCE
    // =========================
    [HttpGet("attendance")]
    public async Task<IActionResult> Attendance()
    {
        await _job.RunAttendanceNotifications();

        return Ok("Attendance notifications sent.");
    }

    // =========================
    // FEES
    // =========================
    [HttpGet("fees")]
    public async Task<IActionResult> Fees()
    {
        await _job.RunFeeReminders();

        return Ok("Fee reminders sent.");
    }

    // =========================
    // EXAMS
    // =========================
    [HttpGet("exams")]
    public async Task<IActionResult> Exams()
    {
        await _job.RunExamReminders();

        return Ok("Exam reminders sent.");
    }
}