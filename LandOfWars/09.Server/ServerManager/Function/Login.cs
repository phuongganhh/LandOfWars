using ServerManager.Enum;
using ServerManager.Interface;
using ServerManager.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Function
{
    public class Login : IBasic
    {
        public Login()
        {
            this.server = new Server();
            this.server.GetServer.ClientConnected += GetServer_ClientConnected;
            this.server.GetServer.ClientDisconnected += GetServer_ClientDisconnected;
            this.server.GetServer.DataReceived += GetServer_DataReceived;
        }

        private void GetServer_DataReceived(object sender, SimpleTCP.Message e)
        {
            throw new NotImplementedException();
        }

        private void GetServer_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            throw new NotImplementedException();
        }

        private void GetServer_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            throw new NotImplementedException();
        }

        private Server server { get; set; }
        public void Start()
        {
            this.server.Start(Constants.LoginServerPort);
        }

        public void Stop()
        {
            this.server.Stop();
        }
    }
}
