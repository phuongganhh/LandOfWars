using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PA.Framework
{
    /// <summary>
    /// http://www.devopsonwindows.com/build-windows-service-framework/
    /// </summary>
    static class BasicServiceInstaller
    {
        public static void Install(string serviceName)
        {
            if (serviceName.DoesServiceExist())
            {
                Uninstall(serviceName);
            }
            CreateInstaller(serviceName).Install(new Hashtable());
        }
        private static bool isRunning(this string name)
        {
            try
            {
                ServiceController sc = new ServiceController(name);
                var a = sc.Status;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public static bool DoesServiceExist(this string serviceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(serviceName));
        }
        public static void Uninstall(string serviceName)
        {
            CreateInstaller(serviceName).Uninstall(null);
        }

        private static Installer CreateInstaller(string serviceName)
        {
            var installer = new TransactedInstaller();
            installer.Installers.Add(new ServiceInstaller
            {
                ServiceName = serviceName,
                DisplayName = serviceName,
                StartType = ServiceStartMode.Manual
            });
            installer.Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            });
            var installContext = new InstallContext(
                serviceName + ".install.log", null);
            installContext.Parameters["assemblypath"] =
                Assembly.GetEntryAssembly().Location;
            installer.Context = installContext;
            return installer;
        }
    }
}
