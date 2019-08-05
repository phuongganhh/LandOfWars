using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqFamilyAttrGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_family_attr")
                .Where("cq_family_attr.id",this.id)
				.Select(
					"cq_family_attr.id",
					"cq_family_attr.family_id",
					"cq_family_attr.rank",
					"cq_family_attr.proffer",
					"cq_family_attr.join_date",
					"cq_family_attr.auto_execise",
					"cq_family_attr.exp_date"
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