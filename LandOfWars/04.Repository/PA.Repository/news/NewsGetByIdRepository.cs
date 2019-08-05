using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Repository
{
    public class NewsGetByIdRepository<T> : CommandBase<T> where T : class, new()
    {
        public long? id { get; set; }
        private Result<T> GetData(ObjectContext context)
        {
            return Success(context.sql.From("news").Where("id", this.id).Where("active", true).Fetch<T>().FirstOrDefault());
        }
        protected override Result<T> ExecuteCore(ObjectContext context)
        {
            return this.GetData(context);
        }
    }
}
