using Core.classes;
using ServerManager.Enum;
using ServerManager.Interface;
using ServerManager.TCP;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZeroEye
{
    public class GameControl : IBasic
    {
        private static GameControl _instance { get; set; }
        public static GameControl Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameControl();
                }
                return _instance;
            }
        }
        public GameControl()
        {
            this.server = new Server();
            this.server.Run(Constants.GameServerPort);
            this.server.server.ClientConnected += Server_ClientConnected;
            this.server.server.ClientDisconnected += Server_ClientDisconnected;
            this.server.server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            try
            {
                this.server.GetUser(e.TcpClient).third.Send(e.Data);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex.Message);
            }
        }

        private void Server_ClientDisconnected(object sender, System.Net.Sockets.TcpClient e)
        {
            this.server.RemoveUser(e);
        }


        private void Server_ClientConnected(object sender, System.Net.Sockets.TcpClient e)
        {
            var third = new Third();
            third.Run(Constants.GameServerPort);
            this.server.AddUser(new ServerManager.PAFrame
            {
                client = e,
                third = third,
                thread = third.client._rxThread
            });
            third.client.DataReceived += third_DataReceived;
        }

        private void third_DataReceived(object sender, SimpleTCP.Message e)
        {
            var client = ThreadManager.Instance.GetThread(Thread.CurrentThread.ManagedThreadId);
            if(client != null)
            {
                client.Client.Send(e.Data);
            }
        }

        private Server server { get; set; }
        public void Start()
        {
            if(_instance == null)
            {
                _instance = new GameControl();
            }
        }

        public void Stop()
        {
            _instance = null;
            this.server.server.Stop();
            ThreadManager.Instance.Disconect();
        }
    }
}
