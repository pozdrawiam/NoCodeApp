using Nca.Domain.Entities;
using Nca.Domain.Features.DataValues.Add;

namespace Nca.Tests.Domain.Features.DataValues;

public class DataValueAddCmdTests
{
    private readonly DataValueAddCmdHandler _handler;
    private readonly IDb _db = TestHelper.CreateInMemoryDb();

    public DataValueAddCmdTests()
    {
        _handler = new DataValueAddCmdHandler(_db);
    }
    
    [Fact]
    public async Task Should_save_to_db()
    {
        var cmd = new DataValueAddCmd
        {
            DataDefinitionId = 1,
            Fields = new List<DataValueAddCmd.FieldValueAddDto>
            {
                new() { FieldDefinitionId = 1, Value = "a" },
                new() { FieldDefinitionId = 2, Value = "b" }
            }
        };

        // Act
        await _handler.ExecuteAsync(cmd);

        var dataValue = _db.DataValues.Single();
        
        Assert.Contains(dataValue.Fields, x => x.Value == cmd.Fields[0].Value);
        Assert.Contains(dataValue.Fields, x => x.Value == cmd.Fields[1].Value);
        Assert.Equal(2, _db.FieldValues.Count());
    }
}
