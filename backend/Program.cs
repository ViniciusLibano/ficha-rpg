using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RpgApi.Domain.Entities;
using RpgApi.Infrastructure.Contexts;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment
    .GetEnvironmentVariable("DB_CONN_STRING")
        ?? string.Empty;

builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<MainDbContext>();

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();