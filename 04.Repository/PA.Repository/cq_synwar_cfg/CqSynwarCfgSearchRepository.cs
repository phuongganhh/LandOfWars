using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSynwarCfgSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? mapid { get; set; }
		public int? type { get; set; }
		public int? number { get; set; }
		public int? coordx { get; set; }
		public int? coordy { get; set; }
		public int? cx { get; set; }
		public int? cy { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_synwar_cfg")
				.Select(
					"cq_synwar_cfg.id",
					"cq_synwar_cfg.mapid",
					"cq_synwar_cfg.type",
					"cq_synwar_cfg.number",
					"cq_synwar_cfg.coordx",
					"cq_synwar_cfg.coordy",
					"cq_synwar_cfg.cx",
					"cq_synwar_cfg.cy"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_synwar_cfg")
                        .Select("cq_synwar_cfg.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_synwar_cfg.id","%" + this.id.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_synwar_cfg.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_synwar_cfg.type","%" + this.type.ToString() + "%");
			}
			if(this.number != null)
			{
				result = result.WhereLike("cq_synwar_cfg.number","%" + this.number.ToString() + "%");
			}
			if(this.coordx != null)
			{
				result = result.WhereLike("cq_synwar_cfg.coordx","%" + this.coordx.ToString() + "%");
			}
			if(this.coordy != null)
			{
				result = result.WhereLike("cq_synwar_cfg.coordy","%" + this.coordy.ToString() + "%");
			}
			if(this.cx != null)
			{
				result = result.WhereLike("cq_synwar_cfg.cx","%" + this.cx.ToString() + "%");
			}
			if(this.cy != null)
			{
				result = result.WhereLike("cq_synwar_cfg.cy","%" + this.cy.ToString() + "%");
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