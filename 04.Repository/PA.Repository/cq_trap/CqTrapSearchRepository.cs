using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTrapSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? look { get; set; }
		public int? owner_id { get; set; }
		public int? map_id { get; set; }
		public int? pos_x { get; set; }
		public int? pos_y { get; set; }
		public int? data { get; set; }
		public int? pos_cx { get; set; }
		public int? pos_cy { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_trap")
				.Select(
					"cq_trap.id",
					"cq_trap.type",
					"cq_trap.look",
					"cq_trap.owner_id",
					"cq_trap.map_id",
					"cq_trap.pos_x",
					"cq_trap.pos_y",
					"cq_trap.data",
					"cq_trap.pos_cx",
					"cq_trap.pos_cy"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_trap")
                        .Select("cq_trap.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_trap.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_trap.type","%" + this.type.ToString() + "%");
			}
			if(this.look != null)
			{
				result = result.WhereLike("cq_trap.look","%" + this.look.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_trap.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.map_id != null)
			{
				result = result.WhereLike("cq_trap.map_id","%" + this.map_id.ToString() + "%");
			}
			if(this.pos_x != null)
			{
				result = result.WhereLike("cq_trap.pos_x","%" + this.pos_x.ToString() + "%");
			}
			if(this.pos_y != null)
			{
				result = result.WhereLike("cq_trap.pos_y","%" + this.pos_y.ToString() + "%");
			}
			if(this.data != null)
			{
				result = result.WhereLike("cq_trap.data","%" + this.data.ToString() + "%");
			}
			if(this.pos_cx != null)
			{
				result = result.WhereLike("cq_trap.pos_cx","%" + this.pos_cx.ToString() + "%");
			}
			if(this.pos_cy != null)
			{
				result = result.WhereLike("cq_trap.pos_cy","%" + this.pos_cy.ToString() + "%");
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