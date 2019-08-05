using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponSkillGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? type { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.type == null)
            {
                throw new BusinessException("type is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_weapon_skill")
                .Where("cq_weapon_skill.type",this.type)
				.Select(
					"cq_weapon_skill.type",
					"cq_weapon_skill.level",
					"cq_weapon_skill.exp",
					"cq_weapon_skill.old_level",
					"cq_weapon_skill.owner_id",
					"cq_weapon_skill.id",
					"cq_weapon_skill.unlearn",
					"cq_weapon_skill.ownertype"
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