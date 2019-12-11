using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTradeIncomeGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? player_id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.player_id == null)
            {
                throw new BusinessException("player_id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_trade_income")
                .Where("cq_trade_income.player_id",this.player_id)
				.Select(
					"cq_trade_income.player_id",
					"cq_trade_income.income_emoney"
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