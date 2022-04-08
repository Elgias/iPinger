using iPinger.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Application.Managers
{
    public interface IConfigManager
    {
        ParsedConfig? LoadedConfig { get; }

        void LoadConfig();
    }
}
