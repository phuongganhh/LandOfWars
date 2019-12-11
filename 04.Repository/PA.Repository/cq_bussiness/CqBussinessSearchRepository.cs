using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqBussinessSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? userid { get; set; }
		public int? bussinessid { get; set; }
		public string name { get; set; }
		public int? date { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_bussiness")
				.Select(
					"cq_bussiness.id",
					"cq_bussiness.userid",
					"cq_bussiness.bussinessid",
					"cq_bussiness.name",
					"cq_bussiness.date"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_bussiness")
                        .Select("cq_bussiness.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_bussiness.id","%" + this.id.ToString() + "%");
			}
			if(this.userid != null)
			{
				result = result.WhereLike("cq_bussiness.userid","%" + this.userid.ToString() + "%");
			}
			if(this.bussinessid != null)
			{
				result = result.WhereLike("cq_bussiness.bussinessid","%" + this.bussinessid.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_bussiness.name","%" + this.name.ToString() + "%");
			}
			if(this.date != null)
			{
				result = result.WhereLike("cq_bussiness.date","%" + this.date.ToString() + "%");
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