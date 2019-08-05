using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUnlawfulSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? ID { get; set; }
		public string word { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_unlawful")
				.Select(
					"cq_unlawful.ID",
					"cq_unlawful.word"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_unlawful")
                        .Select("cq_unlawful.ID")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.ID != null)
			{
				result = result.WhereLike("cq_unlawful.ID","%" + this.ID.ToString() + "%");
			}
			if(this.word != null)
			{
				result = result.WhereLike("cq_unlawful.word","%" + this.word.ToString() + "%");
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