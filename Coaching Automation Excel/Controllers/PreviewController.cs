using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoachingAutomationExcel.Models;
using CoachingAutomationExcel.Services;

namespace CoachingAutomationExcel.Controllers;

[Authorize]
[ApiController]
[Route("api/preview")]
public class PreviewController : ControllerBase
{
    private readonly ExcelService _excel;

    public PreviewController(
        ExcelService excel)
    {
        _excel = excel;
    }

    [HttpGet("attendance")]
    public IActionResult Attendance()
    {
        var students = _excel.GetAttendanceStudents();

        return Ok(new PreviewDto
            {
                Module = "Attendance",
                TotalRecords = students.Count,
                ActionableRecords = students.Count(x => x.Attendance.Equals("Absent", StringComparison.OrdinalIgnoreCase))
            });
    }

    [HttpGet("fees")]
    public IActionResult Fees()
    {
        var students = _excel.GetFeesStudents();

        return Ok(new PreviewDto
            {
                Module = "Fees",
                TotalRecords = students.Count,
                ActionableRecords = students.Count(x => x.FeesDue > 0)
            });
    }

    [HttpGet("exams")]
    public IActionResult Exams()
    {
        var exams = _excel.GetExamStudents();

        return Ok(new PreviewDto
            {
                Module = "Exams",
                TotalRecords = exams.Count,
                ActionableRecords = exams.Count(x => x.ExamDate >= DateTime.Today)
            });
    }

    [HttpGet("broadcast")]
    public IActionResult Broadcast()
    {
        var broadcasts = _excel.GetBroadcastMessages();

        return Ok(new PreviewDto
            {
                Module = "Broadcast",
                TotalRecords = broadcasts.Count,
                ActionableRecords = broadcasts.Count
            });
    }
}