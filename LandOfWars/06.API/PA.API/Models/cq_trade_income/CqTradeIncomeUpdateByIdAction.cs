using Entities;
using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;
namespace PA.API.Models.CqTradeIncome
{
    public class CqTradeIncomeUpdateByIdAction : CommandBase
    {
        public cq_trade_income data { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.data == null)
            {
                throw new BusinessException("Dữ liệu không thể null", System.Net.HttpStatusCode.BadRequest);
            }
            if(this.data.player_id == null)
            {
                throw new BusinessException("player_id không được null", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result UpdateData(ObjectContext context)
        {
            using(var cmd = new CqTradeIncomeUpdateByIdRepository())
			{
				cmd.data = this.data;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.UpdateData(context);
        }
    }
}