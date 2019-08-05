using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.v2
{
    public class Client
    {
        public Client()
        {
            this.client = new SimpleTcpClient();
        }
        private SimpleTcpClient client { get; set; }
        public SimpleTcpClient GetClient
        {
            get
            {
                return this.client;
            }
        }
        public void Start(string host,int port)
        {
            if (!this.client.TcpClient.Connected)
            {
                this.client.Connect(host, port);
            }
        }
        public void Stop()
        {
            if (this.client.TcpClient.Connected)
            {
                this.client.Disconnect();
            }
        }
    }
}
