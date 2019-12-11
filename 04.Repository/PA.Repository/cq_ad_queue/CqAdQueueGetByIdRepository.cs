using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAdQueueGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_ad_queue")
                .Where("cq_ad_queue.id",this.id)
				.Select(
					"cq_ad_queue.id",
					"cq_ad_queue.next_id",
					"cq_ad_queue.user_id",
					"cq_ad_queue.user_name",
					"cq_ad_queue.create_time",
					"cq_ad_queue.addition",
					"cq_ad_queue.words"
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