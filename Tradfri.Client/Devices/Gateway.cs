using CoAPnet.Client;
using CoAPnet.Extensions.DTLS;
using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Tradfri.Client.Devices;

namespace Tradfri.Client
{
    public class Gateway
    {
        private readonly ICoapClient _coapClient;
        private readonly GatewaySettings _settings;
        
        private bool _connected = false;

        public Gateway(ICoapClient coapClient, GatewaySettings settings)
        {
            _coapClient = coapClient ?? throw new ArgumentNullException(nameof(coapClient));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public Task<Credentials> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            Guard.Argument(_settings.Secret, nameof(_settings.Secret)).NotNull().NotEmpty();

            return AuthenticateAsyncInternal(_settings.Secret, cancellationToken);
        }

        public async Task<Credentials> AuthenticateAsyncInternal(string secret, CancellationToken cancellationToken = default)
        {
            await ConnectAsync(new Credentials { Identity = "Client_identity", PresharedKey = _settings.Secret }, cancellationToken);

            var identity = RandomString(16);
            var payload = new AuthenticationRequest { Identity = identity };
            var request = new CoapRequestBuilder()
                    .WithMethod(CoapRequestMethod.Post)
                    .WithPath(ApiEndPoint.Authentication)
                    .WithPayload(JsonSerializer.Serialize(payload))                    
                    .Build();

            var authResponse = await _coapClient.RequestAsync<AuthenticationResponse>(request, cancellationToken);
            return new Credentials { Identity = identity, PresharedKey = authResponse.PreshardKey };
        }

        public async Task ConnectAsync(Credentials credentials, CancellationToken cancellationToken = default)
        {
            var options = new CoapClientConnectOptionsBuilder()
                    .WithHost(_settings.GatewayIp.ToString())
                    .WithPort(5684)
                    .WithDtlsTransportLayer(o =>
                    {
                        o.WithPreSharedKey(credentials.Identity, credentials.PresharedKey);
                    })
                    .Build();

            await _coapClient.ConnectAsync(options, cancellationToken);
            _connected = true;
        }

        public Task<int[]> GetDeviceIds(CancellationToken cancellationToken = default)
        {
            if(!_connected)
            {
                throw new InvalidOperationException("Please connect to Gateway");
            }

            var request = new CoapRequestBuilder()
                .WithMethod(CoapRequestMethod.Get)
                .WithPath(ApiEndPoint.Devices)                
                .Build();

            return _coapClient.RequestAsync<int[]>(request, cancellationToken);            
        }

        public async IAsyncEnumerable<Device> GetDevices([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (!_connected)
            {
                throw new InvalidOperationException("Please connect to Gateway");
            }

            var deviceIds = await GetDeviceIds(cancellationToken);

            foreach(var device in deviceIds)
            {
                yield return await GetDevice(device);
            }
        }

        public Task<Device> GetDevice(int id, CancellationToken cancellationToken = default)
        {
            if (!_connected)
            {
                throw new InvalidOperationException("Please connect to Gateway");
            }

            var request = new CoapRequestBuilder()
                .WithMethod(CoapRequestMethod.Get)
                .WithPath($"{ApiEndPoint.Devices}/{id}")
                .Build();

            return _coapClient.RequestAsync<Device>(request, cancellationToken);
        }

        private static string RandomString(int length)
        {
            var s = "abcdefghijklmnopqrstuvwxyz";
            Random ran = new Random();
            var res = string.Empty;
            for(var i = 0; i < length; i++)
            {
                res += s[ran.Next(0, s.Length - 1)];
            }
            return res;
        }
    }
}
