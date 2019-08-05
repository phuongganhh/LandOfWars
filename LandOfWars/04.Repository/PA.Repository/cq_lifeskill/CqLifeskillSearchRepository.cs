using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLifeskillSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Id { get; set; }
		public int? Ownerid { get; set; }
		public int? Type { get; set; }
		public int? Level { get; set; }
		public int? Exp { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_lifeskill")
				.Select(
					"cq_lifeskill.Id",
					"cq_lifeskill.Ownerid",
					"cq_lifeskill.Type",
					"cq_lifeskill.Level",
					"cq_lifeskill.Exp"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_lifeskill")
                        .Select("cq_lifeskill.Id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Id != null)
			{
				result = result.WhereLike("cq_lifeskill.Id","%" + this.Id.ToString() + "%");
			}
			if(this.Ownerid != null)
			{
				result = result.WhereLike("cq_lifeskill.Ownerid","%" + this.Ownerid.ToString() + "%");
			}
			if(this.Type != null)
			{
				result = result.WhereLike("cq_lifeskill.Type","%" + this.Type.ToString() + "%");
			}
			if(this.Level != null)
			{
				result = result.WhereLike("cq_lifeskill.Level","%" + this.Level.ToString() + "%");
			}
			if(this.Exp != null)
			{
				result = result.WhereLike("cq_lifeskill.Exp","%" + this.Exp.ToString() + "%");
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