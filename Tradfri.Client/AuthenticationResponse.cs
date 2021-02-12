using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tradfri.Client
{
    public class AuthenticationResponse
    {
        [JsonPropertyName(ApiCode.PRESHARED_KEY)]
        public string PreshardKey { get; set; }
    }
}
