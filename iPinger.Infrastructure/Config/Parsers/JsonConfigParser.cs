using iPinger.Domain.Models;
using iPinger.Infrastructure.Models;

using Newtonsoft.Json;

using Shared.Exceptions.Config;

namespace iPinger.Infrastructure.Config.Parsers
{
    public class JsonConfigParser : IConfigParser
    {
        public ParsedConfig Parse(string content)
        {
            ConfigModel? configModel = JsonConvert.DeserializeObject<ConfigModel>(content);

            if (configModel is null)
            {
                throw new ParseConfigException("Config is invalid");
            }

            ParsedConfig parsedConfig = new ParsedConfig
            {
                Hosts = configModel.Hosts.Select(x => new HostModel
                {
                    Host = x.Host,
                    Port = x.Port,
                    Protocol = x.Protocol switch
                    {
                        "tcp" => Protocol.Tcp,
                        "udp" => Protocol.Udp,
                        _ => Protocol.Tcp
                    }
                })
            };

            return parsedConfig;
        }
    }
}
