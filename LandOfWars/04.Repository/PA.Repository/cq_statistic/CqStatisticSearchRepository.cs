using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStatisticSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? iduser { get; set; }
		public int? event_type { get; set; }
		public int? DATA { get; set; }
		public int? eventime { get; set; }
		public int? ownertype { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_statistic")
				.Select(
					"cq_statistic.id",
					"cq_statistic.iduser",
					"cq_statistic.event_type",
					"cq_statistic.DATA",
					"cq_statistic.eventime",
					"cq_statistic.ownertype"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_statistic")
                        .Select("cq_statistic.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_statistic.id","%" + this.id.ToString() + "%");
			}
			if(this.iduser != null)
			{
				result = result.WhereLike("cq_statistic.iduser","%" + this.iduser.ToString() + "%");
			}
			if(this.event_type != null)
			{
				result = result.WhereLike("cq_statistic.event_type","%" + this.event_type.ToString() + "%");
			}
			if(this.DATA != null)
			{
				result = result.WhereLike("cq_statistic.DATA","%" + this.DATA.ToString() + "%");
			}
			if(this.eventime != null)
			{
				result = result.WhereLike("cq_statistic.eventime","%" + this.eventime.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_statistic.ownertype","%" + this.ownertype.ToString() + "%");
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