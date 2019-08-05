using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqArtifactGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_artifact")
                .Where("cq_artifact.id",this.id)
				.Select(
					"cq_artifact.id",
					"cq_artifact.Type",
					"cq_artifact.Rank",
					"cq_artifact.Function_Code",
					"cq_artifact.Chance",
					"cq_artifact.Conflict0",
					"cq_artifact.Conflict1",
					"cq_artifact.Conflict2"
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