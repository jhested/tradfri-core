using CoAPnet;
using System;
using System.Net;
using System.Threading.Tasks;
using Tradfri.Client;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var coapClient = new CoapFactory().CreateClient())
            {                
                var gateway = new Gateway(coapClient, new GatewaySettings { GatewayIp = IPAddress.Parse("192.168.0.51"), Secret = "MR2PcuQSzcaDvVrp" });

                var credentials = await gateway.AuthenticateAsync();

                await gateway.ConnectAsync(credentials);

                await foreach(var device in gateway.GetDevices())
                {
                    Console.WriteLine(device.Name);
                    device.SetClient(coapClient);
                    await device.Observe();
                }

                Console.ReadLine();
            }
        }
    }
}