using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Domain.Models
{
    public class ConfigModel
    {
        /// <summary>
        /// Ping timeout in ms
        /// </summary>
        public int Timeout { get; set; }
        public IEnumerable<HostConfigModel> Hosts { get; set; } = new List<HostConfigModel>();
    }
}
