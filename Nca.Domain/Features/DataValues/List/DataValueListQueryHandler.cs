namespace Nca.Domain.Features.DataValues.List;

public class DataValueListQueryHandler(IDb db)
    : IQueryHandler<DataValueListQuery, DataValueListQueryResult>
{
    public Task<DataValueListQueryResult> ExecuteAsync(DataValueListQuery query)
    {
        throw new NotImplementedException();
    }
}
