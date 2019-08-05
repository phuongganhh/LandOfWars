using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexp10SearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public string Level { get; set; }
		public string exp { get; set; }
		public string PerAtk { get; set; }
		public string OverAdjAtk { get; set; }
		public string PerXP { get; set; }
		public string OverAdjXP { get; set; }
		public string PerXPTeam { get; set; }
		public string OverAdjXPTeam { get; set; }
		public string KillBonus { get; set; }
		public string OverAdjKillBonus { get; set; }
		public string metempsychosis { get; set; }
		public string UplevTime { get; set; }
		public string ExpallMax { get; set; }
		public string type { get; set; }
		public string FinalExp { get; set; }
		public string OverAdjFinal { get; set; }
		public string Expall_per { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_levexp10")
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
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_levexp10")
                        .Select("cq_levexp10.Level")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Level != null)
			{
				result = result.WhereLike("cq_levexp10.Level","%" + this.Level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_levexp10.exp","%" + this.exp.ToString() + "%");
			}
			if(this.PerAtk != null)
			{
				result = result.WhereLike("cq_levexp10.PerAtk","%" + this.PerAtk.ToString() + "%");
			}
			if(this.OverAdjAtk != null)
			{
				result = result.WhereLike("cq_levexp10.OverAdjAtk","%" + this.OverAdjAtk.ToString() + "%");
			}
			if(this.PerXP != null)
			{
				result = result.WhereLike("cq_levexp10.PerXP","%" + this.PerXP.ToString() + "%");
			}
			if(this.OverAdjXP != null)
			{
				result = result.WhereLike("cq_levexp10.OverAdjXP","%" + this.OverAdjXP.ToString() + "%");
			}
			if(this.PerXPTeam != null)
			{
				result = result.WhereLike("cq_levexp10.PerXPTeam","%" + this.PerXPTeam.ToString() + "%");
			}
			if(this.OverAdjXPTeam != null)
			{
				result = result.WhereLike("cq_levexp10.OverAdjXPTeam","%" + this.OverAdjXPTeam.ToString() + "%");
			}
			if(this.KillBonus != null)
			{
				result = result.WhereLike("cq_levexp10.KillBonus","%" + this.KillBonus.ToString() + "%");
			}
			if(this.OverAdjKillBonus != null)
			{
				result = result.WhereLike("cq_levexp10.OverAdjKillBonus","%" + this.OverAdjKillBonus.ToString() + "%");
			}
			if(this.metempsychosis != null)
			{
				result = result.WhereLike("cq_levexp10.metempsychosis","%" + this.metempsychosis.ToString() + "%");
			}
			if(this.UplevTime != null)
			{
				result = result.WhereLike("cq_levexp10.UplevTime","%" + this.UplevTime.ToString() + "%");
			}
			if(this.ExpallMax != null)
			{
				result = result.WhereLike("cq_levexp10.ExpallMax","%" + this.ExpallMax.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_levexp10.type","%" + this.type.ToString() + "%");
			}
			if(this.FinalExp != null)
			{
				result = result.WhereLike("cq_levexp10.FinalExp","%" + this.FinalExp.ToString() + "%");
			}
			if(this.OverAdjFinal != null)
			{
				result = result.WhereLike("cq_levexp10.OverAdjFinal","%" + this.OverAdjFinal.ToString() + "%");
			}
			if(this.Expall_per != null)
			{
				result = result.WhereLike("cq_levexp10.Expall_per","%" + this.Expall_per.ToString() + "%");
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