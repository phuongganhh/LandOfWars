using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMacrossGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_macross")
                .Where("cq_macross.id",this.id)
				.Select(
					"cq_macross.id",
					"cq_macross.unit1",
					"cq_macross.unit2",
					"cq_macross.unit3",
					"cq_macross.data1",
					"cq_macross.data2",
					"cq_macross.data3",
					"cq_macross.data4",
					"cq_macross.data5",
					"cq_macross.data6",
					"cq_macross.data7",
					"cq_macross.data8",
					"cq_macross.name",
					"cq_macross.fuse"
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