using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqWeaponSkill
{
    public class CqWeaponSkillDeleteByIdAction : CommandBase
    {
        public int? type { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.type == null)
                throw new BusinessException("type không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqWeaponSkillDeleteByIdRepository())
			{
				cmd.type = this.type;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}