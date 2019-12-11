using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShipmissionPrivateSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? user_id { get; set; }
		public int? mission { get; set; }
		public int? itemtype_id { get; set; }
		public int? status { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shipmission_private")
				.Select(
					"cq_shipmission_private.id",
					"cq_shipmission_private.user_id",
					"cq_shipmission_private.mission",
					"cq_shipmission_private.itemtype_id",
					"cq_shipmission_private.status"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shipmission_private")
                        .Select("cq_shipmission_private.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shipmission_private.id","%" + this.id.ToString() + "%");
			}
			if(this.user_id != null)
			{
				result = result.WhereLike("cq_shipmission_private.user_id","%" + this.user_id.ToString() + "%");
			}
			if(this.mission != null)
			{
				result = result.WhereLike("cq_shipmission_private.mission","%" + this.mission.ToString() + "%");
			}
			if(this.itemtype_id != null)
			{
				result = result.WhereLike("cq_shipmission_private.itemtype_id","%" + this.itemtype_id.ToString() + "%");
			}
			if(this.status != null)
			{
				result = result.WhereLike("cq_shipmission_private.status","%" + this.status.ToString() + "%");
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