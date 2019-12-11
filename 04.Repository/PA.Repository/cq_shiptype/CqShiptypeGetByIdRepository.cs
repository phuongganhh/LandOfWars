using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShiptypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_shiptype")
                .Where("cq_shiptype.id",this.id)
				.Select(
					"cq_shiptype.id",
					"cq_shiptype.name",
					"cq_shiptype.mapdoc",
					"cq_shiptype.level",
					"cq_shiptype.price",
					"cq_shiptype.maxplayers",
					"cq_shiptype.rows",
					"cq_shiptype.cols"
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