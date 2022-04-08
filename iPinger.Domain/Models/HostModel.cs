using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Domain.Models
{
    public class HostModel
    {
        public int InnerId { get; set; }
        /// <summary>
        /// Ip or hostname
        /// </summary>
        public string Host { get; set; }

        public int Port { get; set; }

        public Protocol Protocol { get; set; }
    }
}
