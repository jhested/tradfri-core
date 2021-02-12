using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tradfri.Client
{
    public class GatewaySettings
    {
        public IPAddress GatewayIp { get; init; }
        public string Secret { get; init; }
    }
}
