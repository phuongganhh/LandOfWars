using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPkBonusGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_pk_bonus")
                .Where("cq_pk_bonus.id",this.id)
				.Select(
					"cq_pk_bonus.id",
					"cq_pk_bonus.Target",
					"cq_pk_bonus.Target_name",
					"cq_pk_bonus.Hunter",
					"cq_pk_bonus.Hunter_name",
					"cq_pk_bonus.B_type",
					"cq_pk_bonus.Bonus"
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