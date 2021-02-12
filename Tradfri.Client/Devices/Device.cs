using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tradfri.Client.Devices
{
    public class Device
    {
        [JsonPropertyName(ApiCode.NAME)]
        public string Name { get; init; }
    }
}
