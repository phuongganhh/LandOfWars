using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderFromDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlExtension.connection_tring = @"server=localhost;user id=root;database=jz";
            new Find().Execute(null);
        }
    }
}
