using Newtonsoft.Json;
using Shecan_Desktop.utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shecan_Desktop
{

    internal class Configuration
    {

        public const string _path = @"config.json";
        public static ConfigurationModel Config { get; private set; }
        public async static Task<ConfigurationModel> Load()
        {
            if (Config is null)
            {
                ConfigurationModel config;

                if (File.Exists(_path) is false)
                {
                    var isConnected = await new ConnectionManager()
                        .IsConnectedToShecanAsync();

                    config = new ConfigurationModel()
                    {
                        IsEnabled = isConnected
                    };
                    Save(config);
                }

                var data = File.ReadAllText(_path);
                Config = JsonConvert.DeserializeObject<ConfigurationModel>(data);             
            }
            return Config;
        }
        public static void Save(ConfigurationModel config = null)
        {
            var data = JsonConvert.SerializeObject(config ?? Config);
            File.WriteAllText(_path, data);
        }
    }
}
