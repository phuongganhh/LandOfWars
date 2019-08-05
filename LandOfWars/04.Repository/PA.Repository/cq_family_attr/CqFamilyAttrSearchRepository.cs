using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqFamilyAttrSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? family_id { get; set; }
		public int? rank { get; set; }
		public int? proffer { get; set; }
		public int? join_date { get; set; }
		public int? auto_execise { get; set; }
		public int? exp_date { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_family_attr")
				.Select(
					"cq_family_attr.id",
					"cq_family_attr.family_id",
					"cq_family_attr.rank",
					"cq_family_attr.proffer",
					"cq_family_attr.join_date",
					"cq_family_attr.auto_execise",
					"cq_family_attr.exp_date"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_family_attr")
                        .Select("cq_family_attr.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_family_attr.id","%" + this.id.ToString() + "%");
			}
			if(this.family_id != null)
			{
				result = result.WhereLike("cq_family_attr.family_id","%" + this.family_id.ToString() + "%");
			}
			if(this.rank != null)
			{
				result = result.WhereLike("cq_family_attr.rank","%" + this.rank.ToString() + "%");
			}
			if(this.proffer != null)
			{
				result = result.WhereLike("cq_family_attr.proffer","%" + this.proffer.ToString() + "%");
			}
			if(this.join_date != null)
			{
				result = result.WhereLike("cq_family_attr.join_date","%" + this.join_date.ToString() + "%");
			}
			if(this.auto_execise != null)
			{
				result = result.WhereLike("cq_family_attr.auto_execise","%" + this.auto_execise.ToString() + "%");
			}
			if(this.exp_date != null)
			{
				result = result.WhereLike("cq_family_attr.exp_date","%" + this.exp_date.ToString() + "%");
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