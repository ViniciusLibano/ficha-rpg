using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Application.DTOs;
using RpgApi.Application.DTOs.GameSystems;

namespace RpgApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameSystemsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetGameSystems()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetGameSystemById(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddSystem([FromBody] CreateGameSystemRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditSystem(int id, [FromBody] UpdateGameSystemRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSystem(int id)
    {
        throw new NotImplementedException();
    }
}