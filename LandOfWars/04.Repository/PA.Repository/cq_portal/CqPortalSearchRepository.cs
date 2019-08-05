using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPortalSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? mapid { get; set; }
		public int? portal_idx { get; set; }
		public int? pos_x { get; set; }
		public int? pos_y { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_portal")
				.Select(
					"cq_portal.id",
					"cq_portal.mapid",
					"cq_portal.portal_idx",
					"cq_portal.pos_x",
					"cq_portal.pos_y"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_portal")
                        .Select("cq_portal.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_portal.id","%" + this.id.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_portal.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.portal_idx != null)
			{
				result = result.WhereLike("cq_portal.portal_idx","%" + this.portal_idx.ToString() + "%");
			}
			if(this.pos_x != null)
			{
				result = result.WhereLike("cq_portal.pos_x","%" + this.pos_x.ToString() + "%");
			}
			if(this.pos_y != null)
			{
				result = result.WhereLike("cq_portal.pos_y","%" + this.pos_y.ToString() + "%");
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