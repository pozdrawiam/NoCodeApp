﻿using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Features.DataDefinitions.Delete;

public class DataDefinitionsDeleteCmdHandler(IDb db)
    : CmdHandler<DataDefinitionsDeleteCmd>
{
    protected override async Task Execute(DataDefinitionsDeleteCmd cmd)
    {
        int[] ids = cmd.Ids.Distinct().ToArray();
        DataDefinition[] definitions = await db.DataDefinitions.Where(x => ids.Contains(x.Id)).ToArrayAsync();

        db.DataDefinitions.RemoveRange(definitions);

        await db.SaveChangesAsync();
    }
}
