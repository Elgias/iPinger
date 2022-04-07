
using iPinger.Application.Factories.Pingers;
using iPinger.Application.Services.Pinger;
using iPinger.Domain.Models;
using iPinger.Domain.Pingers;
using iPinger.Factories.Pingers;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Application.Services
{
    public class PingService : IPingService
    {
        private readonly IPingerFactory _pingerFactory;

        public PingService(IPingerFactory pingerFactory)
        {
            _pingerFactory = pingerFactory;
        }

        public async Task<PingResult> PingHostAsync(HostModel hostModel)
        {
            IPinger pinger = _pingerFactory.CreatePingerByProtocol(hostModel.Protocol);
            
            return await pinger.PingHostAsync(hostModel);
        }

        public async Task<IEnumerable<PingResult>> PingHostGroupAsync(IEnumerable<HostModel> hosts)
        {
            ConcurrentBag<PingResult> pingResults = new ConcurrentBag<PingResult>();

            List<Task> tasks = new List<Task>();

            foreach (HostModel host in hosts)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    IPinger pinger = _pingerFactory.CreatePingerByProtocol(host.Protocol);

                    PingResult pingResult = pinger.PingHostAsync(host).GetAwaiter().GetResult();

                    pingResults.Add(pingResult);
                }));
            }

            await Task.WhenAll(tasks);

            return pingResults;
        }
    }
}
