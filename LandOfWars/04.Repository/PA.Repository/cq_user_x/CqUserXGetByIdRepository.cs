using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserXGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_user_x")
                .Where("cq_user_x.id",this.id)
				.Select(
					"cq_user_x.id",
					"cq_user_x.name",
					"cq_user_x.big_badluck",
					"cq_user_x.small_badluck",
					"cq_user_x.lottery_times",
					"cq_user_x.big_goodluck",
					"cq_user_x.small_goodluck",
					"cq_user_x.lastlottery",
					"cq_user_x.Stone0",
					"cq_user_x.Stone1",
					"cq_user_x.Stone2",
					"cq_user_x.chk_sum",
					"cq_user_x.ExpBallRobot"
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