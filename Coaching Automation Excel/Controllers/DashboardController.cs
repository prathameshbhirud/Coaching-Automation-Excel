using Microsoft.AspNetCore.Mvc;
using CoachingAutomationExcel.Services;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly ExcelService _excel;

    public DashboardController(ExcelService excel)
    {
        _excel = excel;
    }

    [HttpGet("summary")]
    public IActionResult GetSummary()
    {
        var attendanceStudents = _excel.GetAttendanceStudents();

        var feeStudents = _excel.GetFeesStudents();

        var examStudents = _excel.GetExamStudents();

        var response = new DashboardSummaryDto
        {
            TotalStudents = attendanceStudents.Count,

            AttendanceToday = attendanceStudents.Count(
                x => x.Attendance.Equals(
                    "Present",
                    StringComparison.OrdinalIgnoreCase)),

            PendingFees = feeStudents.Count(x => x.FeesDue > 0),

            UpcomingExams = examStudents.Count(x => x.ExamDate >= DateTime.Today)
        };

        return Ok(response);
    }
}