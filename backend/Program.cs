using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RpgApi.Application.Extensions;
using RpgApi.Domain.Entities;
using RpgApi.Infrastructure.Contexts;
using RpgApi.Infrastructure.Extensions;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrasctructureServices();
builder.Services.AddApplicationServices();
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