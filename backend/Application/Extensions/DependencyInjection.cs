using Microsoft.AspNetCore.Authorization;
using RpgApi.Application.Authorization.Handlers;

namespace RpgApi.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationHandler, IsGameMasterHandler>();
        services.AddScoped<IAuthorizationHandler, IsOwnerHandler>();
        services.AddScoped<IAuthorizationHandler, IsOwnerOrGMHandler>();
        services.AddScoped<IAuthorizationHandler, IsInSessionHandler>();
        
        return services;
    }
}