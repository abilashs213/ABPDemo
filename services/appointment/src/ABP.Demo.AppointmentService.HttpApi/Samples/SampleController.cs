using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace ABP.Demo.AppointmentService.Samples;

[RemoteService(Name = AppointmentServiceRemoteServiceConsts.RemoteServiceName)]
[Area("AppointmentService")]
[ControllerName("AppointmentService")]
[Route("api/AppointmentService/sample")]
public class SampleController : AppointmentServiceController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }
}
