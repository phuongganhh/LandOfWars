using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqProductionSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? owner_id { get; set; }
		public int? production_type { get; set; }
		public int? state { get; set; }
		public int? time { get; set; }
		public int? residual { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_production")
				.Select(
					"cq_production.id",
					"cq_production.owner_id",
					"cq_production.production_type",
					"cq_production.state",
					"cq_production.time",
					"cq_production.residual"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_production")
                        .Select("cq_production.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_production.id","%" + this.id.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_production.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.production_type != null)
			{
				result = result.WhereLike("cq_production.production_type","%" + this.production_type.ToString() + "%");
			}
			if(this.state != null)
			{
				result = result.WhereLike("cq_production.state","%" + this.state.ToString() + "%");
			}
			if(this.time != null)
			{
				result = result.WhereLike("cq_production.time","%" + this.time.ToString() + "%");
			}
			if(this.residual != null)
			{
				result = result.WhereLike("cq_production.residual","%" + this.residual.ToString() + "%");
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