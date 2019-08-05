using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorAccessGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_tutor_access")
                .Where("cq_tutor_access.id",this.id)
				.Select(
					"cq_tutor_access.id",
					"cq_tutor_access.tutor_id",
					"cq_tutor_access.Uplevtime",
					"cq_tutor_access.God_time",
					"cq_tutor_access.Artifact",
					"cq_tutor_access.Stone0",
					"cq_tutor_access.Stone1",
					"cq_tutor_access.Stone2",
					"cq_tutor_access.Exp"
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