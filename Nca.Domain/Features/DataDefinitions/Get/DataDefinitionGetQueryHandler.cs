using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Features.DataDefinitions.Get;

public class DataDefinitionGetQueryHandler(IDb db) 
    : IQueryHandler<DataDefinitionGetQuery, DataDefinitionGetQueryResult?>
{
    public async Task<DataDefinitionGetQueryResult?> ExecuteAsync(DataDefinitionGetQuery query)
    {
        DataDefinition? entity = await db.DataDefinitions.FindAsync(query.Id);

        if (entity == null)
            return null;

        return new DataDefinitionGetQueryResult
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
