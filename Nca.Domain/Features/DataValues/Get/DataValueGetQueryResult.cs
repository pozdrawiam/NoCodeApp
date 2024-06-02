namespace Nca.Domain.Features.DataValues.Get;

public class DataValueGetQueryResult(Dictionary<string, string?> values)
{
    public Dictionary<string, string?> Values { get; init; } = values;
}
