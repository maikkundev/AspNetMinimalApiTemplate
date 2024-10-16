using Microsoft.EntityFrameworkCore;
using AspNetMinimalApiTemplate.Data;
using AspNetMinimalApiTemplate.Handlers;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Env.GetString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.UseRouting();

app.MapPostHandlers();

app.Run();
