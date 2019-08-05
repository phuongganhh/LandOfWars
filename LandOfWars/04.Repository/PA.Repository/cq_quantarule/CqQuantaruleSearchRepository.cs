using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqQuantaruleSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? LEVEL { get; set; }
		public int? amount { get; set; }
		public int? VALUE { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_quantarule")
				.Select(
					"cq_quantarule.LEVEL",
					"cq_quantarule.amount",
					"cq_quantarule.VALUE"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_quantarule")
                        .Select("cq_quantarule.LEVEL")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.LEVEL != null)
			{
				result = result.WhereLike("cq_quantarule.LEVEL","%" + this.LEVEL.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_quantarule.amount","%" + this.amount.ToString() + "%");
			}
			if(this.VALUE != null)
			{
				result = result.WhereLike("cq_quantarule.VALUE","%" + this.VALUE.ToString() + "%");
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