namespace Nca.Domain.Features.DataValues.List;

public class DataValueListQueryResult
{
    public IReadOnlyCollection<IReadOnlyCollection<string>> Values { get; set; } = ArraySegment<IReadOnlyCollection<string>>.Empty;
}
