using CoAPnet.Client;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Tradfri.Client
{
    public static class Extensions
    {
        public static async Task<T> RequestAsync<T>(this ICoapClient client, CoapRequest request, CancellationToken cancellationToken)
        {
            var response = await client.RequestAsync(request, cancellationToken);
            var message = Encoding.UTF8.GetString(response.Payload);
            return JsonSerializer.Deserialize<T>(message);
        }
    }
}
