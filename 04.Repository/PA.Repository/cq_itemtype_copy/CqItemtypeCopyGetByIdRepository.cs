using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemtypeCopyGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_itemtype_copy")
                .Where("cq_itemtype_copy.id",this.id)
				.Select(
					"cq_itemtype_copy.id",
					"cq_itemtype_copy.name",
					"cq_itemtype_copy.level",
					"cq_itemtype_copy.weight",
					"cq_itemtype_copy.price",
					"cq_itemtype_copy.id_action",
					"cq_itemtype_copy.life",
					"cq_itemtype_copy.max_en",
					"cq_itemtype_copy.charge_en",
					"cq_itemtype_copy.max_power",
					"cq_itemtype_copy.charge_power",
					"cq_itemtype_copy.amount_limit",
					"cq_itemtype_copy.ident",
					"cq_itemtype_copy.equip_type",
					"cq_itemtype_copy.equip_level",
					"cq_itemtype_copy.equip_skill",
					"cq_itemtype_copy.gem1",
					"cq_itemtype_copy.gem2",
					"cq_itemtype_copy.magic1",
					"cq_itemtype_copy.magic2",
					"cq_itemtype_copy.magic3",
					"cq_itemtype_copy.max_range",
					"cq_itemtype_copy.atk_speed",
					"cq_itemtype_copy.nicety",
					"cq_itemtype_copy.pack_size",
					"cq_itemtype_copy.pack_width",
					"cq_itemtype_copy.max_atk",
					"cq_itemtype_copy.min_atk",
					"cq_itemtype_copy.hot_atk",
					"cq_itemtype_copy.shake_atk",
					"cq_itemtype_copy.sting_atk",
					"cq_itemtype_copy.decay_atk",
					"cq_itemtype_copy.defence_max",
					"cq_itemtype_copy.defence_percent",
					"cq_itemtype_copy.hot_def",
					"cq_itemtype_copy.shake_def",
					"cq_itemtype_copy.cold_def",
					"cq_itemtype_copy.light_def",
					"cq_itemtype_copy.shape",
					"cq_itemtype_copy.Emoney",
					"cq_itemtype_copy.Req_Engine"
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