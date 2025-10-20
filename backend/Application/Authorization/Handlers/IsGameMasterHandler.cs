using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RpgApi.Application.Authorization.Requirements;
using RpgApi.Infrastructure.Contexts;

namespace RpgApi.Application.Authorization.Handlers;

public class IsGameMasterHandler(
    MainDbContext context, 
    IHttpContextAccessor httpContextAccessor) 
    : AuthorizationHandler<IsGameMasterRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext handlerContext, 
        IsGameMasterRequirement requirement)
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

        var sessionIdString = httpContext.Request.RouteValues["id"]?.ToString();
        if (!int.TryParse(sessionIdString, out var sessionId))
        {
            handlerContext.Fail();
            return;
        }

        var session = await context.GameSessions
            .AsNoTracking()
            .FirstOrDefaultAsync(gs => gs.Id == sessionId);

        if (session == null)
        {
            handlerContext.Fail();
            return;
        }
        
        if (session.GameMasterId == userId)
        {
            handlerContext.Succeed(requirement);
        }
        else
        {
            handlerContext.Fail();
        }
    }
}
