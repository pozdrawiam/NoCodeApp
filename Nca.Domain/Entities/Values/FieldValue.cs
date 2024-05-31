using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Entities.Values;

public class FieldValue
{
    public int Id { get; set; }

    public int DataValueId { get; set; }

    public DataValue? DataValue { get; set; }
    
    public int FieldDefinitionId { get; set; }

    public FieldDefinition? FieldDefinition { get; set; }

    public string Value { get; set; } = "";
}
