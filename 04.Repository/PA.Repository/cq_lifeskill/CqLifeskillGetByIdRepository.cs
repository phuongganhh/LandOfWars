using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLifeskillGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? Id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.Id == null)
            {
                throw new BusinessException("Id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_lifeskill")
                .Where("cq_lifeskill.Id",this.Id)
				.Select(
					"cq_lifeskill.Id",
					"cq_lifeskill.Ownerid",
					"cq_lifeskill.Type",
					"cq_lifeskill.Level",
					"cq_lifeskill.Exp"
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