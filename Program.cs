using Microsoft.EntityFrameworkCore;
using AspNetMinimalApiTemplate.Data;
using AspNetMinimalApiTemplate.Handlers;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Env.GetString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

app.UseRouting();

app.MapPostHandlers();

app.Run();
