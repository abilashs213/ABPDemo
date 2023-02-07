using System.IO;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp;

namespace ABP.Demo.AppointmentService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 *
 * It is also used in the DbMigrator application.
 * */
public class AppointmentServiceDbContextFactory : IDesignTimeDbContextFactory<AppointmentServiceDbContext>
{
    private readonly string _connectionString;

    /* This constructor is used when you use EF Core tooling (e.g. Update-Database) */
    public AppointmentServiceDbContextFactory()
    {
        _connectionString = GetConnectionStringFromConfiguration();
    }

    /* This constructor is used by DbMigrator application */
    public AppointmentServiceDbContextFactory([NotNull] string connectionString)
    {
        Check.NotNullOrWhiteSpace(connectionString, nameof(connectionString));
        _connectionString = connectionString;
    }

    public AppointmentServiceDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppointmentServiceDbContext>()
            .UseSqlServer(_connectionString, b =>
            {
                b.MigrationsHistoryTable("__AppointmentService_Migrations");
            });

        return new AppointmentServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration()
            .GetConnectionString(AppointmentServiceDbProperties.ConnectionStringName);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    $"..{Path.DirectorySeparatorChar}ABP.Demo.AppointmentService.HttpApi.Host"
                )
            )
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
