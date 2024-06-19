using Nca.Domain.Entities;
using Nca.Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDb, SqliteDb>(_ => new SqliteDb(builder.Configuration["DbConnection"]!));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
