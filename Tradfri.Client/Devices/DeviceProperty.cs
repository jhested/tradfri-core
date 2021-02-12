using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradfri.Client.Devices
{
    public class DevicePropertyAttribute : Attribute
    {
        public int Code { get; set; }
    }
}
