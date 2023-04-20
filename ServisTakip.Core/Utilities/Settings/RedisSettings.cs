using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Core.Utilities.Settings
{
    public class RedisSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string HashKey { get; set; }
        public int Timeout { get; set; }
    }
}
