using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexpGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? Level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.Level == null)
            {
                throw new BusinessException("Level is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_levexp")
                .Where("cq_levexp.Level",this.Level)
				.Select(
					"cq_levexp.Level",
					"cq_levexp.exp",
					"cq_levexp.PerAtk",
					"cq_levexp.OverAdjAtk",
					"cq_levexp.PerXP",
					"cq_levexp.OverAdjXP",
					"cq_levexp.PerXPTeam",
					"cq_levexp.OverAdjXPTeam",
					"cq_levexp.KillBonus",
					"cq_levexp.OverAdjKillBonus",
					"cq_levexp.metempsychosis",
					"cq_levexp.UpLevTime",
					"cq_levexp.ExpBallMax",
					"cq_levexp.type",
					"cq_levexp.FinalExp",
					"cq_levexp.OverAdjFinal",
					"cq_levexp.Expball_per"
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