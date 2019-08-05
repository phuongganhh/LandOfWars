using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager
{
    public class Config
    {
        public bool AntiAuto { get; set; }
    }
    public class ConfigExtensions
    {
        private static ConfigExtensions _instance { get; set; }
        private static ConfigExtensions Instance
        {
            get
            {
                if (_instance == null) _instance = new ConfigExtensions();
                return _instance;
            }
        }
        private static Config _config { get; set; }
        public Config GetConfig()
        {
            if (_config != null) return _config;
            _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("setting.json"));
            return _config;
        }
        public void SetConfig(object o)
        {
            var c = (Config)o;
            using(var w = new StreamWriter("setting.json"))
            {
                w.Write(c);
            }
            _config = c;
        }
    }
}
