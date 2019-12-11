using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.classes
{
    public class Logger
    {
        private static Logger _instance { get; set; }
        public static Logger Instance
        {
            get
            {
                if (_instance == null) _instance = new Logger();
                return _instance;
            }
        }
        public void Write(string mess)
        {
            using(var w = new StreamWriter("ZeroEye.log"))
            {
                w.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} : {mess}" );
            }
        }
    }
}
