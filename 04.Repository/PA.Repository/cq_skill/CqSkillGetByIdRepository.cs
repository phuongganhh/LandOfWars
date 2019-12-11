using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSkillGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_skill")
                .Where("cq_skill.id",this.id)
				.Select(
					"cq_skill.id",
					"cq_skill.ownerid",
					"cq_skill.main",
					"cq_skill.sub1",
					"cq_skill.sub2",
					"cq_skill.sub3",
					"cq_skill.hotkey",
					"cq_skill.weapon_pos",
					"cq_skill.owner_type"
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