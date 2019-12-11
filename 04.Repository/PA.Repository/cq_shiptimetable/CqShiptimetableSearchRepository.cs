using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShiptimetableSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? time { get; set; }
		public int? mission { get; set; }
		public int? type { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shiptimetable")
				.Select(
					"cq_shiptimetable.id",
					"cq_shiptimetable.time",
					"cq_shiptimetable.mission",
					"cq_shiptimetable.type"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shiptimetable")
                        .Select("cq_shiptimetable.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shiptimetable.id","%" + this.id.ToString() + "%");
			}
			if(this.time != null)
			{
				result = result.WhereLike("cq_shiptimetable.time","%" + this.time.ToString() + "%");
			}
			if(this.mission != null)
			{
				result = result.WhereLike("cq_shiptimetable.mission","%" + this.mission.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_shiptimetable.type","%" + this.type.ToString() + "%");
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