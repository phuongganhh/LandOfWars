using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_tutor_type")
                .Where("cq_tutor_type.Id",this.Id)
				.Select(
					"cq_tutor_type.Id",
					"cq_tutor_type.User_lev_min",
					"cq_tutor_type.User_lev_max",
					"cq_tutor_type.Student_num",
					"cq_tutor_type.Battle_lev_share"
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