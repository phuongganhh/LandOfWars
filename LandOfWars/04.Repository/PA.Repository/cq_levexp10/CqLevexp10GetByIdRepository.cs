using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexp10GetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_levexp10")
                .Where("cq_levexp10.Level",this.Level)
				.Select(
					"cq_levexp10.Level",
					"cq_levexp10.exp",
					"cq_levexp10.PerAtk",
					"cq_levexp10.OverAdjAtk",
					"cq_levexp10.PerXP",
					"cq_levexp10.OverAdjXP",
					"cq_levexp10.PerXPTeam",
					"cq_levexp10.OverAdjXPTeam",
					"cq_levexp10.KillBonus",
					"cq_levexp10.OverAdjKillBonus",
					"cq_levexp10.metempsychosis",
					"cq_levexp10.UplevTime",
					"cq_levexp10.ExpallMax",
					"cq_levexp10.type",
					"cq_levexp10.FinalExp",
					"cq_levexp10.OverAdjFinal",
					"cq_levexp10.Expall_per"
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