using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemexBakGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_itemex_bak")
                .Where("cq_itemex_bak.id",this.id)
				.Select(
					"cq_itemex_bak.id",
					"cq_itemex_bak.type",
					"cq_itemex_bak.ownertype",
					"cq_itemex_bak.owner_id",
					"cq_itemex_bak.player_id",
					"cq_itemex_bak.position",
					"cq_itemex_bak.amount",
					"cq_itemex_bak.ident",
					"cq_itemex_bak.data",
					"cq_itemex_bak.plunder",
					"cq_itemex_bak.sale_time",
					"cq_itemex_bak.max_hp",
					"cq_itemex_bak.weight",
					"cq_itemex_bak.data1",
					"cq_itemex_bak.data2",
					"cq_itemex_bak.data3",
					"cq_itemex_bak.data4",
					"cq_itemex_bak.shape",
					"cq_itemex_bak.addlevel",
					"cq_itemex_bak.hot_atk",
					"cq_itemex_bak.shake_atk",
					"cq_itemex_bak.sting_atk",
					"cq_itemex_bak.decay_atk",
					"cq_itemex_bak.chk_sum",
					"cq_itemex_bak.Forgename",
					"cq_itemex_bak.specialflag",
					"cq_itemex_bak.data5",
					"cq_itemex_bak.data6",
					"cq_itemex_bak.weight3",
					"cq_itemex_bak.weight4",
					"cq_itemex_bak.Exp"
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