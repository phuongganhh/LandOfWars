using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShiprecordbookGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_shiprecordbook")
                .Where("cq_shiprecordbook.id",this.id)
				.Select(
					"cq_shiprecordbook.id",
					"cq_shiprecordbook.player",
					"cq_shiprecordbook.mission",
					"cq_shiprecordbook.joins",
					"cq_shiprecordbook.finish",
					"cq_shiprecordbook.perfect",
					"cq_shiprecordbook.finish_record",
					"cq_shiprecordbook.finish_time",
					"cq_shiprecordbook.perfect_record",
					"cq_shiprecordbook.perfect_time"
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