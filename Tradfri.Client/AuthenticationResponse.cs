using System.Text.Json.Serialization;

namespace Tradfri.Client
{
    public class AuthenticationResponse
    {
        [JsonPropertyName(ApiCode.PRESHARED_KEY)]
        public string PreshardKey { get; set; }
    }
}
