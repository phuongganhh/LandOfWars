using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Repository
{
    public class NewsGetListRepository<T> : CommandBase<List<T>> where T : class, new()
    {
        public bool? pin { get; set; }
        private List<T> GetData(ObjectContext context)
        {
            var result =  context.sql
                .From("news")
                .Where("active", true)
                .Where("deleted",false)
                .OrderByDesc("create_time")
                ;
            if (this.pin != null)
                result = result.Where("pin", this.pin);
            return result.Fetch<T>();
        }
        protected override Result<List<T>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}
