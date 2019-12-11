using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Repository
{
    public class ApplicationGetListRepository<T> : CommandBase<List<T>> where T : class, new()
    {
        private List<T> GetList(ObjectContext context)
        {
            return context.sql.From("application").Fetch<T>();
        }
        protected override Result<List<T>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetList(context));
        }
    }
}
