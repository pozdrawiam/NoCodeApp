using Microsoft.EntityFrameworkCore;
using Nca.Core.Exceptions;
using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Features.DataDefinitions.Edit;

public class DataDefinitionEditCmdHandler(IDb db) 
    : ICmdHandler<DataDefinitionEditCmd>
{
    public async Task ExecuteAsync(DataDefinitionEditCmd cmd)
    {
        var entity = await db.DataDefinitions
            .Include(x => x.Fields)
            .FirstOrDefaultAsync(x => x.Id == cmd.Id);

        if (entity == null)
            throw new NotFoundException();
        
        entity.Name = cmd.Name;
        
        UpdateFields(cmd, entity);

        await db.SaveChangesAsync();
    }

    private static void UpdateFields(DataDefinitionEditCmd cmd, DataDefinition entity)
    {
        var fieldsToRemove = entity.Fields
            .Where(f => cmd.Fields.All(cf => cf.Id != f.Id))
            .ToList();
        
        foreach (var field in fieldsToRemove)
        {
            entity.Fields.Remove(field);
        }
        
        foreach (var cmdField in cmd.Fields)
        {
            var existingField = entity.Fields.FirstOrDefault(f => f.Id == cmdField.Id);

            if (existingField != null)
            {
                existingField.Name = cmdField.Name;
            }
            else
            {
                var newField = new FieldDefinition
                {
                    Id = cmdField.Id,
                    Name = cmdField.Name
                };
                entity.Fields.Add(newField);
            }
        }
    }
}
