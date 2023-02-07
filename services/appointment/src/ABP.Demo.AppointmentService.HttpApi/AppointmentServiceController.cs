using ABP.Demo.AppointmentService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ABP.Demo.AppointmentService;

public abstract class AppointmentServiceController : AbpControllerBase
{
    protected AppointmentServiceController()
    {
        LocalizationResource = typeof(AppointmentServiceResource);
    }
}
