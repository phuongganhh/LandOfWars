using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexp100GetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public string Level { get; set; }
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
                .From("cq_levexp100")
                .Where("cq_levexp100.Level",this.Level)
				.Select(
					"cq_levexp100.Level",
					"cq_levexp100.exp",
					"cq_levexp100.PerAtk",
					"cq_levexp100.OverAdjAtk",
					"cq_levexp100.PerXP",
					"cq_levexp100.OverAdjXP",
					"cq_levexp100.PerXPTeam",
					"cq_levexp100.OverAdjXPTeam",
					"cq_levexp100.KillBonus",
					"cq_levexp100.OverAdjKillBonus",
					"cq_levexp100.metempsychosis",
					"cq_levexp100.UplevTime",
					"cq_levexp100.ExpallMax",
					"cq_levexp100.type",
					"cq_levexp100.FinalExp",
					"cq_levexp100.OverAdjFinal",
					"cq_levexp100.Expall_per"
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