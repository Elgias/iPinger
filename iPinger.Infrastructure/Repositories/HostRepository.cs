using iPinger.Application.Repositories;
using iPinger.Domain.Models;
using iPinger.Infrastructure.Config.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Infrastructure.Repositories
{
    public class HostRepository : IHostRepository
    {
        private readonly IConfigManager _configManager;

        public HostRepository(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public IEnumerable<HostModel> GetHosts()
        {
            if (_configManager.LoadedConfig is null)
                _configManager.LoadConfig();

            return _configManager.LoadedConfig.Hosts;
        }
    }
}
