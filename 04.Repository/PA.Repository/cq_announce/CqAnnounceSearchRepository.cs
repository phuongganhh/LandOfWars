using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAnnounceSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? User_id { get; set; }
		public string Name { get; set; }
		public int? level { get; set; }
		public int? tutor_level { get; set; }
		public int? profession { get; set; }
		public string content { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_announce")
				.Select(
					"cq_announce.id",
					"cq_announce.User_id",
					"cq_announce.Name",
					"cq_announce.level",
					"cq_announce.tutor_level",
					"cq_announce.profession",
					"cq_announce.content"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_announce")
                        .Select("cq_announce.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_announce.id","%" + this.id.ToString() + "%");
			}
			if(this.User_id != null)
			{
				result = result.WhereLike("cq_announce.User_id","%" + this.User_id.ToString() + "%");
			}
			if(this.Name != null)
			{
				result = result.WhereLike("cq_announce.Name","%" + this.Name.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_announce.level","%" + this.level.ToString() + "%");
			}
			if(this.tutor_level != null)
			{
				result = result.WhereLike("cq_announce.tutor_level","%" + this.tutor_level.ToString() + "%");
			}
			if(this.profession != null)
			{
				result = result.WhereLike("cq_announce.profession","%" + this.profession.ToString() + "%");
			}
			if(this.content != null)
			{
				result = result.WhereLike("cq_announce.content","%" + this.content.ToString() + "%");
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