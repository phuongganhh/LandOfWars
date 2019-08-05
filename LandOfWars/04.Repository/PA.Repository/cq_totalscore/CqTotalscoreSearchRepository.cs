using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTotalscoreSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? total_scores { get; set; }
		public int? total_kills { get; set; }
		public int? total_deaths { get; set; }
		public int? finishs { get; set; }
		public int? perfect_finishs { get; set; }
		public int? safe_finishs { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_totalscore")
				.Select(
					"cq_totalscore.id",
					"cq_totalscore.total_scores",
					"cq_totalscore.total_kills",
					"cq_totalscore.total_deaths",
					"cq_totalscore.finishs",
					"cq_totalscore.perfect_finishs",
					"cq_totalscore.safe_finishs"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_totalscore")
                        .Select("cq_totalscore.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_totalscore.id","%" + this.id.ToString() + "%");
			}
			if(this.total_scores != null)
			{
				result = result.WhereLike("cq_totalscore.total_scores","%" + this.total_scores.ToString() + "%");
			}
			if(this.total_kills != null)
			{
				result = result.WhereLike("cq_totalscore.total_kills","%" + this.total_kills.ToString() + "%");
			}
			if(this.total_deaths != null)
			{
				result = result.WhereLike("cq_totalscore.total_deaths","%" + this.total_deaths.ToString() + "%");
			}
			if(this.finishs != null)
			{
				result = result.WhereLike("cq_totalscore.finishs","%" + this.finishs.ToString() + "%");
			}
			if(this.perfect_finishs != null)
			{
				result = result.WhereLike("cq_totalscore.perfect_finishs","%" + this.perfect_finishs.ToString() + "%");
			}
			if(this.safe_finishs != null)
			{
				result = result.WhereLike("cq_totalscore.safe_finishs","%" + this.safe_finishs.ToString() + "%");
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