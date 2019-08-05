using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqArtifactDropShapeChanceGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_artifact_drop_shape_chance")
                .Where("cq_artifact_drop_shape_chance.id",this.id)
				.Select(
					"cq_artifact_drop_shape_chance.id",
					"cq_artifact_drop_shape_chance.Type",
					"cq_artifact_drop_shape_chance.shapeminsize",
					"cq_artifact_drop_shape_chance.chance",
					"cq_artifact_drop_shape_chance.Function_id"
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