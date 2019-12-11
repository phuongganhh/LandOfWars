using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAddresslistSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? user_id { get; set; }
		public int? link_id { get; set; }
		public string name { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_addresslist")
				.Select(
					"cq_addresslist.id",
					"cq_addresslist.user_id",
					"cq_addresslist.link_id",
					"cq_addresslist.name"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_addresslist")
                        .Select("cq_addresslist.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_addresslist.id","%" + this.id.ToString() + "%");
			}
			if(this.user_id != null)
			{
				result = result.WhereLike("cq_addresslist.user_id","%" + this.user_id.ToString() + "%");
			}
			if(this.link_id != null)
			{
				result = result.WhereLike("cq_addresslist.link_id","%" + this.link_id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_addresslist.name","%" + this.name.ToString() + "%");
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