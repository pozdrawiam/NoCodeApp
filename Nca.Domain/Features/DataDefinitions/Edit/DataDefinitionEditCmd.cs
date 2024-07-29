namespace Nca.Domain.Features.DataDefinitions.Edit;

public class DataDefinitionEditCmd
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public IList<FieldDto> Fields { get; set; } = new List<FieldDto>();
    public bool AddField { get; set; }
    
    public class FieldDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool Remove { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
    }
}
