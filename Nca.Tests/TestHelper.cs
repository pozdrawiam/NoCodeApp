﻿using Microsoft.EntityFrameworkCore;

namespace Nca.Tests;

public static class TestHelper
{
    public static IDb CreateInMemoryDb()
    {
        var options = new DbContextOptionsBuilder<Db>()
            .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid())
            .Options;
        
        return new Db(options);
    }
}
