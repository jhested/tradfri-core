using CoAPnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Tradfri.Client.Devices
{
    public class Device : ICoapResponseHandler
    {
        [JsonPropertyName(ApiCode.NAME)]
        public string Name { get; init; }

        [JsonPropertyName(ApiCode.INSTANCE_ID)]
        public int InstanceId { get; set; }

        private ICoapClient _coapClient;        

        public async Task Observe(CancellationToken cancellationToken = default)
        {
            var observeOptions = new CoapObserveOptionsBuilder()
                .WithPath($"{ApiEndPoint.Devices}/{InstanceId}")
                .WithResponseHandler(this)
                .Build();

            await _coapClient.ObserveAsync(observeOptions, cancellationToken);
        }

        public Task HandleResponseAsync(HandleResponseContext context)
        {
            Console.WriteLine(Encoding.UTF8.GetString(context.Response.Payload));
            return Task.FromResult(0);
        }

        public void SetClient(ICoapClient coapClient)
        {
            _coapClient = coapClient;
        }
    }
}
