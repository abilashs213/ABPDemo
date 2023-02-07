using ABP.Demo.AppointmentService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ABP.Demo.AppointmentService.Permissions;

public class AppointmentServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AppointmentServicePermissions.GroupName, L("Permission:AppointmentService"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AppointmentServiceResource>(name);
    }
}
