using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobotGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_robot")
                .Where("cq_robot.id",this.id)
				.Select(
					"cq_robot.id",
					"cq_robot.name",
					"cq_robot.owner_type",
					"cq_robot.owner_id",
					"cq_robot.player_id",
					"cq_robot.type",
					"cq_robot.exp",
					"cq_robot.level",
					"cq_robot.life",
					"cq_robot.position",
					"cq_robot.color",
					"cq_robot.reborn_cnt",
					"cq_robot.number",
					"cq_robot.hot_def",
					"cq_robot.shake_def",
					"cq_robot.cold_def",
					"cq_robot.light_def",
					"cq_robot.ExpBallUsage",
					"cq_robot.EN_state",
					"cq_robot.weapon_select",
					"cq_robot.eatheruplev_date",
					"cq_robot.TechnoPoint",
					"cq_robot.TechnoUsage0",
					"cq_robot.TechnoUsage1",
					"cq_robot.TechnoUsage2",
					"cq_robot.TechnoUsage3",
					"cq_robot.TechnoUsage4",
					"cq_robot.Model_lev",
					"cq_robot.Mete_lev",
					"cq_robot.Mete_RobotType",
					"cq_robot.research1",
					"cq_robot.research2",
					"cq_robot.research3",
					"cq_robot.research4",
					"cq_robot.research5",
					"cq_robot.research6",
					"cq_robot.research7",
					"cq_robot.research8",
					"cq_robot.chk_sum",
					"cq_robot.qi",
					"cq_robot.qiusage",
					"cq_robot.syndicate"
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