using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using CoachingAutomationExcel.Services;

[Authorize]
[ApiController]
[Route("api/settings")]
public class SettingsController : ControllerBase
{
    private readonly SettingsService _service;

    public SettingsController(SettingsService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.Get());
    }

    [HttpPost]
    public IActionResult Save(SettingsDto dto)
    {
        _service.Save(dto);
        return Ok();
    }
}