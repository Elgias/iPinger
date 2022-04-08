using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Domain.Models
{
    public class HostConfigModel
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Protocol { get; set; }
    }
}
