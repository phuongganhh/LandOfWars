using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqScoreGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_score")
                .Where("cq_score.id",this.id)
				.Select(
					"cq_score.id",
					"cq_score.total_scores",
					"cq_score.total_kills",
					"cq_score.total_deaths",
					"cq_score.finishs",
					"cq_score.perfect_finishs",
					"cq_score.safe_finishs",
					"cq_score.mission_name",
					"cq_score.mission_id",
					"cq_score.base_scores",
					"cq_score.kills",
					"cq_score.deaths",
					"cq_score.mission_score",
					"cq_score.mission1_name",
					"cq_score.mission1_scores",
					"cq_score.mission2_name",
					"cq_score.mission2_scores",
					"cq_score.mission3_name",
					"cq_score.mission3_scores",
					"cq_score.mission4_name",
					"cq_score.mission4_scores",
					"cq_score.mission5_name",
					"cq_score.mission5_scores",
					"cq_score.mission6_name",
					"cq_score.mission6_scores",
					"cq_score.mission7_name",
					"cq_score.mission7_scores",
					"cq_score.mission8_name",
					"cq_score.mission8_scores"
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