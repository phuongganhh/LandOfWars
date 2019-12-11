using Core.classes;
using PA.Framework;
using ServerManager.TCP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroEye;

namespace Core.Services
{
    public class ZeroEyes : IService
    {
        public void DefaultStart()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "LOW.exe";
                p.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                p.StartInfo.Arguments = "blacknull";
                p.Start();
            }
            catch (Exception)
            {

            }
            
        }

        public void Dispose()
        {
        }
        public void Start(string[] args)
        {
            try
            {
                Login.Instance.Start();
                GameControl.Instance.Start();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex.Message);
            }
            
        }
    }
}
