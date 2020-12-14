using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    interface ISerializer
    {
        void Serializer<T>(string path, T type);
    }
}
