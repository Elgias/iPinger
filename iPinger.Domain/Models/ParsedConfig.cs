using iPinger.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Domain.Models
{
    public class ParsedConfig
    {
        public int Timeout { get; set; }
        public IEnumerable<HostModel> Hosts { get; set; }

        public ParsedConfig()
        {
            Hosts = new List<HostModel>();
        }
    }
}
