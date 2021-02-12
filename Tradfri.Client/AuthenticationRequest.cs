using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tradfri.Client
{
    public class AuthenticationRequest
    {
        [JsonPropertyName(ApiCode.IDENTITY)]
        public string Identity { get; init; }
    }
}
