using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Application.DTOs;
using RpgApi.Application.DTOs.SheetModels;
using RpgApi.Domain.Entities;

namespace RpgApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SheetModelsController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int systemId)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSheetModelRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateSheetModelRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }
}