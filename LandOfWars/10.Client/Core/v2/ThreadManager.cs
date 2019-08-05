using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.TCP
{
    public class ThreadManager
    {
        private static ThreadManager _i { get; set; }
        public static ThreadManager Instance
        {
            get
            {
                if (_i == null) _i = new ThreadManager();
                return _i;
            }
        }
        public void Disconect()
        {
            foreach (var thread in this.Threads)
            {
                if (thread.Value.Connected)
                {
                    thread.Value.Close();
                }
            }
            this.Threads = new Dictionary<int, TcpClient>();
        }
        public ThreadManager()
        {
            this.Threads = new Dictionary<int, TcpClient>();
        }
        public Dictionary<int,TcpClient> Threads { get; set; }
        public TcpClient GetThread(int id)
        {
            if (this.Threads.ContainsKey(id))
            {
                return this.Threads[id];
            }
            return null;
        }
    }
}
