namespace Nca.Domain.Features.DataDefinitions.List;

public class DataDefinitionListQueryHandler(IDb db) 
    : IQueryHandler<DataDefinitionListQuery, DataDefinitionListQueryResult>
{
    public Task<DataDefinitionListQueryResult> ExecuteAsync(DataDefinitionListQuery query)
    {
        throw new NotImplementedException();
    }
}
