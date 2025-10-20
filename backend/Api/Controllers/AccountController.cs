using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Application.DTOs;
using RpgApi.Application.DTOs.Account;

namespace RpgApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> UserInfo()
    {
        throw new NotImplementedException();
    }
}