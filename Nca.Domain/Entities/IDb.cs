using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Entities;

public interface IDb
{
    DbSet<DataDefinition> DataDefinitions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
