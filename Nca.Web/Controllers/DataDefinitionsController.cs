using Microsoft.AspNetCore.Mvc;
using Nca.Domain.Features.DataDefinitions.Add;
using Nca.Domain.Features.DataDefinitions.List;

namespace Nca.Web.Controllers;

public class DataDefinitionsController(IServiceProvider services)
    : Controller
{
    public async Task<IActionResult> Index()
    {
        var handler = services.GetService<DataDefinitionListQueryHandler>();
        var result = await handler!.ExecuteAsync(new DataDefinitionListQuery());

        return View(result);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(DataDefinitionAddCmd cmd)
    {
        var handler = services.GetService<DataDefinitionAddCmdHandler>();
        await handler!.ExecuteAsync(cmd);
        
        return RedirectToAction("Index");
    }
}