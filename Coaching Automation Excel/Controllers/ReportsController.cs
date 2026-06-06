using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoachingAutomationExcel.Models;
using CoachingAutomationExcel.Services;

namespace CoachingAutomationExcel.Controllers;

[Authorize]
[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly ExcelService _excel;

    private readonly ExportService _export;

    private readonly PdfExportService _pdfExport;

    public ReportsController(ExcelService excel, ExportService export, PdfExportService pdfExport)
    {
        _excel = excel;
        _export = export;
        _pdfExport = pdfExport;
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

    [HttpGet("attendance/export")]
    public IActionResult ExportAttendance()
    {
        var students = _excel.GetAttendanceStudents();

        var file = _export.ExportAttendance(students);

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"attendance-{DateTime.Now:yyyyMMdd}.xlsx");
    }

    [HttpGet("fees/export")]
    public IActionResult ExportFees()
    {
        var data = _excel.GetFeesStudents();

        var file = _export.ExportFees(data);

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"fees-{DateTime.Now:yyyyMMdd}.xlsx");
    }

    [HttpGet("exams/export")]
    public IActionResult ExportExams()
    {
        var data = _excel.GetExamStudents();

        var file = _export.ExportExams(data);

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"exams-{DateTime.Now:yyyyMMdd}.xlsx");
    }

    [HttpGet("broadcast/export")]
    public IActionResult ExportBroadcast()
    {
        var data = _excel.GetBroadcastMessages();

        var file = _export.ExportBroadcast(data);

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"broadcast-{DateTime.Now:yyyyMMdd}.xlsx");
    }

    [HttpGet("attendance/pdf")]
    public IActionResult AttendancePdf()
    {
        var students = _excel.GetAttendanceStudents();

        var headers = new List<string>
        {
            "Student",
            "Phone",
            "Attendance"
        };

        var rows = students.Select(x =>
                new List<string>
                {
                    x.StudentName,
                    x.ParentPhone,
                    x.Attendance
                })
            .ToList();

        var pdf = _pdfExport.GeneratePdf(
                "Attendance Report",
                headers,
                rows);

        return File(pdf, "application/pdf", "attendance-report.pdf");
    }

    [HttpGet("fees/pdf")]
    public IActionResult FeesPdf()
    {
        var students = _excel.GetFeesStudents();

        var headers = new List<string>
        {
            "Student",
            "Phone",
            "Fees Due"
        };

        var rows = students.Select(x =>
                new List<string>
                {
                    x.StudentName,
                    x.ParentPhone,
                    x.FeesDue.ToString()
                })
            .ToList();

        var pdf = _pdfExport.GeneratePdf(
                "Fees Report",
                headers,
                rows);

        return File(pdf, "application/pdf", "fees-report.pdf");
    }

    [HttpGet("exams/pdf")]
    public IActionResult ExamsPdf()
    {
        var exams = _excel.GetExamStudents();

        var headers = new List<string>
        {
            "Student",
            "Phone",
            "Exam Name",
            "Exam Date"
        };

        var rows = exams.Select(x =>
                new List<string>
                {
                    x.StudentName,
                    x.ParentPhone,
                    x.ExamName,
                    x.ExamDate?.ToString("dd-MMM-yyyy")
                })
            .ToList();

        var pdf = _pdfExport.GeneratePdf(
                "Exam Report",
                headers,
                rows);

        return File(pdf, "application/pdf", "exam-report.pdf");
    }

    [HttpGet("broadcast/pdf")]
    public IActionResult BroadcastPdf()
    {
        var messages = _excel.GetBroadcastMessages();

        var headers = new List<string>
        {
            "Message"
        };

        var rows = messages.Select(x =>
                new List<string>
                {
                    x.Message
                })
            .ToList();

        var pdf = _pdfExport.GeneratePdf(
                "Broadcast Report",
                headers,
                rows);

        return File(pdf, "application/pdf", "broadcast-report.pdf");
    }
}