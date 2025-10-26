using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RpgApi.Domain.Entities;
using RpgApi.Infrastructure.Contexts;

namespace RpgApi.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasctructureServices(this IServiceCollection services)
    {
        var connectionString = Environment
           .GetEnvironmentVariable("DB_CONN_STRING")
            ?? string.Empty;

        services.AddDbContext<MainDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddIdentity<User, IdentityRole<int>>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<MainDbContext>();
        
        return services;
    }
}