using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAdvertLogGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_advert_log")
                .Where("cq_advert_log.id",this.id)
				.Select(
					"cq_advert_log.id",
					"cq_advert_log.type",
					"cq_advert_log.user_id",
					"cq_advert_log.user_name",
					"cq_advert_log.publish_time",
					"cq_advert_log.addition",
					"cq_advert_log.words"
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