using Nca.Domain.Features.DataDefinitions.Delete;

namespace Nca.Tests.Domain.Features.DataDefinitions;

public class DataDefinitionsDeleteCmdTests
{
    private readonly DataDefinitionsDeleteCmdHandler _handler;
    private readonly IDb _db = TestHelper.CreateInMemoryDb();

    public DataDefinitionsDeleteCmdTests()
    {
        _handler = new DataDefinitionsDeleteCmdHandler(_db);
    }
    
    [Fact]
    public async Task Should_delete_from_db()
    {
        var cmd = new DataDefinitionsDeleteCmd();

        await _handler.ExecuteAsync(cmd);

        throw new NotImplementedException();
    }
}
