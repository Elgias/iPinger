using iPinger.Domain.Models;
using iPinger.Domain.Pingers;

using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace iPinger.Application.Pingers
{
    public class TcpPinger : IPinger
    {
        readonly PingerParams _params;

        public TcpPinger(PingerParams pingerParams)
        {
            _params = pingerParams;
        }

        public Task<PingResult> PingHostAsync(HostModel hostElement)
        {
            return Task.Run<PingResult>(() =>
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(hostElement.Host), hostElement.Port);

                Stopwatch stopwatch = Stopwatch.StartNew();

                PingResult pingResult = new PingResult(hostElement, false, 0);

                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        if (!client.ConnectAsync(ip.Address, ip.Port).Wait(_params.Timeout))
                        {
                            throw new SocketException();
                        }

                        pingResult.ResponseTime = client.Client.ReceiveTimeout;
                        pingResult.Available = client.Connected;
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
