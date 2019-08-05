using Entities;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.API.Models.Robot
{
    public class RobotGetAction : CommandBase<IEnumerable<dynamic>>
    {
        private List<cq_robot> GetRobots(ObjectContext context)
        {
            return context.db.From("cq_robot").Where("cq_robot.player_id", context.GetUser.id).Result<cq_robot>();
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetRobots(context).Select(x=> {
                return new
                {
                    name = x.name,
                    level = x.level,
                    owner_type = x.owner_type,
                    owner_id = x.owner_id,
                    exp = x.exp,
                    life = x.life,
                    reborn = x.reborn_cnt,
                    hot_def = x.hot_def,
                    shake_def = x.shake_def,
                    cold_def = x.cold_def,
                    light_def = x.light_def,
                    mete_lev = x.Mete_lev,
                    model_lev = x.Model_lev
                };
            }));
        }
    }
}