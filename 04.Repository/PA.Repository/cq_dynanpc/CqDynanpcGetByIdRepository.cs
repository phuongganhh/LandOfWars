using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDynanpcGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_dynanpc")
                .Where("cq_dynanpc.id",this.id)
				.Select(
					"cq_dynanpc.id",
					"cq_dynanpc.ownerid",
					"cq_dynanpc.ownertype",
					"cq_dynanpc.name",
					"cq_dynanpc.type",
					"cq_dynanpc.lookface",
					"cq_dynanpc.idxserver",
					"cq_dynanpc.mapid",
					"cq_dynanpc.cellx",
					"cq_dynanpc.celly",
					"cq_dynanpc.task0",
					"cq_dynanpc.task1",
					"cq_dynanpc.task2",
					"cq_dynanpc.task3",
					"cq_dynanpc.task4",
					"cq_dynanpc.task5",
					"cq_dynanpc.task6",
					"cq_dynanpc.task7",
					"cq_dynanpc.data0",
					"cq_dynanpc.data1",
					"cq_dynanpc.data2",
					"cq_dynanpc.data3",
					"cq_dynanpc.datastr",
					"cq_dynanpc.linkid",
					"cq_dynanpc.life",
					"cq_dynanpc.maxlife",
					"cq_dynanpc.sort",
					"cq_dynanpc.itemid",
					"cq_dynanpc.def_adj",
					"cq_dynanpc.def_sub",
					"cq_dynanpc.def_hot",
					"cq_dynanpc.def_shake",
					"cq_dynanpc.def_sting",
					"cq_dynanpc.def_decay",
					"cq_dynanpc.owner_name",
					"cq_dynanpc.default_owner_name",
					"cq_dynanpc.initial_price",
					"cq_dynanpc.price",
					"cq_dynanpc.deposit",
					"cq_dynanpc.buy_ratio",
					"cq_dynanpc.fee_type",
					"cq_dynanpc.income_value",
					"cq_dynanpc.preferential",
					"cq_dynanpc.annex",
					"cq_dynanpc.attribute_type",
					"cq_dynanpc.User_atk_adjust",
					"cq_dynanpc.user_atk_mode",
					"cq_dynanpc.harvest_date",
					"cq_dynanpc.number"
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