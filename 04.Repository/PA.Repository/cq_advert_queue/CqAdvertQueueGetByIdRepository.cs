using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAdvertQueueGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_advert_queue")
                .Where("cq_advert_queue.id",this.id)
				.Select(
					"cq_advert_queue.id",
					"cq_advert_queue.type",
					"cq_advert_queue.next_id",
					"cq_advert_queue.user_id",
					"cq_advert_queue.user_name",
					"cq_advert_queue.create_time",
					"cq_advert_queue.addition",
					"cq_advert_queue.words"
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