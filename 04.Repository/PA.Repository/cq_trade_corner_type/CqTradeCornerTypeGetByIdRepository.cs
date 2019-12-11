using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTradeCornerTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_trade_corner_type")
                .Where("cq_trade_corner_type.id",this.id)
				.Select(
					"cq_trade_corner_type.id",
					"cq_trade_corner_type.itemtype",
					"cq_trade_corner_type.buy_price",
					"cq_trade_corner_type.amount",
					"cq_trade_corner_type.sell_price"
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