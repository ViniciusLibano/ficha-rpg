using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Application.DTOs;
using RpgApi.Application.DTOs.Account;
using RpgApi.Application.Services.Interfaces;
using RpgApi.Domain.Entities;

namespace RpgApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    IAccountService accountService,
    IConfiguration configuration) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        var register = await accountService.RegisterAsync(request);
        
        if (!register.Succeeded)
            return BadRequest(new { errors = register.Errors });
        
        return Ok(register.Response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var login = await accountService.LoginAsync(request);
        
        if (!login.Succeeded)
            return Unauthorized(new { errors = login.Errors });
        
        return Ok(login.Response);
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> UserInfo()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var user = await accountService.GetUserInfoAsync(userId!);
        if (user == null)
            return NotFound(new { Message = "Usuário não encontrado." });

        return Ok(user);
    }
}