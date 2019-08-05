using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.v2
{
    public class UserManager
    {
        public UserManager()
        {
            this._user = new Dictionary<string, PA>();
        }
        private static UserManager _instance { get; set; }
        public static UserManager Instance
        {
            get
            {
                if (_instance == null) _instance = new UserManager();
                return _instance;
            }
        }
        private Dictionary<string,PA> _user { get; set; }
        public PA GetUser(string ip)
        {
            if (this._user.ContainsKey(ip))
            {
                return this._user[ip];
            }
            return null;
        }
        public void SetUser(PA p)
        {
            this._user[p.client.GetIP()] = p;
        }
        public void Remove(string ip)
        {
            if (this._user.ContainsKey(ip))
            {
                this._user.Remove(ip);
            }
        }
    }
}
