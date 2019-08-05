using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqCard2GetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_card2")
                .Where("cq_card2.id",this.id)
				.Select(
					"cq_card2.id",
					"cq_card2.type",
					"cq_card2.account_id",
					"cq_card2.ref_id",
					"cq_card2.chk_sum",
					"cq_card2.time_stamp",
					"cq_card2.used",
					"cq_card2.ordernumber",
					"cq_card2.flag",
					"cq_card2.card_in_time"
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