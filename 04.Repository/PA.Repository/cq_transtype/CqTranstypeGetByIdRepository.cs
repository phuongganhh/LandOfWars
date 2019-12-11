using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTranstypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_transtype")
                .Where("cq_transtype.id",this.id)
				.Select(
					"cq_transtype.id",
					"cq_transtype.sort",
					"cq_transtype.name",
					"cq_transtype.data0",
					"cq_transtype.data1",
					"cq_transtype.data2",
					"cq_transtype.data3",
					"cq_transtype.data4",
					"cq_transtype.data5",
					"cq_transtype.data6",
					"cq_transtype.data7",
					"cq_transtype.data8",
					"cq_transtype.data9",
					"cq_transtype.data10",
					"cq_transtype.data11",
					"cq_transtype.data12",
					"cq_transtype.data13",
					"cq_transtype.data14",
					"cq_transtype.data15",
					"cq_transtype.data16",
					"cq_transtype.data17",
					"cq_transtype.data18",
					"cq_transtype.data19",
					"cq_transtype.size",
					"cq_transtype.atk_speed",
					"cq_transtype.atk_delay"
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