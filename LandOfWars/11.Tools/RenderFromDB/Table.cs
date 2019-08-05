using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderFromDB
{
    public class Table
    {
        public string name { get; set; }
        public List<Col> cols { get; set; }
    }
}
