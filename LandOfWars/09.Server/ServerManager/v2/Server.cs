using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.v2
{
    public class Server : IDisposable
    {
        public void Dispose()
        {
            this.Stop();
        }
        public Server()
        {
            this.server = new SimpleTcpServer();
        }
        private SimpleTcpServer server { get; set; }
        public void Start(int port)
        {
            if (!this.server.IsStarted)
            {
                this.server.Start(port);
            }
        }
        public SimpleTcpServer GetServer
        {
            get
            {
                return this.server;
            }
        }
        public void Stop()
        {
            if (this.server.IsStarted)
            {
                this.server.Stop();
            }
        }
    }
}
