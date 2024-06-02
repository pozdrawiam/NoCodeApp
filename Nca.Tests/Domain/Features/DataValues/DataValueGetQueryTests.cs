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
        throw new NotSupportedException();
    }
}
