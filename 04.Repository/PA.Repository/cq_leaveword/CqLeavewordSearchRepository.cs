using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLeavewordSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string user_name { get; set; }
		public string send_name { get; set; }
		public string time { get; set; }
		public string words { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_leaveword")
				.Select(
					"cq_leaveword.id",
					"cq_leaveword.user_name",
					"cq_leaveword.send_name",
					"cq_leaveword.time",
					"cq_leaveword.words"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_leaveword")
                        .Select("cq_leaveword.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_leaveword.id","%" + this.id.ToString() + "%");
			}
			if(this.user_name != null)
			{
				result = result.WhereLike("cq_leaveword.user_name","%" + this.user_name.ToString() + "%");
			}
			if(this.send_name != null)
			{
				result = result.WhereLike("cq_leaveword.send_name","%" + this.send_name.ToString() + "%");
			}
			if(this.time != null)
			{
				result = result.WhereLike("cq_leaveword.time","%" + this.time.ToString() + "%");
			}
			if(this.words != null)
			{
				result = result.WhereLike("cq_leaveword.words","%" + this.words.ToString() + "%");
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