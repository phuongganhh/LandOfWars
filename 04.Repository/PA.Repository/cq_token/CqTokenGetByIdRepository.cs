using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTokenGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_token")
                .Where("cq_token.id",this.id)
				.Select(
					"cq_token.id",
					"cq_token.type",
					"cq_token.id_source",
					"cq_token.id_target",
					"cq_token.number",
					"cq_token.chk_sum",
					"cq_token.time_stamp",
					"cq_token.sourceBalance",
					"cq_token.targetBalance"
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