using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Entities;

public class Db(DbContextOptions<Db> options) 
    : DbContext(options), IDb
{
    public DbSet<DataDefinition> DataDefinitions { get; set; }
    public DbSet<FieldDefinition> FieldDefinitions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        
        mb.Entity<FieldDefinition>().HasOne(x => x.DataDefinition)
            .WithMany(x => x.Fields)
            .HasForeignKey(x => x.DataDefinitionId);
    }
}
