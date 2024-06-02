using Nca.Domain.Entities.Values;
using Nca.Domain.Features.DataValues.Get;

namespace Nca.Tests.Domain.Features.DataValues;

public class DataValueGetQueryTests
{
    private readonly DataValueGetQueryHandler _handler;
    private readonly IDb _db = TestHelper.CreateInMemoryDb();

    public DataValueGetQueryTests()
    {
        _handler = new DataValueGetQueryHandler(_db);
    }

    [Fact]
    public async Task Should_load_from_db()
    {
        var value = new DataValue { Id = 1 };

        _db.DataValues.Add(value);
        await _db.SaveChangesAsync();
        
        var query = new DataValueGetQuery { Id = 1 };
        
        // Act
        var result = await _handler.ExecuteAsync(query);

        Assert.NotNull(result);
    }
}
