using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMapitemgenGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_mapitemgen")
                .Where("cq_mapitemgen.id",this.id)
				.Select(
					"cq_mapitemgen.id",
					"cq_mapitemgen.mapid",
					"cq_mapitemgen.x",
					"cq_mapitemgen.y",
					"cq_mapitemgen.range",
					"cq_mapitemgen.sec",
					"cq_mapitemgen.itemtype"
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