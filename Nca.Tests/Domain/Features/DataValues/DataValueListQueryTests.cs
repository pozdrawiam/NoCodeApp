using Nca.Domain.Entities.Definitions;
using Nca.Domain.Entities.Values;
using Nca.Domain.Features.DataValues.List;

namespace Nca.Tests.Domain.Features.DataValues;

public class DataValueListQueryTests
{
    private readonly DataValueListQueryHandler _handler;
    private readonly IDb _db = TestHelper.CreateInMemoryDb();
    
    public DataValueListQueryTests()
    {
        _handler = new DataValueListQueryHandler(_db);
    }

    [Fact]
    public async Task Should_load_list_from_db()
    {
        var dataDefinition = new DataDefinition
        {
            Id = 1,
            Name = "Def1",
            Fields = new List<FieldDefinition>
            {
                new() { Id = 1, Name = "A", Sequence = 0 },
                new() { Id = 2, Name = "B", Sequence = 1 },
            }
        };
        
        var value = new DataValue
        {
            Id = 1, 
            DataDefinitionId = 1,
            Fields = new List<FieldValue>
            {
                new() { FieldDefinitionId = 1, Value = "test1" },
                new() { FieldDefinitionId = 2, Value = "test2" }
            }
        };
        
        _db.DataDefinitions.Add(dataDefinition);
        _db.DataValues.Add(value);
        await _db.SaveChangesAsync();
        
        var query = new DataValueListQuery { DataDefinitionId = 1 };
        
        // Act
        var result = await _handler.ExecuteAsync(query);
        
        Assert.Equal(2, result.Values.Single().Count);
    }
}
