using IoTDeviceApplication.Models;
using IoTDeviceApplication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTDeviceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePropertiesController : ControllerBase
    {
        private readonly UpdatePropertiesRepository repository;

        public UpdatePropertiesController(UpdatePropertiesRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("reported")]
        public async Task<IActionResult> UpdateReportedProperties([FromBody] UpdateProperties model, string deviceId)
        {
            var twin = await repository.UpdateReportedPropertiesAsync(model, deviceId);
            return Ok(twin);
        }

        [HttpPost("desired")]
        public async Task<IActionResult> UpdateDesiredProperties([FromBody] UpdateProperties model, string deviceId)
        {
            var twin = await repository.UpdateDesiredPropertiesAsync(model, deviceId);
            return Ok(twin);
        }
    }
}
