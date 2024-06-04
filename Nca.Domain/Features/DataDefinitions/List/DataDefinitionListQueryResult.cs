namespace Nca.Domain.Features.DataDefinitions.List;

public class DataDefinitionListQueryResult(DataDefinitionListQueryResult.EntryDto[] entries)
{
    public EntryDto[] Entries { get; set; } = entries;

    public class EntryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int FieldsCount { get; set; }
    }
}
