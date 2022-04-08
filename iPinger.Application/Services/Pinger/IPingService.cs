using iPinger.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Application.Services.Pinger
{
    public interface IPingService
    {
        Task<PingResult> PingHostAsync(HostModel hostModel, int timeout);

        Task<IEnumerable<PingResult>> PingHostGroupAsync(IEnumerable<HostModel> hosts, int timeout);
    }
}
