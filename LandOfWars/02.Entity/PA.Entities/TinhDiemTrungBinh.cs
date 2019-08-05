using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Entities
{
    public class SqlServer : IDataBase
    {
        public int DiemToan { get; set; }
        public int DiemVan { get; set; }

        public float tinhDiemTrung()
        {
            return 0;
        }
    }
}
