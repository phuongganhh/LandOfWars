using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqBonusGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? action { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.action == null)
            {
                throw new BusinessException("action is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_bonus")
                .Where("cq_bonus.action",this.action)
				.Select(
					"cq_bonus.action",
					"cq_bonus.id",
					"cq_bonus.id_account"
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