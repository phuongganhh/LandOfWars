using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqQuantaruleGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? LEVEL { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.LEVEL == null)
            {
                throw new BusinessException("LEVEL is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_quantarule")
                .Where("cq_quantarule.LEVEL",this.LEVEL)
				.Select(
					"cq_quantarule.LEVEL",
					"cq_quantarule.amount",
					"cq_quantarule.VALUE"
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