using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService.EntityFrameworkCore;

[DependsOn(
    typeof(AppointmentServiceTestBaseModule),
    typeof(AppointmentServiceEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
)]
public class AppointmentServiceEntityFrameworkCoreTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var sqliteConnection = CreateDatabaseAndGetConnection();

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<AppointmentServiceDbContext>(c =>
            {
                c.DbContextOptions.UseSqlite(sqliteConnection);
            });
        });
    }

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        new AppointmentServiceDbContext(
            new DbContextOptionsBuilder<AppointmentServiceDbContext>().UseSqlite(connection).Options
        ).GetService<IRelationalDatabaseCreator>().CreateTables();

        return connection;
    }
}
