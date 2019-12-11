using Entities;
using PA.Caching;
using PA.Common;
using PA.Common.cq_robot;
using PA.Extensions;
using PA.Framework;
using PA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.API.Models.Robot
{
    public class RobotRanksAction : CommandBase<IEnumerable<dynamic>>
    {
        private IEnumerable<dynamic> GetRank(ObjectContext context)
        {
            var robot = context.db.From("cq_robot").Result<cq_robot>();
            return context.db.From("cq_user").Result<cq_user>().Where(x=>!x.name.EndsWith("[PM]")).OrderByDescending(x=>x.Battle_lev).ToList().Select(x =>
            {
                return new
                {
                    name = x.name,
                    fight_power = x.Battle_lev,
                    last_login = x.login_time.GetTime().ToString("yyyy-MM-dd HH:mm:ss"),
                    last_logout = x.last_logout2.GetTime().ToString("yyyy-MM-dd HH:mm:ss"),
                    login_time = x.login_time.GetTime().Ticks,
                    logout_time = x.last_logout2.GetTime().Ticks,
                    level = robot?.Where(w => w.player_id == x.id)?.OrderByDescending(s=>s.level).Select(s=> s.level).FirstOrDefault()
                };
            });
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            var result = context.cache.GetOrSet<IEnumerable<dynamic>>("RobotRanking", () =>
            {
                return this.GetRank(context);
            }, 5);
            return Success(result);
        }
    }
}