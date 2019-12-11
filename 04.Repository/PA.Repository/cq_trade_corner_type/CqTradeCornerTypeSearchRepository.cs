using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTradeCornerTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? itemtype { get; set; }
		public int? buy_price { get; set; }
		public int? amount { get; set; }
		public int? sell_price { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_trade_corner_type")
				.Select(
					"cq_trade_corner_type.id",
					"cq_trade_corner_type.itemtype",
					"cq_trade_corner_type.buy_price",
					"cq_trade_corner_type.amount",
					"cq_trade_corner_type.sell_price"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_trade_corner_type")
                        .Select("cq_trade_corner_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_trade_corner_type.id","%" + this.id.ToString() + "%");
			}
			if(this.itemtype != null)
			{
				result = result.WhereLike("cq_trade_corner_type.itemtype","%" + this.itemtype.ToString() + "%");
			}
			if(this.buy_price != null)
			{
				result = result.WhereLike("cq_trade_corner_type.buy_price","%" + this.buy_price.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_trade_corner_type.amount","%" + this.amount.ToString() + "%");
			}
			if(this.sell_price != null)
			{
				result = result.WhereLike("cq_trade_corner_type.sell_price","%" + this.sell_price.ToString() + "%");
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