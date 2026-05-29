using OfficeOpenXml;
using Microsoft.Extensions.Options;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class ExcelService
{
    private readonly ExcelSettings _settings;

    public ExcelService(IOptions<ExcelSettings> settings)
    {
        _settings = settings.Value;

        ExcelPackage.License.SetNonCommercialPersonal("CoachingAutomationExcel");
    }

    // =========================================
    // ATTENDANCE
    // =========================================
    public List<Student> GetAttendanceStudents()
    {
        var students = new List<Student>();

        var fullPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            _settings.AttendanceFilePath);

        var file = new FileInfo(fullPath);

        using var package = new ExcelPackage(file);

        var sheet = package.Workbook.Worksheets.FirstOrDefault();

        if (sheet == null)
            throw new Exception("Attendance worksheet not found");

        for (int row = 2; row <= sheet.Dimension.Rows; row++)
        {
            Enum.TryParse(
                sheet.Cells[row, 4].Text,
                true,
                out NotificationChannel channel);

            students.Add(new Student
            {
                StudentName = sheet.Cells[row, 1].Text,
                ParentPhone = sheet.Cells[row, 2].Text,
                Attendance = sheet.Cells[row, 3].Text,
                PreferredChannel = channel
            });
        }

        return students;
    }

    // =========================================
    // FEES
    // =========================================
    public List<Student> GetFeesStudents()
    {
        var students = new List<Student>();

        var fullPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            _settings.FeesFilePath);

        var file = new FileInfo(fullPath);

        using var package = new ExcelPackage(file);

        var sheet = package.Workbook.Worksheets.FirstOrDefault();

        if (sheet == null)
            throw new Exception("Fees worksheet not found");

        for (int row = 2; row <= sheet.Dimension.Rows; row++)
        {
            Enum.TryParse(
                sheet.Cells[row, 4].Text,
                true,
                out NotificationChannel channel);

            students.Add(new Student
            {
                StudentName = sheet.Cells[row, 1].Text,
                ParentPhone = sheet.Cells[row, 2].Text,
                FeesDue = decimal.TryParse(
                    sheet.Cells[row, 3].Text,
                    out var fee)
                    ? fee
                    : 0,

                PreferredChannel = channel
            });
        }

        return students;
    }

    // =========================================
    // EXAMS
    // =========================================
    public List<Student> GetExamStudents()
    {
        var students = new List<Student>();

        var fullPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            _settings.ExamsFilePath);

        var file = new FileInfo(fullPath);

        using var package = new ExcelPackage(file);

        var sheet = package.Workbook.Worksheets.FirstOrDefault();
        if (sheet == null)
        {
            throw new Exception("No worksheet found in exams.xlsx");
        }

        if (sheet == null)
            throw new Exception("Exams worksheet not found");

        for (int row = 2; row <= sheet.Dimension.Rows; row++)
        {
            Enum.TryParse(
                sheet.Cells[row, 5].Text,
                true,
                out NotificationChannel channel);

            var dateText = sheet.Cells[row, 4].Text;

            Console.WriteLine($"Date text: {dateText}"); //TODO

            DateTime.TryParse(dateText, out DateTime examDate);

            students.Add(new Student
            {
                StudentName = sheet.Cells[row, 1].Text,
                ParentPhone = sheet.Cells[row, 2].Text,
                ExamName = sheet.Cells[row, 3].Text,
                ExamDate = examDate,
                PreferredChannel = channel
            });
        }

        return students;
    }
}