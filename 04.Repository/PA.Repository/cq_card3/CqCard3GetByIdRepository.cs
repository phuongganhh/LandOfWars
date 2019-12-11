using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqCard3GetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_card3")
                .Where("cq_card3.id",this.id)
				.Select(
					"cq_card3.id",
					"cq_card3.type",
					"cq_card3.account_id",
					"cq_card3.ref_id",
					"cq_card3.chk_sum",
					"cq_card3.time_stamp",
					"cq_card3.used",
					"cq_card3.flag",
					"cq_card3.ordernumber"
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