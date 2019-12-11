using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqNpcIncomeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? npc_id { get; set; }
		public int? owner_id { get; set; }
		public int? owner_type { get; set; }
		public long? income_exp { get; set; }
		public long? income_money { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_npc_income")
				.Select(
					"cq_npc_income.id",
					"cq_npc_income.npc_id",
					"cq_npc_income.owner_id",
					"cq_npc_income.owner_type",
					"cq_npc_income.income_exp",
					"cq_npc_income.income_money"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_npc_income")
                        .Select("cq_npc_income.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_npc_income.id","%" + this.id.ToString() + "%");
			}
			if(this.npc_id != null)
			{
				result = result.WhereLike("cq_npc_income.npc_id","%" + this.npc_id.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_npc_income.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_npc_income.owner_type","%" + this.owner_type.ToString() + "%");
			}
			if(this.income_exp != null)
			{
				result = result.WhereLike("cq_npc_income.income_exp","%" + this.income_exp.ToString() + "%");
			}
			if(this.income_money != null)
			{
				result = result.WhereLike("cq_npc_income.income_money","%" + this.income_money.ToString() + "%");
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