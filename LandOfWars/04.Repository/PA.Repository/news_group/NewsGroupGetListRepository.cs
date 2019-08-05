using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Repository
{
    public class NewsGroupGetListRepository<T> : CommandBase<List<T>> where T : class, new()
    {
        private List<T> GetData(ObjectContext context)
        {
            return context.sql.From("news_group").Fetch<T>();
        }
        protected override Result<List<T>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}
