using iPinger.Application.Factories.Pingers;
using iPinger.Application.Pingers;
using iPinger.Domain.Models;
using iPinger.Domain.Pingers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Factories.Pingers
{
    public class PingerFactory : IPingerFactory
    {
        public IPinger CreatePinger(PingerFactoryParams param)
        {
            PingerParams pingerParams = new PingerParams()
            {
                Timeout = param.Timeout
            };

            return param.Protocol switch
            {
                Protocol.Udp => new UdpPinger(pingerParams),
                _ => new TcpPinger(pingerParams)
            };   
        }
    }
}
