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
        public IPinger CreatePingerByProtocol(Protocol protocol) => protocol switch
        {
            Protocol.Tcp => new TcpPinger(),
            Protocol.Udp => new UdpPinger(),
            _ => new TcpPinger()
        };
    }
}
