using Nca.Domain.Entities.Definitions;
using Nca.Domain.Features.DataDefinitions.List;

namespace Nca.Tests.Domain.Features.DataDefinitions;

public class DataDefinitionListQueryHandlerTests
{
    private readonly DataDefinitionListQueryHandler _handler;
    private readonly IDb _db = TestHelper.CreateInMemoryDb();

    public DataDefinitionListQueryHandlerTests()
    {
        _handler = new DataDefinitionListQueryHandler(_db);
    }

    [Fact]
    public async Task Should_load_list_from_db()
    {
        var dataDefinition1 = new DataDefinition
        {
            Id = 1,
            Name = "Def1",
            Fields = new List<FieldDefinition>
            {
                new() { Id = 1, Name = "A", Sequence = 0 }
            }
        };
        
        var dataDefinition2 = new DataDefinition
        {
            Id = 2,
            Name = "Def2",
            Fields = new List<FieldDefinition>
            {
                new() { Id = 2, Name = "B", Sequence = 0 },
                new() { Id = 3, Name = "C", Sequence = 1 }
            }
        };

        _db.DataDefinitions.Add(dataDefinition1);
        _db.DataDefinitions.Add(dataDefinition2);
        await _db.SaveChangesAsync();

        var query = new DataDefinitionListQuery();
        
        // Act
        var result = await _handler.ExecuteAsync(query);
        
        Assert.Equal(2, result.Entries.Count);

        var first = result.Entries.First();
        var second = result.Entries.ElementAt(1);
        
        Assert.Equal("Def1", first.Name);
        Assert.Equal("Def2", second.Name);
        Assert.Equal(1, first.FieldsCount);
        Assert.Equal(2, second.FieldsCount);
    }
}
