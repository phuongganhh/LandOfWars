using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqCardGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_card")
                .Where("cq_card.id",this.id)
				.Select(
					"cq_card.id",
					"cq_card.type",
					"cq_card.account_id",
					"cq_card.ref_id",
					"cq_card.chk_sum",
					"cq_card.time_stamp",
					"cq_card.used",
					"cq_card.ordernumber",
					"cq_card.flag",
					"cq_card.card_in_time"
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