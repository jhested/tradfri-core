using System;

namespace Tradfri.Client.Devices
{
    public class DevicePropertyAttribute : Attribute
    {
        public int Code { get; set; }
    }
}
