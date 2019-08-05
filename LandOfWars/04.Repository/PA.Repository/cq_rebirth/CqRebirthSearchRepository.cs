using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRebirthSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? need_prof { get; set; }
		public int? new_prof { get; set; }
		public int? need_level { get; set; }
		public int? new_level { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_rebirth")
				.Select(
					"cq_rebirth.id",
					"cq_rebirth.need_prof",
					"cq_rebirth.new_prof",
					"cq_rebirth.need_level",
					"cq_rebirth.new_level"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_rebirth")
                        .Select("cq_rebirth.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_rebirth.id","%" + this.id.ToString() + "%");
			}
			if(this.need_prof != null)
			{
				result = result.WhereLike("cq_rebirth.need_prof","%" + this.need_prof.ToString() + "%");
			}
			if(this.new_prof != null)
			{
				result = result.WhereLike("cq_rebirth.new_prof","%" + this.new_prof.ToString() + "%");
			}
			if(this.need_level != null)
			{
				result = result.WhereLike("cq_rebirth.need_level","%" + this.need_level.ToString() + "%");
			}
			if(this.new_level != null)
			{
				result = result.WhereLike("cq_rebirth.new_level","%" + this.new_level.ToString() + "%");
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