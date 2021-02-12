using CoAPnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradfri.Client.Devices
{
    public class LightBulb : Device
    {
        public byte Brightness { get; set; }
        
    }
}
