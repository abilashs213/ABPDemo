using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ABP.Demo.AppointmentService.EntityFrameworkCore;

public static class AppointmentServiceDbContextModelCreatingExtensions
{
    public static void ConfigureAppointmentService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(AppointmentServiceConsts.DbTablePrefix + "YourEntities", AppointmentServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
