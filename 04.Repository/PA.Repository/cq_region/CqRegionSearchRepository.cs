using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRegionSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? mapid { get; set; }
		public int? type { get; set; }
		public int? bound_x { get; set; }
		public int? bound_y { get; set; }
		public int? bound_cx { get; set; }
		public int? bound_cy { get; set; }
		public string datastr { get; set; }
		public int? data0 { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? data3 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_region")
				.Select(
					"cq_region.id",
					"cq_region.mapid",
					"cq_region.type",
					"cq_region.bound_x",
					"cq_region.bound_y",
					"cq_region.bound_cx",
					"cq_region.bound_cy",
					"cq_region.datastr",
					"cq_region.data0",
					"cq_region.data1",
					"cq_region.data2",
					"cq_region.data3"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_region")
                        .Select("cq_region.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_region.id","%" + this.id.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_region.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_region.type","%" + this.type.ToString() + "%");
			}
			if(this.bound_x != null)
			{
				result = result.WhereLike("cq_region.bound_x","%" + this.bound_x.ToString() + "%");
			}
			if(this.bound_y != null)
			{
				result = result.WhereLike("cq_region.bound_y","%" + this.bound_y.ToString() + "%");
			}
			if(this.bound_cx != null)
			{
				result = result.WhereLike("cq_region.bound_cx","%" + this.bound_cx.ToString() + "%");
			}
			if(this.bound_cy != null)
			{
				result = result.WhereLike("cq_region.bound_cy","%" + this.bound_cy.ToString() + "%");
			}
			if(this.datastr != null)
			{
				result = result.WhereLike("cq_region.datastr","%" + this.datastr.ToString() + "%");
			}
			if(this.data0 != null)
			{
				result = result.WhereLike("cq_region.data0","%" + this.data0.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_region.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_region.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_region.data3","%" + this.data3.ToString() + "%");
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