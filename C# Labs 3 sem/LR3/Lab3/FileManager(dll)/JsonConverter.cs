using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace FileManager
{
    class JsonConverter<T> : IProvider<T> where T : class
    {
        public T ParseConfig()
        {
            T info;
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));

            if (jsonFormatter is null)
            {
                throw new ArgumentNullException(nameof(jsonFormatter));
            }

            using (var file = new FileStream(@"appsettings.json", FileMode.OpenOrCreate))
            {
                info = jsonFormatter.ReadObject(file) as T;
            }

            return info;
        }
    }
}
