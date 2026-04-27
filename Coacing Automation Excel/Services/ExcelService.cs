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
        // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelPackage.License.SetNonCommercialPersonal("CoachingAUtomationExcel"); 
    }

    public List<Student> GetStudents()
    {
        var students = new List<Student>();

        var file = new FileInfo(_settings.FilePath);
        using var package = new ExcelPackage(file);
        var sheet = package.Workbook.Worksheets[0];

        for (int row = 2; row <= sheet.Dimension.Rows; row++)
        {
            Enum.TryParse(sheet.Cells[row, 5].Text, true, out NotificationChannel channel);

            students.Add(new Student
            {
                StudentName = sheet.Cells[row, 1].Text,
                ParentPhone = sheet.Cells[row, 2].Text,
                Attendance = sheet.Cells[row, 3].Text,
                FeesDue = decimal.TryParse(sheet.Cells[row, 4].Text, out var fee) ? fee : 0,
                PreferredChannel = channel
            });
        }

        return students;
    }
}