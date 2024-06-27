using Microsoft.AspNetCore.Mvc;
using Nca.Domain.Features.DataValues.List;

namespace Nca.Web.Controllers;

public class DataValuesController(IServiceProvider services)
    : Controller
{
    public async Task<IActionResult> Index(int id)
    {
        var cmd = new DataValueListQuery { DataDefinitionId = id };
        var handler = services.GetService<DataValueListQueryHandler>();
        var result = await handler!.ExecuteAsync(cmd);

        return View(result);
    }
}
