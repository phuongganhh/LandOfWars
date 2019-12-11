using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShapeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_shape")
                .Where("cq_shape.id",this.id)
				.Select(
					"cq_shape.id",
					"cq_shape.cx",
					"cq_shape.cy",
					"cq_shape.line0",
					"cq_shape.line1",
					"cq_shape.line2",
					"cq_shape.line3",
					"cq_shape.line4",
					"cq_shape.line5",
					"cq_shape.line6",
					"cq_shape.line7",
					"cq_shape.line8",
					"cq_shape.line9",
					"cq_shape.Artifact"
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