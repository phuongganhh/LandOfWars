using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_tutor")
                .Where("cq_tutor.id",this.id)
				.Select(
					"cq_tutor.id",
					"cq_tutor.tutor_id",
					"cq_tutor.tutor_name",
					"cq_tutor.Student",
					"cq_tutor.Student_name",
					"cq_tutor.Betrayal_flag",
					"cq_tutor.LastLogout"
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