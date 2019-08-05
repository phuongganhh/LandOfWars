using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDynaRankTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_dyna_rank_type")
                .Where("cq_dyna_rank_type.id",this.id)
				.Select(
					"cq_dyna_rank_type.id",
					"cq_dyna_rank_type.Rank_number"
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