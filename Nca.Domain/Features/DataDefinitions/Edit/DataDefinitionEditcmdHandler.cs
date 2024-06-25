using Nca.Core.Exceptions;

namespace Nca.Domain.Features.DataDefinitions.Edit;

public class DataDefinitionEditcmdHandler(IDb db) 
    : ICmdHandler<DataDefinitionEditCmd>
{
    public async Task ExecuteAsync(DataDefinitionEditCmd cmd)
    {
        var entity = await db.DataDefinitions.FindAsync(cmd.Id);

        if (entity == null)
            throw new NotFoundException();
        
        entity.Name = cmd.Name;

        db.DataDefinitions.Add(entity);

        await db.SaveChangesAsync();
    }
}
