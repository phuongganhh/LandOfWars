using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTotalscoreGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_totalscore")
                .Where("cq_totalscore.id",this.id)
				.Select(
					"cq_totalscore.id",
					"cq_totalscore.total_scores",
					"cq_totalscore.total_kills",
					"cq_totalscore.total_deaths",
					"cq_totalscore.finishs",
					"cq_totalscore.perfect_finishs",
					"cq_totalscore.safe_finishs"
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