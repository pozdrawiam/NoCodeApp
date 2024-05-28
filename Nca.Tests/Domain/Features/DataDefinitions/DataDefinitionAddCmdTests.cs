using Nca.Domain.Entities;
using Nca.Domain.Features.DataDefinitions.Add;

namespace Nca.Tests.Domain.Features.DataDefinitions;

public class DataDefinitionAddCmdTests
{
    private readonly DataDefinitionAddCmdHandler _handler;
    private readonly IDb _db = TestHelper.CreateInMemoryDb();

    public DataDefinitionAddCmdTests()
    {
        _handler = new DataDefinitionAddCmdHandler(_db);
    }
    
    [Fact]
    public async Task Should_save_to_db()
    {
        var cmd = new DataDefinitionAddCmd
        {
            Name = "Products",
            Fields = new List<DataDefinitionAddCmd.FieldDto>
            {
                new() { Name = "Name" },
                new() { Name = "Description" }
            }
        };

        // Act
        await _handler.ExecuteAsync(cmd);

        var dataDefinition = _db.DataDefinitions.Single();
        
        Assert.Contains(dataDefinition.Fields, x => x.Name == cmd.Fields[0].Name);
        Assert.Contains(dataDefinition.Fields, x => x.Name == cmd.Fields[1].Name);
        Assert.Equal(2, _db.FieldDefinitions.Count());
    }
}
