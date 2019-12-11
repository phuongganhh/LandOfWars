using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAdvertLogSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? user_id { get; set; }
		public string user_name { get; set; }
		public int? publish_time { get; set; }
		public int? addition { get; set; }
		public string words { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_advert_log")
				.Select(
					"cq_advert_log.id",
					"cq_advert_log.type",
					"cq_advert_log.user_id",
					"cq_advert_log.user_name",
					"cq_advert_log.publish_time",
					"cq_advert_log.addition",
					"cq_advert_log.words"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_advert_log")
                        .Select("cq_advert_log.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_advert_log.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_advert_log.type","%" + this.type.ToString() + "%");
			}
			if(this.user_id != null)
			{
				result = result.WhereLike("cq_advert_log.user_id","%" + this.user_id.ToString() + "%");
			}
			if(this.user_name != null)
			{
				result = result.WhereLike("cq_advert_log.user_name","%" + this.user_name.ToString() + "%");
			}
			if(this.publish_time != null)
			{
				result = result.WhereLike("cq_advert_log.publish_time","%" + this.publish_time.ToString() + "%");
			}
			if(this.addition != null)
			{
				result = result.WhereLike("cq_advert_log.addition","%" + this.addition.ToString() + "%");
			}
			if(this.words != null)
			{
				result = result.WhereLike("cq_advert_log.words","%" + this.words.ToString() + "%");
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