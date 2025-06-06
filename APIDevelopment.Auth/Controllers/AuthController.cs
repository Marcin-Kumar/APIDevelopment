using APIDevelopment.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIDevelopment.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;
    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        if (request.Username == "testuser" && request.Password == "password123")
        {
            var token = _jwtService.GenerateToken(request.Username);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }
}
