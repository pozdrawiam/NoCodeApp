namespace Nca.Domain.Features.DataDefinitions.Get;

public class DataDefinitionGetQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public IList<FieldDto> Fields { get; set; } = new List<FieldDto>();
    
    public class FieldDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
