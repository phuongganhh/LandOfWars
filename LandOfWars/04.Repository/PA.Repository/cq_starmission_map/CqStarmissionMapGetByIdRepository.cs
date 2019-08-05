using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStarmissionMapGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_starmission_map")
                .Where("cq_starmission_map.id",this.id)
				.Select(
					"cq_starmission_map.id",
					"cq_starmission_map.action",
					"cq_starmission_map.task",
					"cq_starmission_map.levelid",
					"cq_starmission_map.level",
					"cq_starmission_map.map",
					"cq_starmission_map.cellx",
					"cq_starmission_map.celly",
					"cq_starmission_map.limit_time",
					"cq_starmission_map.changemap_prize0",
					"cq_starmission_map.changemap_prize1",
					"cq_starmission_map.finish_prize0",
					"cq_starmission_map.finish_prize1"
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