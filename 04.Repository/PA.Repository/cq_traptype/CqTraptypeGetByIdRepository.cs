using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTraptypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_traptype")
                .Where("cq_traptype.id",this.id)
				.Select(
					"cq_traptype.id",
					"cq_traptype.sort",
					"cq_traptype.look",
					"cq_traptype.action_id",
					"cq_traptype.level",
					"cq_traptype.dexterity",
					"cq_traptype.attack_speed",
					"cq_traptype.active_times",
					"cq_traptype.magic_type",
					"cq_traptype.magic_hitrate",
					"cq_traptype.size",
					"cq_traptype.atk_mode",
					"cq_traptype.atk_max",
					"cq_traptype.atk_min",
					"cq_traptype.atk_hot",
					"cq_traptype.atk_shake",
					"cq_traptype.atk_sting",
					"cq_traptype.atk_decay",
					"cq_traptype.immunity",
					"cq_traptype.touchoff_range",
					"cq_traptype.detonate_range"
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