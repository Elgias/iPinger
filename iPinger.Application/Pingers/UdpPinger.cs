using iPinger.Domain.Models;
using iPinger.Domain.Pingers;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Application.Pingers
{
    public class UdpPinger : IPinger
    {
        public Task<PingResult> PingHostAsync(HostModel ipElement)
        {
            return Task.Run(() =>
            {
                IPEndPoint ip = IPEndPoint.Parse(ipElement.Host);
                ip.Port = ipElement.Port;

                Stopwatch stopwatch = Stopwatch.StartNew();

                PingResult pingResult = new PingResult(ipElement, false, 0);

                try
                {
                    using (UdpClient client = new UdpClient(ip))
                    {
                        pingResult.Available = client.Client.Connected;
                    }
                }
                catch (SocketException ex)
                {

                }
                finally
                {
                    stopwatch.Stop();
                    pingResult.ResponseTime = stopwatch.ElapsedMilliseconds;
                }

                return pingResult;
            });
        }
    }
}
