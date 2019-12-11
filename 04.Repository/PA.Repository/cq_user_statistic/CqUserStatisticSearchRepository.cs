using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserStatisticSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? userid { get; set; }
		public string cquser_name { get; set; }
		public int? cquser_accountid { get; set; }
		public int? cquser_level { get; set; }
		public int? kill_count { get; set; }
		public int? event_type { get; set; }
		public int? eventime { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_user_statistic")
				.Select(
					"cq_user_statistic.userid",
					"cq_user_statistic.cquser_name",
					"cq_user_statistic.cquser_accountid",
					"cq_user_statistic.cquser_level",
					"cq_user_statistic.kill_count",
					"cq_user_statistic.event_type",
					"cq_user_statistic.eventime"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_user_statistic")
                        .Select("cq_user_statistic.userid")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.userid != null)
			{
				result = result.WhereLike("cq_user_statistic.userid","%" + this.userid.ToString() + "%");
			}
			if(this.cquser_name != null)
			{
				result = result.WhereLike("cq_user_statistic.cquser_name","%" + this.cquser_name.ToString() + "%");
			}
			if(this.cquser_accountid != null)
			{
				result = result.WhereLike("cq_user_statistic.cquser_accountid","%" + this.cquser_accountid.ToString() + "%");
			}
			if(this.cquser_level != null)
			{
				result = result.WhereLike("cq_user_statistic.cquser_level","%" + this.cquser_level.ToString() + "%");
			}
			if(this.kill_count != null)
			{
				result = result.WhereLike("cq_user_statistic.kill_count","%" + this.kill_count.ToString() + "%");
			}
			if(this.event_type != null)
			{
				result = result.WhereLike("cq_user_statistic.event_type","%" + this.event_type.ToString() + "%");
			}
			if(this.eventime != null)
			{
				result = result.WhereLike("cq_user_statistic.eventime","%" + this.eventime.ToString() + "%");
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