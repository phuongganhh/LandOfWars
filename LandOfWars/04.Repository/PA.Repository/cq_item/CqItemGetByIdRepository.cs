using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_item")
                .Where("cq_item.id",this.id)
				.Select(
					"cq_item.id",
					"cq_item.type",
					"cq_item.ownertype",
					"cq_item.owner_id",
					"cq_item.player_id",
					"cq_item.position",
					"cq_item.amount",
					"cq_item.ident",
					"cq_item.data",
					"cq_item.plunder",
					"cq_item.sale_time",
					"cq_item.chk_sum"
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