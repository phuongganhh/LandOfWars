using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqContracttypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_contracttype")
                .Where("cq_contracttype.id",this.id)
				.Select(
					"cq_contracttype.id",
					"cq_contracttype.name",
					"cq_contracttype.maxlv_header",
					"cq_contracttype.minlv_header",
					"cq_contracttype.maxlv_member",
					"cq_contracttype.minlv_member",
					"cq_contracttype.item",
					"cq_contracttype.money",
					"cq_contracttype.sociality",
					"cq_contracttype.time",
					"cq_contracttype.troop",
					"cq_contracttype.magic1",
					"cq_contracttype.magic2",
					"cq_contracttype.magic3",
					"cq_contracttype.magic4",
					"cq_contracttype.magic5",
					"cq_contracttype.magic6",
					"cq_contracttype.maxhp_adj",
					"cq_contracttype.maxen_adj",
					"cq_contracttype.maxfu_adj",
					"cq_contracttype.maxxp_adj",
					"cq_contracttype.hp_regenerate",
					"cq_contracttype.en_regenerate",
					"cq_contracttype.fu_regenerate",
					"cq_contracttype.troop_skill_id",
					"cq_contracttype.sociality_id",
					"cq_contracttype.rate_affect",
					"cq_contracttype.stone_expend",
					"cq_contracttype.req_sort",
					"cq_contracttype.range",
					"cq_contracttype.equip",
					"cq_contracttype.def",
					"cq_contracttype.hot_def",
					"cq_contracttype.shake_def",
					"cq_contracttype.sting_def",
					"cq_contracttype.decay_def",
					"cq_contracttype.pk_def",
					"cq_contracttype.status_immunity",
					"cq_contracttype.lv_contrast"
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