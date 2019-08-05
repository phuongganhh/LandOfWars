using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqFamilyGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_family")
                .Where("cq_family.id",this.id)
				.Select(
					"cq_family.id",
					"cq_family.family_name",
					"cq_family.rank",
					"cq_family.lead_name",
					"cq_family.lead_id",
					"cq_family.announce",
					"cq_family.money",
					"cq_family.repute",
					"cq_family.amount",
					"cq_family.enemy_family0_id",
					"cq_family.enemy_family1_id",
					"cq_family.enemy_family2_id",
					"cq_family.enemy_family3_id",
					"cq_family.enemy_family4_id",
					"cq_family.ally_family0_id",
					"cq_family.ally_family1_id",
					"cq_family.ally_family2_id",
					"cq_family.ally_family3_id",
					"cq_family.ally_family4_id",
					"cq_family.create_date",
					"cq_family.create_name",
					"cq_family.Star_tower",
					"cq_family.family_mapid",
					"cq_family.del_flag",
					"cq_family.challenge",
					"cq_family.occupy"
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