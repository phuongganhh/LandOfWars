using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAuctionSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? auction_id { get; set; }
		public string auction_player { get; set; }
		public int? item_id { get; set; }
		public int? value { get; set; }
		public int? state { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_auction")
				.Select(
					"cq_auction.id",
					"cq_auction.auction_id",
					"cq_auction.auction_player",
					"cq_auction.item_id",
					"cq_auction.value",
					"cq_auction.state"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_auction")
                        .Select("cq_auction.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_auction.id","%" + this.id.ToString() + "%");
			}
			if(this.auction_id != null)
			{
				result = result.WhereLike("cq_auction.auction_id","%" + this.auction_id.ToString() + "%");
			}
			if(this.auction_player != null)
			{
				result = result.WhereLike("cq_auction.auction_player","%" + this.auction_player.ToString() + "%");
			}
			if(this.item_id != null)
			{
				result = result.WhereLike("cq_auction.item_id","%" + this.item_id.ToString() + "%");
			}
			if(this.value != null)
			{
				result = result.WhereLike("cq_auction.value","%" + this.value.ToString() + "%");
			}
			if(this.state != null)
			{
				result = result.WhereLike("cq_auction.state","%" + this.state.ToString() + "%");
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