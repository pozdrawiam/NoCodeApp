using Microsoft.AspNetCore.Mvc;
using Nca.Core.Exceptions;
using Nca.Domain.Features.DataDefinitions.Add;
using Nca.Domain.Features.DataDefinitions.Delete;
using Nca.Domain.Features.DataDefinitions.Edit;
using Nca.Domain.Features.DataDefinitions.Get;
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
        var cmd = new DataDefinitionAddCmd
        {
            Fields = Enumerable.Range(0, 5).Select(x => new DataDefinitionAddCmd.FieldDto()).ToList()
        };
        
        return View(cmd);
    }

    [HttpPost]
    public async Task<IActionResult> Add(DataDefinitionAddCmd cmd)
    {
        var handler = services.GetService<DataDefinitionAddCmdHandler>();
        await handler!.ExecuteAsync(cmd);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var handler = services.GetService<DataDefinitionGetQueryHandler>();
        var result = await handler!.ExecuteAsync(new DataDefinitionGetQuery { Id = id });

        if (result == null)
        {
            throw new NotFoundException();
        }

        var cmd = new DataDefinitionEditCmd
        {
            Id = result.Id,
            Name = result.Name
        };

        return View(cmd);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DataDefinitionEditCmd cmd)
    {
        var handler = services.GetService<DataDefinitionEditCmdHandler>();
        await handler!.ExecuteAsync(cmd);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var handler = services.GetService<DataDefinitionsDeleteCmdHandler>();

        var cmd = new DataDefinitionsDeleteCmd
        {
            Ids = new[] { id }
        };

        await handler!.ExecuteAsync(cmd);

        return RedirectToAction("Index");
    }
}
