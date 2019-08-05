using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDynaRankRecGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_dyna_rank_rec")
                .Where("cq_dyna_rank_rec.id",this.id)
				.Select(
					"cq_dyna_rank_rec.id",
					"cq_dyna_rank_rec.type",
					"cq_dyna_rank_rec.Value1",
					"cq_dyna_rank_rec.Value2",
					"cq_dyna_rank_rec.Value3",
					"cq_dyna_rank_rec.Value4",
					"cq_dyna_rank_rec.Obj_id",
					"cq_dyna_rank_rec.datastr",
					"cq_dyna_rank_rec.User_id",
					"cq_dyna_rank_rec.User_name"
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