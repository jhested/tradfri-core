using System.Net;

namespace Tradfri.Client
{
    public class GatewaySettings
    {
        public IPAddress GatewayIp { get; init; }
        public string Secret { get; init; }
    }
}
