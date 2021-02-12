using System.Text.Json.Serialization;

namespace Tradfri.Client
{
    public class AuthenticationRequest
    {
        [JsonPropertyName(ApiCode.IDENTITY)]
        public string Identity { get; init; }
    }
}
