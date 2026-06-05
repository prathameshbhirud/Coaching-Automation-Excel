using CoachingAutomationExcel.Models;
using CoachingAutomationExcel.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoachingAutomationExcel.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly ExcelService _excel;

    public ReportsController(ExcelService excel)
    {
        _excel = excel;
    }

    [HttpGet("attendance")]
    public IActionResult Attendance()
    {
        var students = _excel.GetAttendanceStudents();
        return Ok(students);
    }

    [HttpGet("fees")]
    public IActionResult Fees()
    {
        var students =_excel.GetFeesStudents();
        return Ok(students);
    }

    [HttpGet("exams")]
    public IActionResult Exams()
    {
        var exams = _excel.GetExamStudents();
        return Ok(exams);
    }

    [HttpGet("broadcast")]
    public IActionResult Broadcast()
    {
        var broadcasts = _excel.GetBroadcastMessages();
        return Ok(broadcasts);
    }
}