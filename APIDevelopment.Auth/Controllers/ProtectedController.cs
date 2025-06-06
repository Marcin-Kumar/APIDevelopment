using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIDevelopment.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProtectedController : ControllerBase
{
    [HttpGet("user")]
    [Authorize]
    public IActionResult GetUsername()
    {
        var username = User.Identity?.Name ?? "unknown";
        return Ok(new
        {
            message = "Authorized user",
            user = username
        });
    }
}
