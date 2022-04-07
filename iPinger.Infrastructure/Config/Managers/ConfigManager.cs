using iPinger.Infrastructure.Config.Parsers;
using iPinger.Infrastructure.Config.Providers;
using iPinger.Infrastructure.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Infrastructure.Config.Managers
{
    public class ConfigManager : IConfigManager
    {
        private readonly IConfigProvider _configProvider;

        private ParsedConfig? _loadedConfig;

        public ConfigManager(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public ParsedConfig? LoadedConfig
        {
            get => _loadedConfig;
        }

        public void LoadConfig()
        {
            _loadedConfig = _configProvider.ProvideConfig();
        }
    }
}
