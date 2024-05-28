using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Entities;

public interface IDb
{
    DbSet<DataDefinition> DataDefinitions { get; }
    DbSet<FieldDefinition> FieldDefinitions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
