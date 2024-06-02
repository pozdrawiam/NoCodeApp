using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Features.DataDefinitions.Add;

public class DataDefinitionAddCmdHandler(IDb db)
{
    public async Task ExecuteAsync(DataDefinitionAddCmd cmd)
    {
        var entity = new DataDefinition
        {
            Name = cmd.Name,
            Fields = cmd.Fields.Select(f => new FieldDefinition
            {
                Name = f.Name
            }).ToList()
        };

        db.DataDefinitions.Add(entity);

        await db.SaveChangesAsync();
    }
}
