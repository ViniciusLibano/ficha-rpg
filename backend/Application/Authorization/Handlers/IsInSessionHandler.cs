using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RpgApi.Application.Authorization.Requirements;
using RpgApi.Infrastructure.Contexts;

namespace RpgApi.Application.Authorization.Handlers;

public class IsInSessionHandler(
    MainDbContext context,
    IHttpContextAccessor httpContextAccessor
) : AuthorizationHandler<IsInSessionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext handlerContext,
        IsInSessionRequirement requirement)
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
            .Include(gs =>
                gs.PlayersLink)
            .FirstOrDefaultAsync(gs =>
                gs.Id == sessionId);

        if (session == null)
        {
            handlerContext.Fail();
            return;
        }

        if (session.GameMasterId == userId ||
            session.PlayersLink.Any(gs =>
            gs.PlayerId == userId))
        {
            handlerContext.Succeed(requirement);
        }
        else
        {
            handlerContext.Fail();
        }
    }
}
