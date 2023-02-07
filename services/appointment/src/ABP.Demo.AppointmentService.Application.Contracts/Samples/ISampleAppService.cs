using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ABP.Demo.AppointmentService.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
