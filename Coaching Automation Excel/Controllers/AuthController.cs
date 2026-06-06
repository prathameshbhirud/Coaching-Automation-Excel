using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using CoachingAutomationExcel.Models;
using CoachingAutomationExcel.Services;


namespace CoachingAutomationExcel.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _auth;

    public AuthController(AuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequestDto request)
    {
        var result = _auth.Login(request);

        if(result == null)
        {
            return Unauthorized("Invalid credentials");
        }

        return Ok(result);
    }
}