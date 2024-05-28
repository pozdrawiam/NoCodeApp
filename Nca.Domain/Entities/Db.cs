using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Entities;

public class Db(DbContextOptions<Db> options) 
    : DbContext(options), IDb
{
    public DbSet<DataDefinition> DataDefinitions { get; set; }
}
