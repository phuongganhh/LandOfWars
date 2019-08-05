using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqTradeIncome
{
    public class CqTradeIncomeGetByIdAction : CommandBase<dynamic>
    {
        public int? player_id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.player_id == null)
            {
                throw new BusinessException("player_id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqTradeIncomeGetByIdRepository<dynamic>())
			{
				cmd.player_id = this.player_id;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}