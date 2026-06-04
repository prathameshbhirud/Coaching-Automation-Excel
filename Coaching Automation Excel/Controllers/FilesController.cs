using CoachingAutomationExcel.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoachingAutomationExcel.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<FilesController> _logger;

    public FilesController(IWebHostEnvironment environment, ILogger<FilesController> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    [HttpPost("attendance")]
    public async Task<IActionResult> UploadAttendance(IFormFile file)
    {
        return await UploadFile(file, "attendance.xlsx");
    }

    [HttpPost("fees")]
    public async Task<IActionResult> UploadFees(IFormFile file)
    {
        return await UploadFile(file, "fees.xlsx");
    }

    [HttpPost("exams")]
    public async Task<IActionResult> UploadExams(IFormFile file)
    {
        return await UploadFile(file, "exams.xlsx");
    }

    [HttpPost("broadcast")]
    public async Task<IActionResult> UploadBroadcast(IFormFile file)
    {
        return await UploadFile(file, "broadcast.xlsx");
    }

    private async Task<IActionResult> UploadFile(IFormFile file, string targetFileName)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest(new FileUploadResponse
                {
                    Success = false,
                    Message = "No file uploaded"
                });
        }

        var uploadFolder = Path.Combine(_environment.ContentRootPath, "uploads");

        if (!Directory.Exists(uploadFolder))
        {
            Directory.CreateDirectory(uploadFolder);
        }

        var filePath = Path.Combine(uploadFolder, targetFileName);

        await using var stream = new FileStream(filePath, FileMode.Create);

        await file.CopyToAsync(stream);

        _logger.LogInformation("{FileName} uploaded successfully", targetFileName);

        return Ok(new FileUploadResponse
            {
                Success = true,
                FileName = targetFileName,
                Message = "File uploaded successfully"
            });
    }
}