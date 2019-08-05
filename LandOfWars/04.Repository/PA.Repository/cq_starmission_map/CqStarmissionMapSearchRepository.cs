using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStarmissionMapSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? action { get; set; }
		public int? task { get; set; }
		public int? levelid { get; set; }
		public int? level { get; set; }
		public int? map { get; set; }
		public int? cellx { get; set; }
		public int? celly { get; set; }
		public int? limit_time { get; set; }
		public int? changemap_prize0 { get; set; }
		public int? changemap_prize1 { get; set; }
		public int? finish_prize0 { get; set; }
		public int? finish_prize1 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_starmission_map")
				.Select(
					"cq_starmission_map.id",
					"cq_starmission_map.action",
					"cq_starmission_map.task",
					"cq_starmission_map.levelid",
					"cq_starmission_map.level",
					"cq_starmission_map.map",
					"cq_starmission_map.cellx",
					"cq_starmission_map.celly",
					"cq_starmission_map.limit_time",
					"cq_starmission_map.changemap_prize0",
					"cq_starmission_map.changemap_prize1",
					"cq_starmission_map.finish_prize0",
					"cq_starmission_map.finish_prize1"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_starmission_map")
                        .Select("cq_starmission_map.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_starmission_map.id","%" + this.id.ToString() + "%");
			}
			if(this.action != null)
			{
				result = result.WhereLike("cq_starmission_map.action","%" + this.action.ToString() + "%");
			}
			if(this.task != null)
			{
				result = result.WhereLike("cq_starmission_map.task","%" + this.task.ToString() + "%");
			}
			if(this.levelid != null)
			{
				result = result.WhereLike("cq_starmission_map.levelid","%" + this.levelid.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_starmission_map.level","%" + this.level.ToString() + "%");
			}
			if(this.map != null)
			{
				result = result.WhereLike("cq_starmission_map.map","%" + this.map.ToString() + "%");
			}
			if(this.cellx != null)
			{
				result = result.WhereLike("cq_starmission_map.cellx","%" + this.cellx.ToString() + "%");
			}
			if(this.celly != null)
			{
				result = result.WhereLike("cq_starmission_map.celly","%" + this.celly.ToString() + "%");
			}
			if(this.limit_time != null)
			{
				result = result.WhereLike("cq_starmission_map.limit_time","%" + this.limit_time.ToString() + "%");
			}
			if(this.changemap_prize0 != null)
			{
				result = result.WhereLike("cq_starmission_map.changemap_prize0","%" + this.changemap_prize0.ToString() + "%");
			}
			if(this.changemap_prize1 != null)
			{
				result = result.WhereLike("cq_starmission_map.changemap_prize1","%" + this.changemap_prize1.ToString() + "%");
			}
			if(this.finish_prize0 != null)
			{
				result = result.WhereLike("cq_starmission_map.finish_prize0","%" + this.finish_prize0.ToString() + "%");
			}
			if(this.finish_prize1 != null)
			{
				result = result.WhereLike("cq_starmission_map.finish_prize1","%" + this.finish_prize1.ToString() + "%");
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