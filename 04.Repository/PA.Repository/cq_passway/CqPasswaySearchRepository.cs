using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPasswaySearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? mapid { get; set; }
		public int? passway_idx { get; set; }
		public int? target_mapid { get; set; }
		public int? target_mapportal { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_passway")
				.Select(
					"cq_passway.id",
					"cq_passway.mapid",
					"cq_passway.passway_idx",
					"cq_passway.target_mapid",
					"cq_passway.target_mapportal"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_passway")
                        .Select("cq_passway.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_passway.id","%" + this.id.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_passway.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.passway_idx != null)
			{
				result = result.WhereLike("cq_passway.passway_idx","%" + this.passway_idx.ToString() + "%");
			}
			if(this.target_mapid != null)
			{
				result = result.WhereLike("cq_passway.target_mapid","%" + this.target_mapid.ToString() + "%");
			}
			if(this.target_mapportal != null)
			{
				result = result.WhereLike("cq_passway.target_mapportal","%" + this.target_mapportal.ToString() + "%");
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