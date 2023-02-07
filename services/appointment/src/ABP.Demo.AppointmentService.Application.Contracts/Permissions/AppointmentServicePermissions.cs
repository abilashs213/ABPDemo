using Volo.Abp.Reflection;

namespace ABP.Demo.AppointmentService.Permissions;

public class AppointmentServicePermissions
{
    public const string GroupName = "AppointmentService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AppointmentServicePermissions));
    }
}
