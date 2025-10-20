using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Application.DTOs;
using RpgApi.Application.DTOs.CharacterSheets;
using RpgApi.Domain.Entities;

namespace RpgApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterSheetsController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetSheets()
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsOwnerOrGM")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSheetById(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddSheet([FromBody] CreateCharacterSheetRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsOwnerOrGM")]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> EditSheet(int id, [FromBody] UpdateCharacterSheetRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Policy = "IsOwner")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSheet(int id)
    {
        throw new NotImplementedException();
    }
}