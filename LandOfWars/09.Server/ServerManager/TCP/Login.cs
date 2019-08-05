using ServerManager.Enum;
using ServerManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerManager.TCP
{
    public class Login : IBasic
    {
        public Login()
        {
            try
            {
                Server.Instance.Run(Constants.LoginServerPort); // 9958
                Server.Instance.server.ClientConnected += Server_ClientConnected;
                Server.Instance.server.DelimiterDataReceived += Server_DelimiterDataReceived;
                Server.Instance.server.DataReceived += Server_DataReceived;
                Server.Instance.server.ClientDisconnected += Server_ClientDisconnected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Server_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            Server.Instance.RemoveUser(e);
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            Server.Instance.GetUser(e.TcpClient).third.Send(e.Data);
        }

        private void Server_DelimiterDataReceived(object sender, SimpleTCP.Message e)
        {
        }

        private void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            var third = new Third();
            third.client.DataReceived += third_DataReceived;
            third.Run(Constants.LoginServerPort);
            Server.Instance.AddUser(new PA {
                client = e,
                thread = third.client._rxThread,
                third = third
            });
        }


        
        private void third_DataReceived(object sender, SimpleTCP.Message e)
        {
            var u = ThreadManager.Instance.GetThread(Thread.CurrentThread.ManagedThreadId);
            var local = Encoding.ASCII.GetBytes(Constants.IPLocal);
            var serv = Encoding.ASCII.GetBytes(Constants.IPServer);
            var dt = e.Data.Replace(serv, local);
            u.Send(dt);
        }

        private static Login _i { get; set; }
        public static Login Instance
        {
            get
            {
                if (_i == null) _i = new Login();
                return _i;
            }
        }
        public void Start()
        {
            if (_i == null)
                _i = new Login();
        }
        public void Stop()
        {
            if (Server.Instance.server.IsStarted)
            {
                Server.Instance.server.Stop();
            }
            ThreadManager.Instance.Disconect();
            _i = null;
        }
    }
}
