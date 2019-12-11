using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderFromDB
{
    public class Database
    {
        public string DBName { get; set; }
        public List<Table> Tables { get; set; }
    }
}
