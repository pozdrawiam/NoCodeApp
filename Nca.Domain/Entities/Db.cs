using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities.Definitions;
using Nca.Domain.Entities.Values;

namespace Nca.Domain.Entities;

public class Db(DbContextOptions<Db> options) 
    : DbContext(options), IDb
{
    public DbSet<DataDefinition> DataDefinitions { get; set; }
    public DbSet<FieldDefinition> FieldDefinitions { get; set; }
    
    public DbSet<DataValue> DataValues { get; set; }
    public DbSet<FieldValue> FieldValues { get; set; }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        
        mb.Entity<FieldDefinition>().HasOne(x => x.DataDefinition)
            .WithMany(x => x.Fields)
            .HasForeignKey(x => x.DataDefinitionId);
        
        mb.Entity<FieldValue>().HasOne(x => x.DataValue)
            .WithMany(x => x.Fields)
            .HasForeignKey(x => x.DataValueId);
        
        mb.Entity<FieldValue>().HasOne(x => x.FieldDefinition)
            .WithMany(x => x.Values)
            .HasForeignKey(x => x.DataValueId);
    }
}
