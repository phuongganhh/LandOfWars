using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqNpcGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_npc")
                .Where("cq_npc.id",this.id)
				.Select(
					"cq_npc.id",
					"cq_npc.ownerid",
					"cq_npc.ownertype",
					"cq_npc.name",
					"cq_npc.type",
					"cq_npc.lookface",
					"cq_npc.idxserver",
					"cq_npc.mapid",
					"cq_npc.cellx",
					"cq_npc.celly",
					"cq_npc.task0",
					"cq_npc.task1",
					"cq_npc.task2",
					"cq_npc.task3",
					"cq_npc.task4",
					"cq_npc.task5",
					"cq_npc.task6",
					"cq_npc.task7",
					"cq_npc.data0",
					"cq_npc.data1",
					"cq_npc.data2",
					"cq_npc.data3",
					"cq_npc.datastr",
					"cq_npc.linkid",
					"cq_npc.life",
					"cq_npc.maxlife",
					"cq_npc.sort",
					"cq_npc.itemid",
					"cq_npc.def_adj",
					"cq_npc.def_sub",
					"cq_npc.def_hot",
					"cq_npc.def_shake",
					"cq_npc.def_sting",
					"cq_npc.def_decay",
					"cq_npc.owner_name",
					"cq_npc.default_owner_name",
					"cq_npc.initial_price",
					"cq_npc.price",
					"cq_npc.deposit",
					"cq_npc.buy_ratio",
					"cq_npc.fee_type",
					"cq_npc.income_value",
					"cq_npc.preferential",
					"cq_npc.annex",
					"cq_npc.attribute_type",
					"cq_npc.User_atk_adjust",
					"cq_npc.user_atk_mode",
					"cq_npc.harvest_date"
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