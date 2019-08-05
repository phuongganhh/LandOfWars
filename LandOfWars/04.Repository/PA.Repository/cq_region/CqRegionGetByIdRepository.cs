using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRegionGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_region")
                .Where("cq_region.id",this.id)
				.Select(
					"cq_region.id",
					"cq_region.mapid",
					"cq_region.type",
					"cq_region.bound_x",
					"cq_region.bound_y",
					"cq_region.bound_cx",
					"cq_region.bound_cy",
					"cq_region.datastr",
					"cq_region.data0",
					"cq_region.data1",
					"cq_region.data2",
					"cq_region.data3"
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