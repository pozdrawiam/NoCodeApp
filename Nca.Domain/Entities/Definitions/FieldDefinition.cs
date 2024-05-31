using Nca.Domain.Entities.Values;

namespace Nca.Domain.Entities.Definitions;

public class FieldDefinition
{
    public int Id { get; set; }

    public int DataDefinitionId { get; set; }
    
    public virtual DataDefinition? DataDefinition { get; set; }

    public string Name { get; set; } = "";

    public FieldType Type { get; set; }

    public string? DefaultValue { get; set; }

    public bool IsNullable { get; set; }

    public bool ShowOnList { get; set; }

    public int Sequence { get; set; }
    
    public virtual ICollection<FieldValue> Values { get; set; } = new List<FieldValue>();
}
