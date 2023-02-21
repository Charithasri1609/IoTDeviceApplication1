using IoTDeviceApplication.Models;
using IoTDeviceApplication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Devices;

namespace IoTDeviceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private static DeviceRepository deviceRepository;

        public DeviceController()
        {
            deviceRepository = new DeviceRepository();
        }

        // CREATE
        [HttpPost]
        [Route("Create")]
        public async Task<string> AddDeviceAsync(Devices iotDevice)
        {
            return await deviceRepository.AddDeviceAsync(iotDevice);
        }



        // READ
        [HttpGet]
        [Route("Retrieve/{deviceId}")]
        public async Task<Device> GetDeviceAsync(string deviceId)
        {
            return await deviceRepository.GetDeviceAsync(deviceId);
        }

        // UPDATE

        [HttpPut("Update/{deviceId}/{status}")]
        public async Task UpdateDeviceStatusAsync(string deviceId, string status)
        {
            await deviceRepository.UpdateDeviceStatusAsync(deviceId, status);
        }

        // DELETE
        [HttpDelete]
        [Route("Delete/{deviceId}")]
        public async Task DeleteDeviceAsync(string deviceId)
        {
            await deviceRepository.DeleteDeviceAsync(deviceId);
        }
    }
}
