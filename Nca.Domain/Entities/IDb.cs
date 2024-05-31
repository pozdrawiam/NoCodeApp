using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;
using Nca.Domain.Entities.Values;

namespace Nca.Domain.Entities;

public interface IDb
{
    DbSet<DataDefinition> DataDefinitions { get; }
    DbSet<FieldDefinition> FieldDefinitions { get; }
    
    DbSet<DataValue> DataValues { get; }
    DbSet<FieldValue> FieldValues { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
