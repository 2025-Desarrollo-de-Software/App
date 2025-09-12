using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TripGo.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class TripGoDbContextFactory : IDesignTimeDbContextFactory<TripGoDbContext>
{
    public TripGoDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        TripGoEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<TripGoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new TripGoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TripGo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
