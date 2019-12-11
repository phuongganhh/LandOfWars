using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStudentTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? Id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.Id == null)
            {
                throw new BusinessException("Id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_student_type")
                .Where("cq_student_type.Id",this.Id)
				.Select(
					"cq_student_type.Id",
					"cq_student_type.User_lev_min",
					"cq_student_type.User_lev_max",
					"cq_student_type.Uplevtime",
					"cq_student_type.God_time",
					"cq_student_type.Artifact",
					"cq_student_type.Stone0",
					"cq_student_type.Stone1",
					"cq_student_type.Stone2"
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