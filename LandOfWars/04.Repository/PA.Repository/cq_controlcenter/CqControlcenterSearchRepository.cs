using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqControlcenterSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? player_id { get; set; }
		public int? type { get; set; }
		public int? Item_ID { get; set; }
		public int? Data0 { get; set; }
		public int? Data1 { get; set; }
		public int? Data2 { get; set; }
		public int? Data3 { get; set; }
		public int? Data4 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_controlcenter")
				.Select(
					"cq_controlcenter.id",
					"cq_controlcenter.player_id",
					"cq_controlcenter.type",
					"cq_controlcenter.Item_ID",
					"cq_controlcenter.Data0",
					"cq_controlcenter.Data1",
					"cq_controlcenter.Data2",
					"cq_controlcenter.Data3",
					"cq_controlcenter.Data4"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_controlcenter")
                        .Select("cq_controlcenter.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_controlcenter.id","%" + this.id.ToString() + "%");
			}
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_controlcenter.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_controlcenter.type","%" + this.type.ToString() + "%");
			}
			if(this.Item_ID != null)
			{
				result = result.WhereLike("cq_controlcenter.Item_ID","%" + this.Item_ID.ToString() + "%");
			}
			if(this.Data0 != null)
			{
				result = result.WhereLike("cq_controlcenter.Data0","%" + this.Data0.ToString() + "%");
			}
			if(this.Data1 != null)
			{
				result = result.WhereLike("cq_controlcenter.Data1","%" + this.Data1.ToString() + "%");
			}
			if(this.Data2 != null)
			{
				result = result.WhereLike("cq_controlcenter.Data2","%" + this.Data2.ToString() + "%");
			}
			if(this.Data3 != null)
			{
				result = result.WhereLike("cq_controlcenter.Data3","%" + this.Data3.ToString() + "%");
			}
			if(this.Data4 != null)
			{
				result = result.WhereLike("cq_controlcenter.Data4","%" + this.Data4.ToString() + "%");
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