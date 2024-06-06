using Microsoft.EntityFrameworkCore;

namespace Nca.Domain.Features.DataDefinitions.List;

public class DataDefinitionListQueryHandler(IDb db) 
    : IQueryHandler<DataDefinitionListQuery, DataDefinitionListQueryResult>
{
    public async Task<DataDefinitionListQueryResult> ExecuteAsync(DataDefinitionListQuery query)
    {
        var results = await db.DataDefinitions.Select(x => new DataDefinitionListQueryResult.EntryDto
        {
            Id = x.Id,
            Name = x.Name,
            FieldsCount = x.Fields.Count
        }).ToArrayAsync();

        return new DataDefinitionListQueryResult(results);
    }
}
