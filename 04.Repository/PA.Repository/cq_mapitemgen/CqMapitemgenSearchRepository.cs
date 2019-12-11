using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMapitemgenSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? mapid { get; set; }
		public int? x { get; set; }
		public int? y { get; set; }
		public int? range { get; set; }
		public int? sec { get; set; }
		public int? itemtype { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_mapitemgen")
				.Select(
					"cq_mapitemgen.id",
					"cq_mapitemgen.mapid",
					"cq_mapitemgen.x",
					"cq_mapitemgen.y",
					"cq_mapitemgen.range",
					"cq_mapitemgen.sec",
					"cq_mapitemgen.itemtype"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_mapitemgen")
                        .Select("cq_mapitemgen.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_mapitemgen.id","%" + this.id.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_mapitemgen.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.x != null)
			{
				result = result.WhereLike("cq_mapitemgen.x","%" + this.x.ToString() + "%");
			}
			if(this.y != null)
			{
				result = result.WhereLike("cq_mapitemgen.y","%" + this.y.ToString() + "%");
			}
			if(this.range != null)
			{
				result = result.WhereLike("cq_mapitemgen.range","%" + this.range.ToString() + "%");
			}
			if(this.sec != null)
			{
				result = result.WhereLike("cq_mapitemgen.sec","%" + this.sec.ToString() + "%");
			}
			if(this.itemtype != null)
			{
				result = result.WhereLike("cq_mapitemgen.itemtype","%" + this.itemtype.ToString() + "%");
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