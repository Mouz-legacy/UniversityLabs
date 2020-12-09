using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class ConfigInfo
    {
        public bool Encryption { get; set; }
        public string Archiving { get; set; }
        public string SourceDirectory { get; set; }
        public string DestinationDirectory { get; set; }
    }
}
