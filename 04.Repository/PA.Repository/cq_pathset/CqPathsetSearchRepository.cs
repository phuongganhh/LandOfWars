using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPathsetSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? id_next { get; set; }
		public int? x { get; set; }
		public int? y { get; set; }
		public int? action { get; set; }
		public string param { get; set; }
		public int? delay { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_pathset")
				.Select(
					"cq_pathset.id",
					"cq_pathset.id_next",
					"cq_pathset.x",
					"cq_pathset.y",
					"cq_pathset.action",
					"cq_pathset.param",
					"cq_pathset.delay"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_pathset")
                        .Select("cq_pathset.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_pathset.id","%" + this.id.ToString() + "%");
			}
			if(this.id_next != null)
			{
				result = result.WhereLike("cq_pathset.id_next","%" + this.id_next.ToString() + "%");
			}
			if(this.x != null)
			{
				result = result.WhereLike("cq_pathset.x","%" + this.x.ToString() + "%");
			}
			if(this.y != null)
			{
				result = result.WhereLike("cq_pathset.y","%" + this.y.ToString() + "%");
			}
			if(this.action != null)
			{
				result = result.WhereLike("cq_pathset.action","%" + this.action.ToString() + "%");
			}
			if(this.param != null)
			{
				result = result.WhereLike("cq_pathset.param","%" + this.param.ToString() + "%");
			}
			if(this.delay != null)
			{
				result = result.WhereLike("cq_pathset.delay","%" + this.delay.ToString() + "%");
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