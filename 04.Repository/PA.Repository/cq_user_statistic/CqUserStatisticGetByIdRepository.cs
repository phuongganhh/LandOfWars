using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserStatisticGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? userid { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.userid == null)
            {
                throw new BusinessException("userid is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_user_statistic")
                .Where("cq_user_statistic.userid",this.userid)
				.Select(
					"cq_user_statistic.userid",
					"cq_user_statistic.cquser_name",
					"cq_user_statistic.cquser_accountid",
					"cq_user_statistic.cquser_level",
					"cq_user_statistic.kill_count",
					"cq_user_statistic.event_type",
					"cq_user_statistic.eventime"
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