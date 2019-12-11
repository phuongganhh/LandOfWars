using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSysShopPriceSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? province_id { get; set; }
		public int? Price { get; set; }
		public int? Bank { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_sys_shop_price")
				.Select(
					"cq_sys_shop_price.id",
					"cq_sys_shop_price.province_id",
					"cq_sys_shop_price.Price",
					"cq_sys_shop_price.Bank"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_sys_shop_price")
                        .Select("cq_sys_shop_price.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_sys_shop_price.id","%" + this.id.ToString() + "%");
			}
			if(this.province_id != null)
			{
				result = result.WhereLike("cq_sys_shop_price.province_id","%" + this.province_id.ToString() + "%");
			}
			if(this.Price != null)
			{
				result = result.WhereLike("cq_sys_shop_price.Price","%" + this.Price.ToString() + "%");
			}
			if(this.Bank != null)
			{
				result = result.WhereLike("cq_sys_shop_price.Bank","%" + this.Bank.ToString() + "%");
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