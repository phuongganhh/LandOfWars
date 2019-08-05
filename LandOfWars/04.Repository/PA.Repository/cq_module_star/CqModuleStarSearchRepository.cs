using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqModuleStarSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Id { get; set; }
		public int? type { get; set; }
		public int? Star_lev { get; set; }
		public int? Req_lev { get; set; }
		public int? Req_artifact { get; set; }
		public int? Req_crystal0 { get; set; }
		public int? Req_crystal1 { get; set; }
		public int? Req_crystal2 { get; set; }
		public int? Req_meteor { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_module_star")
				.Select(
					"cq_module_star.Id",
					"cq_module_star.type",
					"cq_module_star.Star_lev",
					"cq_module_star.Req_lev",
					"cq_module_star.Req_artifact",
					"cq_module_star.Req_crystal0",
					"cq_module_star.Req_crystal1",
					"cq_module_star.Req_crystal2",
					"cq_module_star.Req_meteor"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_module_star")
                        .Select("cq_module_star.Id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Id != null)
			{
				result = result.WhereLike("cq_module_star.Id","%" + this.Id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_module_star.type","%" + this.type.ToString() + "%");
			}
			if(this.Star_lev != null)
			{
				result = result.WhereLike("cq_module_star.Star_lev","%" + this.Star_lev.ToString() + "%");
			}
			if(this.Req_lev != null)
			{
				result = result.WhereLike("cq_module_star.Req_lev","%" + this.Req_lev.ToString() + "%");
			}
			if(this.Req_artifact != null)
			{
				result = result.WhereLike("cq_module_star.Req_artifact","%" + this.Req_artifact.ToString() + "%");
			}
			if(this.Req_crystal0 != null)
			{
				result = result.WhereLike("cq_module_star.Req_crystal0","%" + this.Req_crystal0.ToString() + "%");
			}
			if(this.Req_crystal1 != null)
			{
				result = result.WhereLike("cq_module_star.Req_crystal1","%" + this.Req_crystal1.ToString() + "%");
			}
			if(this.Req_crystal2 != null)
			{
				result = result.WhereLike("cq_module_star.Req_crystal2","%" + this.Req_crystal2.ToString() + "%");
			}
			if(this.Req_meteor != null)
			{
				result = result.WhereLike("cq_module_star.Req_meteor","%" + this.Req_meteor.ToString() + "%");
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