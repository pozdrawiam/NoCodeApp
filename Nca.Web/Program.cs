using Nca.Domain.Entities;
using Nca.Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDb, SqliteDb>(_ => new SqliteDb(builder.Configuration["DbConnection"]!));

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Logger.LogInformation("Starting app at {Date}", DateTime.Now);

app.Run();
