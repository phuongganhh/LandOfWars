using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqArtifactFunctionGradeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_artifact_function_grade")
                .Where("cq_artifact_function_grade.id",this.id)
				.Select(
					"cq_artifact_function_grade.id",
					"cq_artifact_function_grade.Function_std",
					"cq_artifact_function_grade.Function_Max",
					"cq_artifact_function_grade.Data_Min",
					"cq_artifact_function_grade.Data_Max"
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