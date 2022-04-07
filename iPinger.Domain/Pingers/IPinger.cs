using iPinger.Domain.Models;

namespace iPinger.Domain.Pingers
{
    public interface IPinger
    {
        Task<PingResult> PingHostAsync(HostModel ipElement);
    }
}
