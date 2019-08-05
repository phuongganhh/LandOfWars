using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShipGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_ship")
                .Where("cq_ship.id",this.id)
				.Select(
					"cq_ship.id",
					"cq_ship.type",
					"cq_ship.name",
					"cq_ship.IdName",
					"cq_ship.captain",
					"cq_ship.captain_lev",
					"cq_ship.owner_type",
					"cq_ship.owner_id",
					"cq_ship.record_fly",
					"cq_ship.record_finish",
					"cq_ship.npc1",
					"cq_ship.npc2",
					"cq_ship.npc3",
					"cq_ship.npc4",
					"cq_ship.npc5",
					"cq_ship.npc6",
					"cq_ship.npc7",
					"cq_ship.npc8",
					"cq_ship.lookface"
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