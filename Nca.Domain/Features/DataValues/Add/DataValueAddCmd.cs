namespace Nca.Domain.Features.DataValues.Add;

public class DataValueAddCmd
{
    public int DataDefinitionId { get; set; }
    public IList<FieldValueAddDto> Fields { get; set; } = new List<FieldValueAddDto>();
    
    public class FieldValueAddDto
    {
        public int FieldDefinitionId { get; set; }
        public string Value { get; set; } = "";
    }
}
