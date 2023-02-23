using IoTDeviceApplication.Models;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices;
using System.Text;

namespace IoTDeviceApplication.Repositories
{
    public class TelemetryRepository
    {
        private static string connectionString = "HostName=charithahub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=E5If7vSxknMCwgNyGlGS2jPScVQIMBw3v8FB5jXHTKM=";

        public static async Task<bool> IsDeviceAvailable(string deviceId)
        {
            var registrymanager = RegistryManager.CreateFromConnectionString(connectionString);
            Device device = await registrymanager.GetDeviceAsync(deviceId);
            if (device.Status == DeviceStatus.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<string> SendTelemetryData(string deviceId, Telemetry telemetryData)
        {
            if (await IsDeviceAvailable(deviceId))
            {
                try
                {
                    var deviceClient = DeviceClient.CreateFromConnectionString(connectionString, deviceId, Microsoft.Azure.Devices.Client.TransportType.Mqtt);
                    var message = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(telemetryData.TelemetryData));
                    message.Properties.Add("deviceId", deviceId);
                    await deviceClient.SendEventAsync(message);
                    Console.WriteLine(telemetryData.TelemetryData);
                    return "Telemetry data sent successfully";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending telemetry data: {0}", ex.Message);
                }
            }
            return "Device is disabled";
        }
    }
}
