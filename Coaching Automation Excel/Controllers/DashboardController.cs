using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoachingAutomationExcel.Services;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Controllers;

[Authorize]
[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly ExcelService _excel;
    private readonly ILogger<FilesController> _logger;

    public DashboardController(ExcelService excel, ILogger<FilesController> logger)
    {
        _excel = excel;
        _logger = logger;
    }

    [HttpGet("summary")]
    public IActionResult GetSummary()
    {
        try
        {
            var attendanceStudents = _excel.GetAttendanceStudents();

            var feeStudents = _excel.GetFeesStudents();

            var examStudents = _excel.GetExamStudents();

            var response = new DashboardSummaryDto
            {
                IsDataAvailable = attendanceStudents.Any() || feeStudents.Any() || examStudents.Any(),
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Dashboard summary failed");
            return Ok(new DashboardSummaryDto
            {
                TotalStudents = 0,
                AttendanceToday = 0,
                PendingFees = 0,
                UpcomingExams = 0
            });
        }
        
    }
}