using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradfri.Client
{
    public class ApiEndPoint : StringStatic
    {
        public static ApiEndPoint Authentication = new ApiEndPoint("15011/9063");
        public static ApiEndPoint GatewayReboot = new ApiEndPoint("15011/9030");
        public static ApiEndPoint GatewayReset = new ApiEndPoint("15011/9031");
        public static ApiEndPoint UpdateFirmware = new ApiEndPoint("15011/9034");
        public static ApiEndPoint GatewayDetails = new ApiEndPoint("15011/15012");
        public static ApiEndPoint Devices = new ApiEndPoint("15001");
        public static ApiEndPoint Groups = new ApiEndPoint("15004");
        public static ApiEndPoint Scenes = new ApiEndPoint("15005");
        public static ApiEndPoint Notifications = new ApiEndPoint("15006");
        public static ApiEndPoint SmartTasks = new ApiEndPoint("15010");

        protected ApiEndPoint(string endpoint) : base(endpoint)
        {            
        }
    }
}
