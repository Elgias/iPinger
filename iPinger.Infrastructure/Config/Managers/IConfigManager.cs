using iPinger.Infrastructure.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Infrastructure.Config.Managers
{
    public interface IConfigManager
    {
        ParsedConfig? LoadedConfig { get; }

        void LoadConfig();
    }
}
