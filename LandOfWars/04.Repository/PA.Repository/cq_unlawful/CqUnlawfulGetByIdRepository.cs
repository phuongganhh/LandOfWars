using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUnlawfulGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? ID { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.ID == null)
            {
                throw new BusinessException("ID is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_unlawful")
                .Where("cq_unlawful.ID",this.ID)
				.Select(
					"cq_unlawful.ID",
					"cq_unlawful.word"
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