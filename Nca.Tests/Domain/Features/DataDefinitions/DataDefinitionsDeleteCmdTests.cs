using Nca.Domain.Entities.Definitions;
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
        var dataDefinition1 = new DataDefinition
        {
            Id = 1,
            Name = "Def1",
            Fields = new List<FieldDefinition> { new() { Id = 1 } }
        };
        var dataDefinition2 = new DataDefinition
        {
            Id = 2,
            Name = "Def2",
            Fields = new List<FieldDefinition> { new() { Id = 2 } }
        };
        var dataDefinition3 = new DataDefinition
        {
            Id = 3,
            Name = "Def3",
            Fields = new List<FieldDefinition> { new() { Id = 3 } }
        };

        _db.DataDefinitions.Add(dataDefinition1);
        _db.DataDefinitions.Add(dataDefinition2);
        _db.DataDefinitions.Add(dataDefinition3);
        await _db.SaveChangesAsync();

        var cmd = new DataDefinitionsDeleteCmd { Ids = [1, 3] };

        await _handler.ExecuteAsync(cmd);

        Assert.Equal(1, _db.DataDefinitions.Count());
        Assert.Equal(1, _db.FieldDefinitions.Count());
        Assert.Equal("Def2", _db.DataDefinitions.Single(x => x.Id == 2).Name);
    }
}
