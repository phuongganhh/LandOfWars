using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqVipUsetimesSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? account_id { get; set; }
		public int? vip_lev { get; set; }
		public int? type { get; set; }
		public int? data1 { get; set; }
		public int? active_date { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_vip_usetimes")
				.Select(
					"cq_vip_usetimes.id",
					"cq_vip_usetimes.account_id",
					"cq_vip_usetimes.vip_lev",
					"cq_vip_usetimes.type",
					"cq_vip_usetimes.data1",
					"cq_vip_usetimes.active_date"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_vip_usetimes")
                        .Select("cq_vip_usetimes.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_vip_usetimes.id","%" + this.id.ToString() + "%");
			}
			if(this.account_id != null)
			{
				result = result.WhereLike("cq_vip_usetimes.account_id","%" + this.account_id.ToString() + "%");
			}
			if(this.vip_lev != null)
			{
				result = result.WhereLike("cq_vip_usetimes.vip_lev","%" + this.vip_lev.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_vip_usetimes.type","%" + this.type.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_vip_usetimes.data1","%" + this.data1.ToString() + "%");
			}
			if(this.active_date != null)
			{
				result = result.WhereLike("cq_vip_usetimes.active_date","%" + this.active_date.ToString() + "%");
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