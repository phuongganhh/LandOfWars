using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRbnTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Id { get; set; }
		public int? Rbn_times { get; set; }
		public int? Req_level { get; set; }
		public int? Mete_level { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_rbn_type")
				.Select(
					"cq_rbn_type.Id",
					"cq_rbn_type.Rbn_times",
					"cq_rbn_type.Req_level",
					"cq_rbn_type.Mete_level"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_rbn_type")
                        .Select("cq_rbn_type.Id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Id != null)
			{
				result = result.WhereLike("cq_rbn_type.Id","%" + this.Id.ToString() + "%");
			}
			if(this.Rbn_times != null)
			{
				result = result.WhereLike("cq_rbn_type.Rbn_times","%" + this.Rbn_times.ToString() + "%");
			}
			if(this.Req_level != null)
			{
				result = result.WhereLike("cq_rbn_type.Req_level","%" + this.Req_level.ToString() + "%");
			}
			if(this.Mete_level != null)
			{
				result = result.WhereLike("cq_rbn_type.Mete_level","%" + this.Mete_level.ToString() + "%");
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