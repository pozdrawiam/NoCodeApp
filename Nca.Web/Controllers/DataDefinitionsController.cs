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
        var cmd = new DataDefinitionAddCmd();
        
        cmd.Fields.Add(new DataDefinitionAddCmd.FieldDto());
        
        return View(cmd);
    }

    [HttpPost]
    public async Task<IActionResult> Add(DataDefinitionAddCmd cmd)
    {
        if (cmd.AddField)
        {
            cmd.Fields.Add(new DataDefinitionAddCmd.FieldDto());
            
            return View(cmd);
        }

        var fieldsToRemove = cmd.Fields.Where(f => f.Remove).ToArray();

        if (fieldsToRemove.Length > 0)
        {
            foreach (var field in fieldsToRemove)
                cmd.Fields.Remove(field);
            
            ModelState.Clear();
            return View(cmd);
        }

        var fieldsToMove = cmd.Fields.Where(f => f.Up || f.Down).ToArray();
        
        if (fieldsToMove.Length > 0)
        {
            foreach (var field in fieldsToMove)
            {
                var index = cmd.Fields.IndexOf(field);

                if (field.Up && index > 0)
                {
                    (cmd.Fields[index - 1], cmd.Fields[index]) = (cmd.Fields[index], cmd.Fields[index - 1]);
                }

                if (field.Down && index < cmd.Fields.Count - 1)
                {
                    (cmd.Fields[index + 1], cmd.Fields[index]) = (cmd.Fields[index], cmd.Fields[index + 1]);
                }
            }

            ModelState.Clear();
            return View(cmd);
        }
        
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
            Name = result.Name,
            Fields = result.Fields.Select(x => new DataDefinitionEditCmd.FieldDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList()
        };

        return View(cmd);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DataDefinitionEditCmd cmd)
    {
        if (cmd.AddField)
        {
            cmd.Fields.Add(new DataDefinitionEditCmd.FieldDto());
            
            return View(cmd);
        }

        var fieldsToRemove = cmd.Fields.Where(f => f.Remove).ToArray();

        if (fieldsToRemove.Length > 0)
        {
            foreach (var field in fieldsToRemove)
                cmd.Fields.Remove(field);
            
            ModelState.Clear();
            return View(cmd);
        }

        var fieldsToMove = cmd.Fields.Where(f => f.Up || f.Down).ToArray();
        
        if (fieldsToMove.Length > 0)
        {
            foreach (var field in fieldsToMove)
            {
                var index = cmd.Fields.IndexOf(field);

                if (field.Up && index > 0)
                {
                    (cmd.Fields[index - 1], cmd.Fields[index]) = (cmd.Fields[index], cmd.Fields[index - 1]);
                }

                if (field.Down && index < cmd.Fields.Count - 1)
                {
                    (cmd.Fields[index + 1], cmd.Fields[index]) = (cmd.Fields[index], cmd.Fields[index + 1]);
                }
            }

            ModelState.Clear();
            return View(cmd);
        }
        
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
