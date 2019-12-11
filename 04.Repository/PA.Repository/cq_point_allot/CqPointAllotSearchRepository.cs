using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPointAllotSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? prof_sort { get; set; }
		public int? level { get; set; }
		public int? force { get; set; }
		public int? Speed { get; set; }
		public int? health { get; set; }
		public int? soul { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_point_allot")
				.Select(
					"cq_point_allot.id",
					"cq_point_allot.prof_sort",
					"cq_point_allot.level",
					"cq_point_allot.force",
					"cq_point_allot.Speed",
					"cq_point_allot.health",
					"cq_point_allot.soul"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_point_allot")
                        .Select("cq_point_allot.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_point_allot.id","%" + this.id.ToString() + "%");
			}
			if(this.prof_sort != null)
			{
				result = result.WhereLike("cq_point_allot.prof_sort","%" + this.prof_sort.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_point_allot.level","%" + this.level.ToString() + "%");
			}
			if(this.force != null)
			{
				result = result.WhereLike("cq_point_allot.force","%" + this.force.ToString() + "%");
			}
			if(this.Speed != null)
			{
				result = result.WhereLike("cq_point_allot.Speed","%" + this.Speed.ToString() + "%");
			}
			if(this.health != null)
			{
				result = result.WhereLike("cq_point_allot.health","%" + this.health.ToString() + "%");
			}
			if(this.soul != null)
			{
				result = result.WhereLike("cq_point_allot.soul","%" + this.soul.ToString() + "%");
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