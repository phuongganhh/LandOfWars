using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAtkGradeTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_atk_grade_type")
                .Where("cq_atk_grade_type.id",this.id)
				.Select(
					"cq_atk_grade_type.id",
					"cq_atk_grade_type.Robot_level_min",
					"cq_atk_grade_type.Robot_level_max",
					"cq_atk_grade_type.Quality",
					"cq_atk_grade_type.Addition",
					"cq_atk_grade_type.Grade"
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