using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RpgApi.Application.Authorization.Requirements;
using RpgApi.Infrastructure.Contexts;

namespace RpgApi.Application.Authorization.Handlers;

public class IsOwnerOrGMHandler(
    MainDbContext context,
    IHttpContextAccessor httpContextAccessor)
    : AuthorizationHandler<IsOwnerOrGMRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext handlerContext,
        IsOwnerOrGMRequirement requirement)
    {
        var userIdString = handlerContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdString, out var userId))
        {
            handlerContext.Fail();
            return;
        }

        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext == null)
        {
            handlerContext.Fail();
            return;
        }

        var sheetIdString = httpContext.Request.RouteValues["id"]?.ToString();
        if (!int.TryParse(sheetIdString, out var sheetId))
        {
            handlerContext.Fail();
            return;
        }

        var sheet = await context.CharacterSheets
            .AsNoTracking()
            .Include(cs =>
                cs.GameSession)
            .FirstOrDefaultAsync(cs =>
                cs.Id == sheetId);

        if (sheet == null)
        {
            handlerContext.Fail();
            return;
        }

        if (userId == sheet.OwnerUserId
            || sheet.GameSession != null 
            && userId == sheet.GameSession.GameMasterId)
        {
            handlerContext.Succeed(requirement);
        }
        else
        {
            handlerContext.Fail();
        }
    }
}
