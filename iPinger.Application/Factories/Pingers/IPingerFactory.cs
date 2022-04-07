using iPinger.Domain.Models;
using iPinger.Domain.Pingers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Application.Factories.Pingers
{
    public interface IPingerFactory
    {
        public IPinger CreatePingerByProtocol(Protocol protocol);
    }
}
