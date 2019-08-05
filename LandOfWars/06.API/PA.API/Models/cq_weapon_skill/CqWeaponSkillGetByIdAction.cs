using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqWeaponSkill
{
    public class CqWeaponSkillGetByIdAction : CommandBase<dynamic>
    {
        public int? type { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.type == null)
            {
                throw new BusinessException("type is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqWeaponSkillGetByIdRepository<dynamic>())
			{
				cmd.type = this.type;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}