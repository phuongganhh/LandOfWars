using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponSkillDeleteByIdRepository : CommandBase
    {
        public int? type { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.type == null)
                throw new BusinessException("type không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_weapon_skill").Where("cq_weapon_skill.type",this.type).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}