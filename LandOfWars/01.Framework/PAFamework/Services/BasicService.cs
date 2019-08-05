using System.ServiceProcess;

namespace PA.Framework
{
    public class BasicService<T> : ServiceBase where T : IService, new()
    {
        private IService _service;

        protected override void OnStart(string[] args)
        {
            try
            {
                _service = new T();
                _service.Start(args);
            }
            catch
            {
                ExitCode = 1064;
                throw;
            }
        }

        protected override void OnStop()
        {
            _service.Dispose();
        }
    }
}