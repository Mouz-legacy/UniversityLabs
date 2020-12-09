using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class ConfigurationProvider<T> where T : class
    {
        private IProvider<T> _config;

        public ConfigurationProvider(string pathEnd)
        {
            switch (pathEnd)
            {
                case ".xml":
                    _config = (IProvider<T>)new XmlConverter<T>().ParseConfig();
                    break;
                case ".json":
                    _config= (IProvider<T>)new JsonConverter<T>().ParseConfig(); 
                    break;
            }
        }

        public T GetConfig()
        {
            T configuration = _config.ParseConfig();
            return configuration;
        }
    }
}
