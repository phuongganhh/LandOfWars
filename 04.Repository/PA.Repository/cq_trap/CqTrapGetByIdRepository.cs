using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTrapGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_trap")
                .Where("cq_trap.id",this.id)
				.Select(
					"cq_trap.id",
					"cq_trap.type",
					"cq_trap.look",
					"cq_trap.owner_id",
					"cq_trap.map_id",
					"cq_trap.pos_x",
					"cq_trap.pos_y",
					"cq_trap.data",
					"cq_trap.pos_cx",
					"cq_trap.pos_cy"
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