namespace Nca.Domain.Features.DataDefinitions.List;

public class DataDefinitionListQueryResult(IReadOnlyCollection<DataDefinitionListQueryResult.EntryDto> entries)
{
    public IReadOnlyCollection<EntryDto> Entries { get; set; } = entries;

    public class EntryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int FieldsCount { get; set; }
    }
}
