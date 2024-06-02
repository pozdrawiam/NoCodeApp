using Nca.Core.Entities;

namespace Nca.Domain.Entities.Definitions;

public class DataDefinition : BaseEntity
{
    public string Name { get; set; } = "";

    public virtual ICollection<FieldDefinition> Fields { get; set; } = new List<FieldDefinition>();
}
