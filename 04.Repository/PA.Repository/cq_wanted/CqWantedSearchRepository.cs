using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWantedSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string target_name { get; set; }
		public int? target_lev { get; set; }
		public int? target_pro { get; set; }
		public int? target_syn { get; set; }
		public string payer { get; set; }
		public int? bounty { get; set; }
		public int? order_time { get; set; }
		public string hunter { get; set; }
		public int? finish_time { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_wanted")
				.Select(
					"cq_wanted.id",
					"cq_wanted.target_name",
					"cq_wanted.target_lev",
					"cq_wanted.target_pro",
					"cq_wanted.target_syn",
					"cq_wanted.payer",
					"cq_wanted.bounty",
					"cq_wanted.order_time",
					"cq_wanted.hunter",
					"cq_wanted.finish_time"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_wanted")
                        .Select("cq_wanted.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_wanted.id","%" + this.id.ToString() + "%");
			}
			if(this.target_name != null)
			{
				result = result.WhereLike("cq_wanted.target_name","%" + this.target_name.ToString() + "%");
			}
			if(this.target_lev != null)
			{
				result = result.WhereLike("cq_wanted.target_lev","%" + this.target_lev.ToString() + "%");
			}
			if(this.target_pro != null)
			{
				result = result.WhereLike("cq_wanted.target_pro","%" + this.target_pro.ToString() + "%");
			}
			if(this.target_syn != null)
			{
				result = result.WhereLike("cq_wanted.target_syn","%" + this.target_syn.ToString() + "%");
			}
			if(this.payer != null)
			{
				result = result.WhereLike("cq_wanted.payer","%" + this.payer.ToString() + "%");
			}
			if(this.bounty != null)
			{
				result = result.WhereLike("cq_wanted.bounty","%" + this.bounty.ToString() + "%");
			}
			if(this.order_time != null)
			{
				result = result.WhereLike("cq_wanted.order_time","%" + this.order_time.ToString() + "%");
			}
			if(this.hunter != null)
			{
				result = result.WhereLike("cq_wanted.hunter","%" + this.hunter.ToString() + "%");
			}
			if(this.finish_time != null)
			{
				result = result.WhereLike("cq_wanted.finish_time","%" + this.finish_time.ToString() + "%");
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