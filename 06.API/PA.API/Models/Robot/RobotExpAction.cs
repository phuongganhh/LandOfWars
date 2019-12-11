using Entities;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.API.Models.Robot
{
    public class RobotExpAction : CommandBase<IEnumerable<dynamic>>
    {
        private List<cq_levexp> GetLevexps(ObjectContext context)
        {
            return context.db.From("cq_levexp").Result<cq_levexp>();
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            List<cq_levexp> lvl = new List<cq_levexp>();
            this.GetLevexps(context).OrderBy(x=>x.exp).ToList().ForEach(item=> {
                if(lvl.FirstOrDefault(x=>x.Level == item.Level) == null)
                {
                    lvl.Add(item);
                }
            });
            return Success(lvl.Select(x=>
            {
                return new
                {
                    level = x.Level,
                    exp = x.exp
                };
            }));
        }
    }
}