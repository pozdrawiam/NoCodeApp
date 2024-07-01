﻿using Nca.Core.Exceptions;

namespace Nca.Domain.Features.DataDefinitions.Edit;

public class DataDefinitionEditCmdHandler(IDb db) 
    : ICmdHandler<DataDefinitionEditCmd>
{
    public async Task ExecuteAsync(DataDefinitionEditCmd cmd)
    {
        var entity = await db.DataDefinitions.FindAsync(cmd.Id);

        if (entity == null)
            throw new NotFoundException();
        
        entity.Name = cmd.Name;

        await db.SaveChangesAsync();
    }
}
