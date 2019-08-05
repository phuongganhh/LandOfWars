using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqBrotherAttrSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string Brother_name { get; set; }
		public int? Brother_team_id { get; set; }
		public int? Jion_date { get; set; }
		public int? Sever_date { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_brother_attr")
				.Select(
					"cq_brother_attr.id",
					"cq_brother_attr.Brother_name",
					"cq_brother_attr.Brother_team_id",
					"cq_brother_attr.Jion_date",
					"cq_brother_attr.Sever_date"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_brother_attr")
                        .Select("cq_brother_attr.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_brother_attr.id","%" + this.id.ToString() + "%");
			}
			if(this.Brother_name != null)
			{
				result = result.WhereLike("cq_brother_attr.Brother_name","%" + this.Brother_name.ToString() + "%");
			}
			if(this.Brother_team_id != null)
			{
				result = result.WhereLike("cq_brother_attr.Brother_team_id","%" + this.Brother_team_id.ToString() + "%");
			}
			if(this.Jion_date != null)
			{
				result = result.WhereLike("cq_brother_attr.Jion_date","%" + this.Jion_date.ToString() + "%");
			}
			if(this.Sever_date != null)
			{
				result = result.WhereLike("cq_brother_attr.Sever_date","%" + this.Sever_date.ToString() + "%");
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