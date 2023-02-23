using IoTDeviceApplication.Models;
using Microsoft.Azure.Devices;

namespace IoTDeviceApplication.Repositories
{
    public class DeviceRepository
    {
        private static string connectionString = "HostName=charithahub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=E5If7vSxknMCwgNyGlGS2jPScVQIMBw3v8FB5jXHTKM=";
        private static RegistryManager registryManager;

        public DeviceRepository()
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
        }

        // CREATE
        public async Task<string> AddDeviceAsync(Devices iotDevice)
        {
            var device = new Device(iotDevice.DeviceId);
            Device createdDevice = await registryManager.AddDeviceAsync(device);
            return createdDevice.Authentication.SymmetricKey.PrimaryKey;
        }


        // READ
        public async Task<Device> GetDeviceAsync(string deviceId)
        {
            Device device = await registryManager.GetDeviceAsync(deviceId);
            return device;
        }

        // UPDATE
        public async Task UpdateDeviceStatusAsync(string deviceId, string status)
        {
            Device device = await registryManager.GetDeviceAsync(deviceId);
            device.Status = (DeviceStatus)Enum.Parse(typeof(DeviceStatus), status, true);
            await registryManager.UpdateDeviceAsync(device);
        }

        // DELETE
        public async Task DeleteDeviceAsync(string deviceId)
        {
            await registryManager.RemoveDeviceAsync(deviceId);
        }
    }
}
