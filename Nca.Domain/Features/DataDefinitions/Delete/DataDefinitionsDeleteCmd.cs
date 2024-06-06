namespace Nca.Domain.Features.DataDefinitions.Delete;

public class DataDefinitionsDeleteCmd
{
    public IReadOnlyCollection<int> Ids { get; set; } = Array.Empty<int>();
}
