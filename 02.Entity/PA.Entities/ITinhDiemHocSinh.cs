using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Entities
{
    public interface IDataBase
    {
        int DiemToan { get; set; }
        int DiemVan { get; set; }

        float tinhDiemTrung();
    }
}
