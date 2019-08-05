using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Update.Instance.onUpdating("http://103.27.237.153:6338/Tools/Template");
                var path = "RIP_Template.exe";
                Process p = new Process();
                var f = new FileInfo(path);
                p.StartInfo.Arguments = Update.Instance.MD5Hash(f.Length + FileVersionInfo.GetVersionInfo(f.FullName).FileVersion);
                p.StartInfo.FileName = path;
                p.Start();
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
        }
    }
}
