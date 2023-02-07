using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ABP.Demo.AppointmentService.EntityFrameworkCore;

[ConnectionStringName(AppointmentServiceDbProperties.ConnectionStringName)]
public class AppointmentServiceDbContext : AbpDbContext<AppointmentServiceDbContext>
{

    public AppointmentServiceDbContext(DbContextOptions<AppointmentServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAppointmentService();
    }
}
