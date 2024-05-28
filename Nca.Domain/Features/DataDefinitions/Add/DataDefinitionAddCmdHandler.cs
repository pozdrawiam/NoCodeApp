using Nca.Domain.Entities;
using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Features.DataDefinitions.Add;

public class DataDefinitionAddCmdHandler(IDb _db)
{
    public async Task ExecuteAsync(DataDefinitionAddCmd cmd)
    {
        var entity = new DataDefinition
        {
            Name = cmd.Name
        };

        _db.DataDefinitions.Add(entity);

        await _db.SaveChangesAsync();
    }
}
