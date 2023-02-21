using IoTDeviceApplication.Models;
using IoTDeviceApplication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTDeviceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly TelemetryRepository _repository;

        public TelemetryController()
        {
            _repository = new TelemetryRepository();
        }

        [HttpPost]
        public async Task<IActionResult> Post(string deviceId, Telemetry telemetryData)
        {
            try
            {
                var result = await _repository.SendTelemetryData(deviceId, telemetryData);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
