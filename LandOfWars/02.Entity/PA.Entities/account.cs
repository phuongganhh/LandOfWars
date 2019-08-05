using PA;
using System;

namespace Entities
{
    public class account
    {
		public long? id { get; set; }
		public string name { get; set; }
		public string password { get; set; }
		public long type { get; set; }
		public long point { get; set; }
		public long pointtime { get; set; }
		public long online { get; set; }
		public long licence { get; set; }
		public string netbar_ip { get; set; }
		public string ip_mask { get; set; }
		public string email { get; set; }
        public int? permission_id { get; set; }
        public DateTime? reg_date { get; set; }
        public int? VIP { get; set; }
        public long money { get; set; }
    }
}
