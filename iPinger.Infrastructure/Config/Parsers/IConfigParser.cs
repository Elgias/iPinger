using iPinger.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Infrastructure.Config.Parsers
{
    public interface IConfigParser
    {
        ParsedConfig Parse(string content);
    }
}
