using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShippathSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? start { get; set; }
		public int? target { get; set; }
		public int? type { get; set; }
		public int? time { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shippath")
				.Select(
					"cq_shippath.id",
					"cq_shippath.start",
					"cq_shippath.target",
					"cq_shippath.type",
					"cq_shippath.time"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shippath")
                        .Select("cq_shippath.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shippath.id","%" + this.id.ToString() + "%");
			}
			if(this.start != null)
			{
				result = result.WhereLike("cq_shippath.start","%" + this.start.ToString() + "%");
			}
			if(this.target != null)
			{
				result = result.WhereLike("cq_shippath.target","%" + this.target.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_shippath.type","%" + this.type.ToString() + "%");
			}
			if(this.time != null)
			{
				result = result.WhereLike("cq_shippath.time","%" + this.time.ToString() + "%");
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