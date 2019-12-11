using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMagictypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_magictype")
                .Where("cq_magictype.id",this.id)
				.Select(
					"cq_magictype.id",
					"cq_magictype.sort",
					"cq_magictype.name",
					"cq_magictype.crime",
					"cq_magictype.ground",
					"cq_magictype.multi",
					"cq_magictype.target",
					"cq_magictype.immunity",
					"cq_magictype.passive",
					"cq_magictype.loop",
					"cq_magictype.intone_ms",
					"cq_magictype.delay_ms",
					"cq_magictype.step_secs",
					"cq_magictype.active_times",
					"cq_magictype.power",
					"cq_magictype.data",
					"cq_magictype.percent",
					"cq_magictype.distance",
					"cq_magictype.range",
					"cq_magictype.width",
					"cq_magictype.need_weapon",
					"cq_magictype.need_ammo",
					"cq_magictype.expend_life",
					"cq_magictype.expend_mana",
					"cq_magictype.expend_fuel",
					"cq_magictype.expend_xp",
					"cq_magictype.expend_ammo",
					"cq_magictype.status",
					"cq_magictype.pos",
					"cq_magictype.mode",
					"cq_magictype.attack",
					"cq_magictype.atk_fighter",
					"cq_magictype.atk_gunner",
					"cq_magictype.atk_energy",
					"cq_magictype.atk_hot",
					"cq_magictype.atk_shake",
					"cq_magictype.atk_sting",
					"cq_magictype.atk_decay",
					"cq_magictype.atk_final",
					"cq_magictype.subskill1",
					"cq_magictype.subskill2",
					"cq_magictype.subskill3",
					"cq_magictype.subskill4",
					"cq_magictype.subskill5",
					"cq_magictype.capacity",
					"cq_magictype.delay_chgskill",
					"cq_magictype.forbidatktype",
					"cq_magictype.reinforce_team",
					"cq_magictype.reinforce_self",
					"cq_magictype.classify",
					"cq_magictype.robot_sort",
					"cq_magictype.robot_lv",
					"cq_magictype.translook",
					"cq_magictype.together",
					"cq_magictype.usufruct",
					"cq_magictype.need_exp",
					"cq_magictype.Action",
					"cq_magictype.Uplevtime",
					"cq_magictype.robot_model_lev"
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