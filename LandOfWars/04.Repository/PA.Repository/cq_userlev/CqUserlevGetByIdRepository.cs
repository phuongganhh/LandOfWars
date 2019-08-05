using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserlevGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.level == null)
            {
                throw new BusinessException("level is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_userlev")
                .Where("cq_userlev.level",this.level)
				.Select(
					"cq_userlev.level",
					"cq_userlev.exp",
					"cq_userlev.data"
				)
                .Result<T>()
                .FirstOrDefault()
                ;
        }
        protected override Result<T> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}