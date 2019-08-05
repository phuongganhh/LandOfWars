using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexpSkillGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_levexp_skill")
                .Where("cq_levexp_skill.id",this.id)
				.Select(
					"cq_levexp_skill.id",
					"cq_levexp_skill.type",
					"cq_levexp_skill.level",
					"cq_levexp_skill.exp",
					"cq_levexp_skill.Uplevtime",
					"cq_levexp_skill.FinalExp",
					"cq_levexp_skill.OverAdjFinal"
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