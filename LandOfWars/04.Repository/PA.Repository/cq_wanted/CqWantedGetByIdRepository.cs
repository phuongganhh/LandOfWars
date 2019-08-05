using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWantedGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.id == null)
            {
                throw new BusinessException("id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_wanted")
                .Where("cq_wanted.id",this.id)
				.Select(
					"cq_wanted.id",
					"cq_wanted.target_name",
					"cq_wanted.target_lev",
					"cq_wanted.target_pro",
					"cq_wanted.target_syn",
					"cq_wanted.payer",
					"cq_wanted.bounty",
					"cq_wanted.order_time",
					"cq_wanted.hunter",
					"cq_wanted.finish_time"
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