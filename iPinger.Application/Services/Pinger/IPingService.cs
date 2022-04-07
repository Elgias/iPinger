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
        Task<PingResult> PingHostAsync(HostModel hostModel);

        Task<IEnumerable<PingResult>> PingHostGroupAsync(IEnumerable<HostModel> hosts);
    }
}
