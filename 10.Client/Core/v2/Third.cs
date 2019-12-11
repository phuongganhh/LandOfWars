using ServerManager.Enum;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.TCP
{
    public class Third : IDisposable
    {
        public Third()
        {
            this.client = new SimpleTcpClient();
        }
        public SimpleTcpClient client { get; set; }
        private static Third _instance { get; set; }
        public static Third Instance
        {
            get
            {
                if (_instance == null) _instance = new Third();
                return _instance;
            }
        }
        private bool _isConnected { get; set; }
        public void Run(int port)
        {
            if (!this._isConnected)
            {
                this.client.Connect(Constants.IPServer, port);
                this._isConnected = true;
            }
        }
        public bool Send(byte[] o)
        {
            if (this._isConnected)
            {
                this.client.Write(o);
                return true;
            }
            return false;
        }
        public bool Send(object o)
        {
            if (this._isConnected)
            {
                this.client.Write(o.ToByteArray());
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            this.client.Disconnect();
        }
    }
}
