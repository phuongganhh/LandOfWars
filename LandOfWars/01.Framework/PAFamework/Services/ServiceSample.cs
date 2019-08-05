using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Framework
{

    class Program
    {
        public const string Name = "TuanSampleService";

        static void Main(string[] args)
        {
            BasicServiceStarter.Run<TuanSampleService>(Name);
        }
    }

    class TuanSampleService : IService
    {
        public void Start(string[] args)
        {
        }

        public void Dispose()
        {
        }

        public void DefaultStart()
        {
            throw new NotImplementedException();
        }
    }
}
