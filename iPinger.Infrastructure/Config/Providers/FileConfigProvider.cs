using iPinger.Infrastructure.Config.Parsers;
using iPinger.Infrastructure.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPinger.Infrastructure.Config.Providers
{
    public class FileConfigProvider : IConfigProvider
    {
        private readonly string _configFileName;

        private readonly IConfigParser _configParser;

        public FileConfigProvider(IConfigParser configParser, string configFileName)
        {
            _configParser = configParser;
            _configFileName = configFileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="PathTooLongException" />
        public ParsedConfig ProvideConfig()
        {
            string fileContent = File.ReadAllText(_configFileName, Encoding.UTF8);

            ParsedConfig configModel = _configParser.Parse(fileContent);

            return configModel;
        }
    }
}
