using iPinger.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Application.Factories.Pingers
{
    public class PingerFactoryParams
    {
        public int Timeout { get; set; }

        public Protocol Protocol { get; set; }
    }
}
