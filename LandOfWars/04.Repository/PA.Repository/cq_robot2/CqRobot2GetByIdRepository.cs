using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobot2GetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_robot2")
                .Where("cq_robot2.id",this.id)
				.Select(
					"cq_robot2.id",
					"cq_robot2.name",
					"cq_robot2.owner_type",
					"cq_robot2.owner_id",
					"cq_robot2.player_id",
					"cq_robot2.type",
					"cq_robot2.exp",
					"cq_robot2.level",
					"cq_robot2.life",
					"cq_robot2.position",
					"cq_robot2.color",
					"cq_robot2.reborn_cnt",
					"cq_robot2.number",
					"cq_robot2.hot_def",
					"cq_robot2.shake_def",
					"cq_robot2.cold_def",
					"cq_robot2.light_def",
					"cq_robot2.ExpBallUsage",
					"cq_robot2.EN_state",
					"cq_robot2.weapon_select",
					"cq_robot2.eatheruplev_date",
					"cq_robot2.TechnoPoint",
					"cq_robot2.TechnoUsage0",
					"cq_robot2.TechnoUsage1",
					"cq_robot2.TechnoUsage2",
					"cq_robot2.TechnoUsage3",
					"cq_robot2.TechnoUsage4",
					"cq_robot2.Model_lev",
					"cq_robot2.Mete_lev",
					"cq_robot2.Mete_RobotType",
					"cq_robot2.research1",
					"cq_robot2.research2",
					"cq_robot2.research3",
					"cq_robot2.research4",
					"cq_robot2.research5",
					"cq_robot2.research6",
					"cq_robot2.research7",
					"cq_robot2.research8",
					"cq_robot2.chk_sum",
					"cq_robot2.qi",
					"cq_robot2.qiusage"
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