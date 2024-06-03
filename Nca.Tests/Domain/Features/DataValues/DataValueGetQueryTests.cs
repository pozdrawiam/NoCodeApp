using Nca.Domain.Entities.Definitions;
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
        var dataDefinition = new DataDefinition
        {
            Id = 1,
            Fields = new List<FieldDefinition>
            {
                new() { Id = 1, Name = "A", Sequence = 0 },
                new() { Id = 2, Name = "B", Sequence = 1 }
            }
        };

        _db.DataDefinitions.Add(dataDefinition);
        await _db.SaveChangesAsync();
        
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

        _db.DataValues.Add(value);
        await _db.SaveChangesAsync();
        
        var query = new DataValueGetQuery { Id = 1 };
        
        // Act
        var result = await _handler.ExecuteAsync(query);

        Assert.NotNull(result);
        Assert.Equal(2, result.Values.Count);
        Assert.Equal("test1", result.Values["A"]);
        Assert.Equal("test2", result.Values["B"]);
    }
}
