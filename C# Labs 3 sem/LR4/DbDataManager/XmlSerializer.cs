using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiceLayer
{
    public class MyXmlSerializer : ISerializer
    {
        public void Serializer<T>(string xmlPath, T type)
        {
            var xmlFormatter = new XmlSerializer(typeof(T));
            using (var file = new FileStream(xmlPath, FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, type);
            }

        }
    }
}
