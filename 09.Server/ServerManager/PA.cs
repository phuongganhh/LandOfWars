using ServerManager.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerManager
{
    public class PA
    {
        public Thread thread { get; set; }
        public TcpClient client { get; set; }
        public Third third { get; set; }
    }
}
