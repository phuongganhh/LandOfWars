using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Framework.Extensions.MySql
{
    public interface IQuerySql
    {
        string connection_string { get; set; }
        List<T> Fetch<T>(Query query);
        int Execute();
    }
}
