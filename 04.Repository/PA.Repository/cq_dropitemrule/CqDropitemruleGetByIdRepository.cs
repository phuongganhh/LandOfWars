using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDropitemruleGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_dropitemrule")
                .Where("cq_dropitemrule.id",this.id)
				.Select(
					"cq_dropitemrule.id",
					"cq_dropitemrule.RuleId",
					"cq_dropitemrule.Chance",
					"cq_dropitemrule.Item0",
					"cq_dropitemrule.Item1",
					"cq_dropitemrule.Item2",
					"cq_dropitemrule.Item3",
					"cq_dropitemrule.Item4",
					"cq_dropitemrule.Item5",
					"cq_dropitemrule.Item6",
					"cq_dropitemrule.Item7",
					"cq_dropitemrule.Item8",
					"cq_dropitemrule.Item9",
					"cq_dropitemrule.Item10",
					"cq_dropitemrule.Item11",
					"cq_dropitemrule.Item12",
					"cq_dropitemrule.Item13",
					"cq_dropitemrule.Item14"
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