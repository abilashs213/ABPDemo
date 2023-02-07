namespace ABP.Demo.AppointmentService;

public static class AppointmentServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "AppointmentService";
}
