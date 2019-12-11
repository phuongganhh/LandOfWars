using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStarmissionPrizeRuleGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_starmission_prize_rule")
                .Where("cq_starmission_prize_rule.id",this.id)
				.Select(
					"cq_starmission_prize_rule.id",
					"cq_starmission_prize_rule.type",
					"cq_starmission_prize_rule.lv_min",
					"cq_starmission_prize_rule.lv_max",
					"cq_starmission_prize_rule.uplevtime",
					"cq_starmission_prize_rule.item_id"
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