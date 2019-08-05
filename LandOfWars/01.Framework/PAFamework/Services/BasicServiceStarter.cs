using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using PA.Framework.Extensions;

namespace PA.Framework
{
    /// <summary>
    /// http://www.devopsonwindows.com/build-windows-service-framework/
    /// </summary>
    public static class BasicServiceStarter
    {
        public static void Run<T>(string serviceName = "StandardService") where T : IService, new()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                {
                    if (EventLog.SourceExists(serviceName))
                    {
                        EventLog.WriteEntry(serviceName,
                            "Fatal Exception : " + Environment.NewLine +
                            e.ExceptionObject, EventLogEntryType.Error);
                    }
                };

                if (Environment.UserInteractive)
                {
                    var cmd = Environment.GetCommandLineArgs()
                        .Skip(1)
                        .FirstOrDefault()
                        .vnSafe(string.Empty)
                        .ToLower();
                    switch (cmd)
                    {
                        case "pai":
                            BasicServiceInstaller.Install(serviceName);
                            ServiceController service = new ServiceController(serviceName);
                            service.Start();
                            service.WaitForStatus(ServiceControllerStatus.Running);
                            using(var s = new T())
                            {
                                s.DefaultStart();
                            }
                            break;
                        case "pa-u":
                            BasicServiceInstaller.Uninstall(serviceName);
                            break;
                        default:
                            using (var s = new T())
                            {
                                s.DefaultStart();
                                s.Dispose();
                            }
                            break;
                    }
                }
                else
                {
                    ServiceBase.Run(new BasicService<T> { ServiceName = serviceName });
                }
            }
            catch (Exception ex)
            {
                using (var w = new StreamWriter("ZeroEye.log"))
                {
                    w.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} : {ex.Message}");
                }
                Environment.Exit(1);
            }
            
        }
    }
}
