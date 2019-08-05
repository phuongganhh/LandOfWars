using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserlevSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? level { get; set; }
		public int? exp { get; set; }
		public int? data { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_userlev")
				.Select(
					"cq_userlev.level",
					"cq_userlev.exp",
					"cq_userlev.data"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_userlev")
                        .Select("cq_userlev.level")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.level != null)
			{
				result = result.WhereLike("cq_userlev.level","%" + this.level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_userlev.exp","%" + this.exp.ToString() + "%");
			}
			if(this.data != null)
			{
				result = result.WhereLike("cq_userlev.data","%" + this.data.ToString() + "%");
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