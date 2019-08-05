using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTitleSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string ownertype { get; set; }
		public int? ownerid { get; set; }
		public int? playerid { get; set; }
		public int? type { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_title")
				.Select(
					"cq_title.id",
					"cq_title.ownertype",
					"cq_title.ownerid",
					"cq_title.playerid",
					"cq_title.type"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_title")
                        .Select("cq_title.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_title.id","%" + this.id.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_title.ownertype","%" + this.ownertype.ToString() + "%");
			}
			if(this.ownerid != null)
			{
				result = result.WhereLike("cq_title.ownerid","%" + this.ownerid.ToString() + "%");
			}
			if(this.playerid != null)
			{
				result = result.WhereLike("cq_title.playerid","%" + this.playerid.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_title.type","%" + this.type.ToString() + "%");
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