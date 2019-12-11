using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorContributionsGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_tutor_contributions")
                .Where("cq_tutor_contributions.id",this.id)
				.Select(
					"cq_tutor_contributions.id",
					"cq_tutor_contributions.tutor_id",
					"cq_tutor_contributions.Student_id",
					"cq_tutor_contributions.Date",
					"cq_tutor_contributions.Uplevtime",
					"cq_tutor_contributions.God_time",
					"cq_tutor_contributions.Artifact",
					"cq_tutor_contributions.Stone0",
					"cq_tutor_contributions.Stone1",
					"cq_tutor_contributions.Stone2",
					"cq_tutor_contributions.Exp"
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