using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTradeBuySearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? player_id { get; set; }
		public int? itemtype { get; set; }
		public int? price { get; set; }
		public int? amount { get; set; }
		public int? deposit { get; set; }
		public int? date { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_trade_buy")
				.Select(
					"cq_trade_buy.id",
					"cq_trade_buy.player_id",
					"cq_trade_buy.itemtype",
					"cq_trade_buy.price",
					"cq_trade_buy.amount",
					"cq_trade_buy.deposit",
					"cq_trade_buy.date"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_trade_buy")
                        .Select("cq_trade_buy.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_trade_buy.id","%" + this.id.ToString() + "%");
			}
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_trade_buy.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.itemtype != null)
			{
				result = result.WhereLike("cq_trade_buy.itemtype","%" + this.itemtype.ToString() + "%");
			}
			if(this.price != null)
			{
				result = result.WhereLike("cq_trade_buy.price","%" + this.price.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_trade_buy.amount","%" + this.amount.ToString() + "%");
			}
			if(this.deposit != null)
			{
				result = result.WhereLike("cq_trade_buy.deposit","%" + this.deposit.ToString() + "%");
			}
			if(this.date != null)
			{
				result = result.WhereLike("cq_trade_buy.date","%" + this.date.ToString() + "%");
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