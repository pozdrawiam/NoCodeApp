namespace Nca.Domain.Features.DataValues.Get;

public class DataValueGetQueryHandler(IDb db) 
    : IQueryHandler<DataValueGetQuery, DataValueGetQueryResult?>
{
    public async Task<DataValueGetQueryResult?> ExecuteAsync(DataValueGetQuery query)
    {
        var entity = await db.DataValues.FindAsync(query.Id);

        if (entity == null)
            return null;

        return new DataValueGetQueryResult(new Dictionary<string, string?>()); //todo fields
    }
}
