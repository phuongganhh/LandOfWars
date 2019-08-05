using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTradeIncomeDeleteByIdRepository : CommandBase
    {
        public int? player_id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.player_id == null)
                throw new BusinessException("player_id không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_trade_income").Where("cq_trade_income.player_id",this.player_id).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}