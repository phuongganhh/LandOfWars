using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLifeskilltypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_lifeskilltype")
                .Where("cq_lifeskilltype.Id",this.Id)
				.Select(
					"cq_lifeskilltype.Id",
					"cq_lifeskilltype.Type",
					"cq_lifeskilltype.Sort",
					"cq_lifeskilltype.Name",
					"cq_lifeskilltype.Multi",
					"cq_lifeskilltype.Target",
					"cq_lifeskilltype.Level",
					"cq_lifeskilltype.consume_type",
					"cq_lifeskilltype.consume_amount",
					"cq_lifeskilltype.Intone_speed",
					"cq_lifeskilltype.Step_secs",
					"cq_lifeskilltype.Delay_ms",
					"cq_lifeskilltype.Range",
					"cq_lifeskilltype.Distance",
					"cq_lifeskilltype.Status",
					"cq_lifeskilltype.Need_prof",
					"cq_lifeskilltype.Need_exp",
					"cq_lifeskilltype.Auto_uplev",
					"cq_lifeskilltype.Need_level",
					"cq_lifeskilltype.Auto_learn"
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