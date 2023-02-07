using ABP.Demo.AppointmentService.Localization;
using Volo.Abp.Application.Services;

namespace ABP.Demo.AppointmentService;

public abstract class AppointmentServiceAppService : ApplicationService
{
    protected AppointmentServiceAppService()
    {
        LocalizationResource = typeof(AppointmentServiceResource);
        ObjectMapperContext = typeof(AppointmentServiceApplicationModule);
    }
}
