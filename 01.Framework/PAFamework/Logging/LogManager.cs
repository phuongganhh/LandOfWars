using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Framework.Logging
{
    public class LogManager
    {
        private static LogManager _instance { get; set; }
        public static LogManager Instance
        {
            get
            {
                if (_instance == null) _instance = new LogManager();
                return _instance;
            }
        }
        public void Log(string message)
        {
            using(var w = new StreamWriter(@"C:/Log/"+DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".log"))
            {
                w.WriteLine(message);
                w.Close();
            }
        }
    }
}
