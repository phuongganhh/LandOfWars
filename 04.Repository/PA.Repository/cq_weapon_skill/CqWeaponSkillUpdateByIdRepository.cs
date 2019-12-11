using Entities;
using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponSkillUpdateByIdRepository : CommandBase
    {
        public cq_weapon_skill data { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.data == null)
            {
                throw new BusinessException("Dữ liệu không thể null", System.Net.HttpStatusCode.BadRequest);
            }
            if(this.data.type == null)
            {
                throw new BusinessException("type không được null", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result UpdateData(ObjectContext context)
        {
            context.db
                .From("cq_weapon_skill")
                .Where("cq_weapon_skill.type",this.data.type)
                .Update(data)
                .ExecuteNotResult()
                ;
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.UpdateData(context);
        }
    }
}