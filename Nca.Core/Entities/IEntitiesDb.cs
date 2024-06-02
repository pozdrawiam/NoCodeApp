namespace Nca.Core.Entities;

public interface IEntitiesDb
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
