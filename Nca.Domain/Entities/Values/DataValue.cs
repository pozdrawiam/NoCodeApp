using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Entities.Values;

public class DataValue
{
    public int Id { get; set; }
    
    public int DataDefinitionId { get; set; }
    
    public virtual DataDefinition? DataDefinition { get; set; }
    
    public virtual ICollection<FieldValue> Fields { get; set; } = new List<FieldValue>();
}
