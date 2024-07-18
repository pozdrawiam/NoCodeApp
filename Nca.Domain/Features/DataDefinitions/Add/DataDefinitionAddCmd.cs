namespace Nca.Domain.Features.DataDefinitions.Add;

public class DataDefinitionAddCmd
{
    public string Name { get; set; } = "";
    public IList<FieldDto> Fields { get; set; } = new List<FieldDto>();
    public bool AddField { get; set; }
    
    public class FieldDto
    {
        public string Name { get; set; } = "";
        public bool Remove { get; set; }
    }
}
