using Nca.Core.Cqs;

namespace Nca.Domain.Features.DataValues.Get;

public class DataValueGetQueryHandler(IDb db) : IQuery<DataValueGetQuery, DataValueGetQueryResult>
{
    public Task<DataValueGetQueryResult> ExecuteAsync(DataValueGetQuery query)
    {
        throw new NotImplementedException();
    }
}
