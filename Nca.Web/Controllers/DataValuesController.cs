using Microsoft.AspNetCore.Mvc;
using Nca.Core.Exceptions;
using Nca.Domain.Features.DataDefinitions.Get;
using Nca.Domain.Features.DataValues.List;

namespace Nca.Web.Controllers;

public class DataValuesController(IServiceProvider services)
    : Controller
{
    public async Task<IActionResult> Index(int id)
    {
        var definitionQuery = new DataDefinitionGetQuery { Id = id };
        var definitionHandler = services.GetService<DataDefinitionGetQueryHandler>();
        ViewBag.Definition = await definitionHandler!.ExecuteAsync(definitionQuery) ?? throw new NotFoundException();
        
        var valuesQuery = new DataValueListQuery { DataDefinitionId = id };
        var valuesHandler = services.GetService<DataValueListQueryHandler>();
        var valuesResult = await valuesHandler!.ExecuteAsync(valuesQuery);

        return View(valuesResult);
    }
}
