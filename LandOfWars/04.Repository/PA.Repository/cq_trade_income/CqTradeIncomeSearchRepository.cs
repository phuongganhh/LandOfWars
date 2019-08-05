using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTradeIncomeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? player_id { get; set; }
		public int? income_emoney { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_trade_income")
				.Select(
					"cq_trade_income.player_id",
					"cq_trade_income.income_emoney"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_trade_income")
                        .Select("cq_trade_income.player_id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_trade_income.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.income_emoney != null)
			{
				result = result.WhereLike("cq_trade_income.income_emoney","%" + this.income_emoney.ToString() + "%");
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