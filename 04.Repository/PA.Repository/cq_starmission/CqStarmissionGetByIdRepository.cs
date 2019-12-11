using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStarmissionGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_starmission")
                .Where("cq_starmission.id",this.id)
				.Select(
					"cq_starmission.id",
					"cq_starmission.name",
					"cq_starmission.missionlv0",
					"cq_starmission.missionlv1",
					"cq_starmission.missionlv2",
					"cq_starmission.bonus_map",
					"cq_starmission.cellx",
					"cq_starmission.celly",
					"cq_starmission.base_time",
					"cq_starmission.first_time_bonus",
					"cq_starmission.first_prize0",
					"cq_starmission.first_prize1",
					"cq_starmission.battlelev"
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