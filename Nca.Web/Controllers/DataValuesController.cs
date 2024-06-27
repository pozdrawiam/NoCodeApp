using Microsoft.AspNetCore.Mvc;
using Nca.Core.Exceptions;
using Nca.Domain.Features.DataDefinitions.Get;
using Nca.Domain.Features.DataValues.Add;
using Nca.Domain.Features.DataValues.List;

namespace Nca.Web.Controllers;

public class DataValuesController(IServiceProvider services)
    : Controller
{
    public async Task<IActionResult> Index(int id)
    {
        ViewBag.Definition = await GetDefinition(id);
        
        var valuesQuery = new DataValueListQuery { DataDefinitionId = id };
        var valuesHandler = services.GetService<DataValueListQueryHandler>();
        var valuesResult = await valuesHandler!.ExecuteAsync(valuesQuery);

        return View(valuesResult);
    }
    
    [HttpGet]
    public async Task<IActionResult> Add(int id)
    {
        var definition = await GetDefinition(id);
        
        var cmd = new DataValueAddCmd
        {
            DataDefinitionId = id,
            Fields = definition.Fields.Select(x => new DataValueAddCmd.FieldValueAddDto
            {
                FieldDefinitionId = x.Id
            }).ToList()
        };
        
        ViewBag.Definition = definition;
        
        return View(cmd);
    }

    private async Task<DataDefinitionGetQueryResult> GetDefinition(int id)
    {
        var definitionQuery = new DataDefinitionGetQuery { Id = id };
        var definitionHandler = services.GetService<DataDefinitionGetQueryHandler>();
        
        return await definitionHandler!.ExecuteAsync(definitionQuery) ?? throw new NotFoundException();
    }
}
