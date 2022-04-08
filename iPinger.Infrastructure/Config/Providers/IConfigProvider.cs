using iPinger.Domain.Models;

namespace iPinger.Infrastructure.Config.Providers
{
    public interface IConfigProvider
    {
        ParsedConfig ProvideConfig();

    }
}
