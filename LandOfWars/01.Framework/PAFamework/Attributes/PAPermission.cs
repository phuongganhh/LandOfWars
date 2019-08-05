using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PA
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PAPermission : Attribute
    {
        public int permission_id { get; set; }
        public PAPermission(int Pers)
        {
            this.permission_id = Pers;
        }
    }
}
