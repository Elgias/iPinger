using iPinger.Application.Managers;
using iPinger.Domain.Models;
using iPinger.Infrastructure.Config.Providers;

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
