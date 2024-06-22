using Nca.Domain.Entities;
using Nca.Domain.Features.DataDefinitions.List;
using Nca.Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDb, SqliteDb>(_ => new SqliteDb(builder.Configuration["DbConnection"]!));

builder.Services.AddTransient<DataDefinitionListQueryHandler>();

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

using (IServiceScope scope = app.Services.CreateScope())
{
    Db? db = scope.ServiceProvider.GetRequiredService<IDb>() as Db;
    
    if (await db!.Database.EnsureCreatedAsync())
        app.Logger.LogDebug("Db created");
}

app.Logger.LogInformation("Starting app at {Date}", DateTime.Now);

app.Run();
