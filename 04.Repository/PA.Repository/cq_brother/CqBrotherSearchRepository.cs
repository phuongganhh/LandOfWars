using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqBrotherSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Create_time { get; set; }
		public int? Amount { get; set; }
		public string Name { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_brother")
				.Select(
					"cq_brother.id",
					"cq_brother.Create_time",
					"cq_brother.Amount",
					"cq_brother.Name"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_brother")
                        .Select("cq_brother.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_brother.id","%" + this.id.ToString() + "%");
			}
			if(this.Create_time != null)
			{
				result = result.WhereLike("cq_brother.Create_time","%" + this.Create_time.ToString() + "%");
			}
			if(this.Amount != null)
			{
				result = result.WhereLike("cq_brother.Amount","%" + this.Amount.ToString() + "%");
			}
			if(this.Name != null)
			{
				result = result.WhereLike("cq_brother.Name","%" + this.Name.ToString() + "%");
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