using iPinger.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Infrastructure.Models
{
    public class ParsedConfig
    {
        public IEnumerable<HostModel> Hosts { get; set; }

        public ParsedConfig()
        {
            Hosts = new List<HostModel>();
        }
    }
}
