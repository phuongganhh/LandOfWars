using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqScoreSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? total_scores { get; set; }
		public int? total_kills { get; set; }
		public int? total_deaths { get; set; }
		public int? finishs { get; set; }
		public int? perfect_finishs { get; set; }
		public int? safe_finishs { get; set; }
		public string mission_name { get; set; }
		public int? mission_id { get; set; }
		public int? base_scores { get; set; }
		public int? kills { get; set; }
		public int? deaths { get; set; }
		public int? mission_score { get; set; }
		public string mission1_name { get; set; }
		public int? mission1_scores { get; set; }
		public string mission2_name { get; set; }
		public int? mission2_scores { get; set; }
		public string mission3_name { get; set; }
		public int? mission3_scores { get; set; }
		public string mission4_name { get; set; }
		public int? mission4_scores { get; set; }
		public string mission5_name { get; set; }
		public int? mission5_scores { get; set; }
		public string mission6_name { get; set; }
		public int? mission6_scores { get; set; }
		public string mission7_name { get; set; }
		public int? mission7_scores { get; set; }
		public string mission8_name { get; set; }
		public int? mission8_scores { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_score")
				.Select(
					"cq_score.id",
					"cq_score.total_scores",
					"cq_score.total_kills",
					"cq_score.total_deaths",
					"cq_score.finishs",
					"cq_score.perfect_finishs",
					"cq_score.safe_finishs",
					"cq_score.mission_name",
					"cq_score.mission_id",
					"cq_score.base_scores",
					"cq_score.kills",
					"cq_score.deaths",
					"cq_score.mission_score",
					"cq_score.mission1_name",
					"cq_score.mission1_scores",
					"cq_score.mission2_name",
					"cq_score.mission2_scores",
					"cq_score.mission3_name",
					"cq_score.mission3_scores",
					"cq_score.mission4_name",
					"cq_score.mission4_scores",
					"cq_score.mission5_name",
					"cq_score.mission5_scores",
					"cq_score.mission6_name",
					"cq_score.mission6_scores",
					"cq_score.mission7_name",
					"cq_score.mission7_scores",
					"cq_score.mission8_name",
					"cq_score.mission8_scores"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_score")
                        .Select("cq_score.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_score.id","%" + this.id.ToString() + "%");
			}
			if(this.total_scores != null)
			{
				result = result.WhereLike("cq_score.total_scores","%" + this.total_scores.ToString() + "%");
			}
			if(this.total_kills != null)
			{
				result = result.WhereLike("cq_score.total_kills","%" + this.total_kills.ToString() + "%");
			}
			if(this.total_deaths != null)
			{
				result = result.WhereLike("cq_score.total_deaths","%" + this.total_deaths.ToString() + "%");
			}
			if(this.finishs != null)
			{
				result = result.WhereLike("cq_score.finishs","%" + this.finishs.ToString() + "%");
			}
			if(this.perfect_finishs != null)
			{
				result = result.WhereLike("cq_score.perfect_finishs","%" + this.perfect_finishs.ToString() + "%");
			}
			if(this.safe_finishs != null)
			{
				result = result.WhereLike("cq_score.safe_finishs","%" + this.safe_finishs.ToString() + "%");
			}
			if(this.mission_name != null)
			{
				result = result.WhereLike("cq_score.mission_name","%" + this.mission_name.ToString() + "%");
			}
			if(this.mission_id != null)
			{
				result = result.WhereLike("cq_score.mission_id","%" + this.mission_id.ToString() + "%");
			}
			if(this.base_scores != null)
			{
				result = result.WhereLike("cq_score.base_scores","%" + this.base_scores.ToString() + "%");
			}
			if(this.kills != null)
			{
				result = result.WhereLike("cq_score.kills","%" + this.kills.ToString() + "%");
			}
			if(this.deaths != null)
			{
				result = result.WhereLike("cq_score.deaths","%" + this.deaths.ToString() + "%");
			}
			if(this.mission_score != null)
			{
				result = result.WhereLike("cq_score.mission_score","%" + this.mission_score.ToString() + "%");
			}
			if(this.mission1_name != null)
			{
				result = result.WhereLike("cq_score.mission1_name","%" + this.mission1_name.ToString() + "%");
			}
			if(this.mission1_scores != null)
			{
				result = result.WhereLike("cq_score.mission1_scores","%" + this.mission1_scores.ToString() + "%");
			}
			if(this.mission2_name != null)
			{
				result = result.WhereLike("cq_score.mission2_name","%" + this.mission2_name.ToString() + "%");
			}
			if(this.mission2_scores != null)
			{
				result = result.WhereLike("cq_score.mission2_scores","%" + this.mission2_scores.ToString() + "%");
			}
			if(this.mission3_name != null)
			{
				result = result.WhereLike("cq_score.mission3_name","%" + this.mission3_name.ToString() + "%");
			}
			if(this.mission3_scores != null)
			{
				result = result.WhereLike("cq_score.mission3_scores","%" + this.mission3_scores.ToString() + "%");
			}
			if(this.mission4_name != null)
			{
				result = result.WhereLike("cq_score.mission4_name","%" + this.mission4_name.ToString() + "%");
			}
			if(this.mission4_scores != null)
			{
				result = result.WhereLike("cq_score.mission4_scores","%" + this.mission4_scores.ToString() + "%");
			}
			if(this.mission5_name != null)
			{
				result = result.WhereLike("cq_score.mission5_name","%" + this.mission5_name.ToString() + "%");
			}
			if(this.mission5_scores != null)
			{
				result = result.WhereLike("cq_score.mission5_scores","%" + this.mission5_scores.ToString() + "%");
			}
			if(this.mission6_name != null)
			{
				result = result.WhereLike("cq_score.mission6_name","%" + this.mission6_name.ToString() + "%");
			}
			if(this.mission6_scores != null)
			{
				result = result.WhereLike("cq_score.mission6_scores","%" + this.mission6_scores.ToString() + "%");
			}
			if(this.mission7_name != null)
			{
				result = result.WhereLike("cq_score.mission7_name","%" + this.mission7_name.ToString() + "%");
			}
			if(this.mission7_scores != null)
			{
				result = result.WhereLike("cq_score.mission7_scores","%" + this.mission7_scores.ToString() + "%");
			}
			if(this.mission8_name != null)
			{
				result = result.WhereLike("cq_score.mission8_name","%" + this.mission8_name.ToString() + "%");
			}
			if(this.mission8_scores != null)
			{
				result = result.WhereLike("cq_score.mission8_scores","%" + this.mission8_scores.ToString() + "%");
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