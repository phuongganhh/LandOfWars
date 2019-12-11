using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqGeneratorGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_generator")
                .Where("cq_generator.id",this.id)
				.Select(
					"cq_generator.id",
					"cq_generator.mapid",
					"cq_generator.bound_x",
					"cq_generator.bound_y",
					"cq_generator.bound_cx",
					"cq_generator.bound_cy",
					"cq_generator.grid",
					"cq_generator.rest_secs",
					"cq_generator.max_per_gen",
					"cq_generator.npctype",
					"cq_generator.timer_begin",
					"cq_generator.timer_end",
					"cq_generator.born_x",
					"cq_generator.born_y",
					"cq_generator.pathset_id",
					"cq_generator.path_returnmode",
					"cq_generator.deadtoborn",
					"cq_generator.patrol_secs",
					"cq_generator.dir",
					"cq_generator.shipmission_delay",
					"cq_generator.control_mask"
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