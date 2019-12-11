using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLotteryGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_lottery")
                .Where("cq_lottery.id",this.id)
				.Select(
					"cq_lottery.id",
					"cq_lottery.type",
					"cq_lottery.rank",
					"cq_lottery.chance",
					"cq_lottery.prize_name",
					"cq_lottery.prize_type",
					"cq_lottery.prize_item",
					"cq_lottery.color",
					"cq_lottery.hole_num",
					"cq_lottery.addition_lev",
					"cq_lottery.hot_atk",
					"cq_lottery.shake_atk",
					"cq_lottery.sting_atk",
					"cq_lottery.decay_atk",
					"cq_lottery.hot_def",
					"cq_lottery.shake_def",
					"cq_lottery.sting_def",
					"cq_lottery.decay_def"
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