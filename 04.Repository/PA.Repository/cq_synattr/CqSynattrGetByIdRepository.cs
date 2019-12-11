using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSynattrGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_synattr")
                .Where("cq_synattr.id",this.id)
				.Select(
					"cq_synattr.id",
					"cq_synattr.syn_id",
					"cq_synattr.rank",
					"cq_synattr.proffer_money",
					"cq_synattr.days",
					"cq_synattr.assistant_id",
					"cq_synattr.employ_time",
					"cq_synattr.proffer_exploit",
					"cq_synattr.flower",
					"cq_synattr.master_id"
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