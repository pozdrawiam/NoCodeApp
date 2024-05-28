namespace Nca.Domain.Entities.Definitions;

public class DataDefinition
{
    public int Id { get; set; }
    
    public string Name { get; set; } = "";

    public virtual ICollection<FieldDefinition> Fields { get; set; } = new List<FieldDefinition>();
}
