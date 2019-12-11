using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Entities
{
    public class package
    {
        public long? id { get; set; }
        public long? package_id { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public long? price { get; set; }
        public long? type { get; set; }
    }
}
