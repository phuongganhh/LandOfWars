using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPointAllotGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_point_allot")
                .Where("cq_point_allot.id",this.id)
				.Select(
					"cq_point_allot.id",
					"cq_point_allot.prof_sort",
					"cq_point_allot.level",
					"cq_point_allot.force",
					"cq_point_allot.Speed",
					"cq_point_allot.health",
					"cq_point_allot.soul"
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