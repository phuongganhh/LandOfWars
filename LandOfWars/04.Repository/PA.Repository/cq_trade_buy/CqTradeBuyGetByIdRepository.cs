using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTradeBuyGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_trade_buy")
                .Where("cq_trade_buy.id",this.id)
				.Select(
					"cq_trade_buy.id",
					"cq_trade_buy.player_id",
					"cq_trade_buy.itemtype",
					"cq_trade_buy.price",
					"cq_trade_buy.amount",
					"cq_trade_buy.deposit",
					"cq_trade_buy.date"
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