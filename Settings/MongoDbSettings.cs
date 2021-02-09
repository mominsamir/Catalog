using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog1.Settings
{
    public class MongoDbSettings
    {
        public string Host { get;  set; }
        public string Port { get; set; }
 
    public string ConnectingString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}

