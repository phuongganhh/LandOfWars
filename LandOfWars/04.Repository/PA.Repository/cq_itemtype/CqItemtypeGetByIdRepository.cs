using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemtypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_itemtype")
                .Where("cq_itemtype.id",this.id)
				.Select(
					"cq_itemtype.id",
					"cq_itemtype.name",
					"cq_itemtype.level",
					"cq_itemtype.weight",
					"cq_itemtype.price",
					"cq_itemtype.id_action",
					"cq_itemtype.life",
					"cq_itemtype.max_en",
					"cq_itemtype.charge_en",
					"cq_itemtype.max_power",
					"cq_itemtype.charge_power",
					"cq_itemtype.amount_limit",
					"cq_itemtype.ident",
					"cq_itemtype.equip_type",
					"cq_itemtype.equip_level",
					"cq_itemtype.equip_skill",
					"cq_itemtype.gem1",
					"cq_itemtype.gem2",
					"cq_itemtype.magic1",
					"cq_itemtype.magic2",
					"cq_itemtype.magic3",
					"cq_itemtype.max_range",
					"cq_itemtype.atk_speed",
					"cq_itemtype.nicety",
					"cq_itemtype.pack_size",
					"cq_itemtype.pack_width",
					"cq_itemtype.max_atk",
					"cq_itemtype.min_atk",
					"cq_itemtype.hot_atk",
					"cq_itemtype.shake_atk",
					"cq_itemtype.sting_atk",
					"cq_itemtype.decay_atk",
					"cq_itemtype.defence_max",
					"cq_itemtype.defence_percent",
					"cq_itemtype.hot_def",
					"cq_itemtype.shake_def",
					"cq_itemtype.cold_def",
					"cq_itemtype.light_def",
					"cq_itemtype.shape",
					"cq_itemtype.Emoney",
					"cq_itemtype.Req_Engine"
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