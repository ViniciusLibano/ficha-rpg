using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Application.DTOs;
using RpgApi.Application.DTOs.GameSessions;
using RpgApi.Domain.Entities;

namespace RpgApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesSessionsController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetSessions()
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSessionById(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateSession([FromBody] CreateGameSessionRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditSession(int id, [FromBody] UpdateGameSessionRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpPost("{id:int}/players")]
    public async Task<IActionResult> AddPlayers(int id, [FromBody] AddPlayerRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpDelete("{id:int}/players/{playerId:int}")]
    public async Task<IActionResult> DeletePlayers(int id, int playerId)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpDelete("{id:int}/leave")]
    public async Task<IActionResult> LeaveSession(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsInSession")]
    [HttpGet("{id:int}/scene")]
    public async Task<IActionResult> GetScene(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpPost("{id:int}/scene/add")]
    public async Task<IActionResult> AddScene(int id, [FromBody] SceneActionRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpDelete("{id:int}/scene/remove")]
    public async Task<IActionResult> DeleteScene(int id, [FromBody] SceneActionRequest request)
    {
        throw new NotImplementedException();
    }
    
    [Authorize(Policy = "IsInSession")]
    [HttpGet("{id:int}/charactersheets")]
    public async Task<IActionResult> GetCharacterSheets(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsOwner")]
    [HttpPost("{id:int}/assignsheet")]
    public async Task<IActionResult> AssignSheet(int id, [FromBody] AssignSheetRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsGameMaster")]
    [HttpPost("{id:int}/clonesheet")]
    public async Task<IActionResult> CloneSheet(int id, [FromBody] CloneSheetRequest request)
    {
        throw new NotImplementedException();
    }
}