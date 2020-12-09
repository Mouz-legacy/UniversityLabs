using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileManager
{
    class XmlConverter<T> : IProvider<T> where T : class
    {
        public T ParseConfig()
        {
            T info;
            var xmlFormatter = new XmlSerializer(typeof(T));
            if (xmlFormatter is null)
            {
                throw new ArgumentNullException(nameof(xmlFormatter));
            }

            using (var file = new FileStream(@"config.xml", FileMode.OpenOrCreate))
            {
                info = xmlFormatter.Deserialize(file) as T;
            }

            return info;
        }
    }
}
