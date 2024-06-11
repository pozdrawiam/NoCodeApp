using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;
using Nca.Domain.Entities.Values;

namespace Nca.Domain.Features.DataValues.List;

public class DataValueListQueryHandler(IDb db)
    : IQueryHandler<DataValueListQuery, DataValueListQueryResult>
{
    public async Task<DataValueListQueryResult> ExecuteAsync(DataValueListQuery query)
    {
        DataDefinition? definition = await db.DataDefinitions.FindAsync(query.DataDefinitionId);

        if (definition == null)
            return new DataValueListQueryResult();

        FieldValue[] fieldValues = await db.DataValues
            .Where(x => x.DataDefinitionId == definition.Id)
            .SelectMany(x => x.Fields)
            .ToArrayAsync();

        List<List<string>> rows = fieldValues.GroupBy(x => x.DataValueId)
            .Select(valuesGroup => definition.Fields
                .OrderBy(x => x.Sequence)
                .Select(x => x.Id)
                .Select(fieldDefId => valuesGroup.FirstOrDefault(x => x.FieldDefinitionId == fieldDefId)?.Value ?? "")
                .ToList())
            .ToList();

        return new DataValueListQueryResult { Values = rows };
    }
}
