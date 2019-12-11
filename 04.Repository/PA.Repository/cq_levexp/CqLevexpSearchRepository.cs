using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexpSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Level { get; set; }
		public long? exp { get; set; }
		public int? PerAtk { get; set; }
		public int? OverAdjAtk { get; set; }
		public int? PerXP { get; set; }
		public int? OverAdjXP { get; set; }
		public int? PerXPTeam { get; set; }
		public int? OverAdjXPTeam { get; set; }
		public int? KillBonus { get; set; }
		public int? OverAdjKillBonus { get; set; }
		public int? metempsychosis { get; set; }
		public int? UpLevTime { get; set; }
		public long? ExpBallMax { get; set; }
		public int? type { get; set; }
		public long? FinalExp { get; set; }
		public int? OverAdjFinal { get; set; }
		public int? Expball_per { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_levexp")
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
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_levexp")
                        .Select("cq_levexp.Level")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Level != null)
			{
				result = result.WhereLike("cq_levexp.Level","%" + this.Level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_levexp.exp","%" + this.exp.ToString() + "%");
			}
			if(this.PerAtk != null)
			{
				result = result.WhereLike("cq_levexp.PerAtk","%" + this.PerAtk.ToString() + "%");
			}
			if(this.OverAdjAtk != null)
			{
				result = result.WhereLike("cq_levexp.OverAdjAtk","%" + this.OverAdjAtk.ToString() + "%");
			}
			if(this.PerXP != null)
			{
				result = result.WhereLike("cq_levexp.PerXP","%" + this.PerXP.ToString() + "%");
			}
			if(this.OverAdjXP != null)
			{
				result = result.WhereLike("cq_levexp.OverAdjXP","%" + this.OverAdjXP.ToString() + "%");
			}
			if(this.PerXPTeam != null)
			{
				result = result.WhereLike("cq_levexp.PerXPTeam","%" + this.PerXPTeam.ToString() + "%");
			}
			if(this.OverAdjXPTeam != null)
			{
				result = result.WhereLike("cq_levexp.OverAdjXPTeam","%" + this.OverAdjXPTeam.ToString() + "%");
			}
			if(this.KillBonus != null)
			{
				result = result.WhereLike("cq_levexp.KillBonus","%" + this.KillBonus.ToString() + "%");
			}
			if(this.OverAdjKillBonus != null)
			{
				result = result.WhereLike("cq_levexp.OverAdjKillBonus","%" + this.OverAdjKillBonus.ToString() + "%");
			}
			if(this.metempsychosis != null)
			{
				result = result.WhereLike("cq_levexp.metempsychosis","%" + this.metempsychosis.ToString() + "%");
			}
			if(this.UpLevTime != null)
			{
				result = result.WhereLike("cq_levexp.UpLevTime","%" + this.UpLevTime.ToString() + "%");
			}
			if(this.ExpBallMax != null)
			{
				result = result.WhereLike("cq_levexp.ExpBallMax","%" + this.ExpBallMax.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_levexp.type","%" + this.type.ToString() + "%");
			}
			if(this.FinalExp != null)
			{
				result = result.WhereLike("cq_levexp.FinalExp","%" + this.FinalExp.ToString() + "%");
			}
			if(this.OverAdjFinal != null)
			{
				result = result.WhereLike("cq_levexp.OverAdjFinal","%" + this.OverAdjFinal.ToString() + "%");
			}
			if(this.Expball_per != null)
			{
				result = result.WhereLike("cq_levexp.Expball_per","%" + this.Expball_per.ToString() + "%");
			}

            this.paging.data = result.Result<T>();
            return this.paging;
        }
		protected override void ValidateCore(ObjectContext context)
        {
            this.current_page = this.current_page ?? 1;
            this.page_size = this.page_size ?? context.GetPageSize();
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            if (this.paging == null)
                this.paging = new Paging<T>();
            this.paging.current_page = this.current_page;
            this.paging.page_size = this.page_size;
            this.paging.is_success = true;
            this.paging.msg = "success";
            this.paging.error_code = 0;
        }
        protected override Result<Paging<T>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}