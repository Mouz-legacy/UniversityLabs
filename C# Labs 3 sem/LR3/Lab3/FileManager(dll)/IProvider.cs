using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IProvider<out T>
    {
        T ParseConfig();
    }
}
