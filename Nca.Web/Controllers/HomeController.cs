using Microsoft.AspNetCore.Mvc;
using Nca.Domain.Features.DataDefinitions.List;

namespace Nca.Web.Controllers;

public class HomeController(IServiceProvider services) 
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var handler = services.GetService<DataDefinitionListQueryHandler>();

        var result = await handler!.ExecuteAsync(new DataDefinitionListQuery());
            
        return Content($"Home#Index result count: {result.Entries.Count}");
    }
}
