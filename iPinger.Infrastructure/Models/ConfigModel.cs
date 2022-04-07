using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Infrastructure.Models
{
    public class ConfigModel
    {
        public IEnumerable<HostConfigModel> Hosts { get; set; } = new List<HostConfigModel>();
    }
}
