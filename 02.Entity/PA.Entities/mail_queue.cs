using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Entities
{
    public class mail_queue
    {
        public long? id { get; set; }
        public string token { get; set; }
        public bool sent { get; set; }
        public DateTime? create_time { get; set; }
        public string email { get; set; }
        public string text { get; set; }
        public bool active { get; set; }
    }
}
