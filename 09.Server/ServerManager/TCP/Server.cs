using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerManager.TCP
{
    public class Server : IDisposable
    {
        public Server()
        {
            user = new Dictionary<string, PA>();
        }
        private static Server _instance { get; set; }
        public static Server Instance
        {
            get
            {
                if (_instance == null) _instance = new Server();
                return _instance;
            }
        }
        public SimpleTcpServer server { get; set; }
        public bool Send(byte[] data)
        {
            
            return false;
        }
        public void Run(int port)
        {
            try
            {
                this.server = new SimpleTcpServer();
                this.server.Start(port);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private static Dictionary<string,PA> user { get; set; }
        public void AddUser(PA box)
        {
            user[box.client.GetIP()] = box;
            ThreadManager.Instance.Threads[box.thread.ManagedThreadId] = box.client;
        }
        public PA GetUser(TcpClient e)
        {
            if (user.ContainsKey(e.GetIP()))
            {
                return user[e.GetIP()];
            }
            return null;
        }
        public void RemoveUser(TcpClient e)
        {
            var u = this.GetUser(e);
            if (u.client.Connected)
            {
                u.client.Close();
            }
            if (u.third.client.TcpClient.Connected)
            {
                u.third.client.TcpClient.Close();
            }
            if (ThreadManager.Instance.Threads.ContainsKey(u.thread.ManagedThreadId))
            {
                ThreadManager.Instance.Threads.Remove(u.thread.ManagedThreadId);
            }
            
        }

        public void Dispose()
        {
            this.server.Stop();
        }
    }
}
