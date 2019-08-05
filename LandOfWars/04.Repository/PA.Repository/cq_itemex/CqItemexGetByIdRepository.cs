using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemexGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_itemex")
                .Where("cq_itemex.id",this.id)
				.Select(
					"cq_itemex.id",
					"cq_itemex.type",
					"cq_itemex.ownertype",
					"cq_itemex.owner_id",
					"cq_itemex.player_id",
					"cq_itemex.position",
					"cq_itemex.amount",
					"cq_itemex.ident",
					"cq_itemex.data",
					"cq_itemex.plunder",
					"cq_itemex.sale_time",
					"cq_itemex.max_hp",
					"cq_itemex.weight",
					"cq_itemex.data1",
					"cq_itemex.data2",
					"cq_itemex.data3",
					"cq_itemex.data4",
					"cq_itemex.shape",
					"cq_itemex.addlevel",
					"cq_itemex.hot_atk",
					"cq_itemex.shake_atk",
					"cq_itemex.sting_atk",
					"cq_itemex.decay_atk",
					"cq_itemex.chk_sum",
					"cq_itemex.Forgename",
					"cq_itemex.specialflag",
					"cq_itemex.data5",
					"cq_itemex.data6",
					"cq_itemex.weight3",
					"cq_itemex.weight4",
					"cq_itemex.Exp",
					"cq_itemex.addlevel_exp"
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