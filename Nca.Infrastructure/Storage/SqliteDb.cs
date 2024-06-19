using Microsoft.EntityFrameworkCore;
using Nca.Domain.Entities;

namespace Nca.Infrastructure.Storage;

public class SqliteDb(string connectionString) 
    : Db(GetSqliteDbOptions(connectionString))
{
    private static DbContextOptions<Db> GetSqliteDbOptions(string connectionString)
    {
        return new DbContextOptionsBuilder<Db>()
            .UseSqlite(connectionString)
            .Options;
    }
}
