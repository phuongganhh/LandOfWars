using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqCard3SearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? account_id { get; set; }
		public int? ref_id { get; set; }
		public int? chk_sum { get; set; }
		public int? time_stamp { get; set; }
		public int? used { get; set; }
		public int? flag { get; set; }
		public string ordernumber { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_card3")
				.Select(
					"cq_card3.id",
					"cq_card3.type",
					"cq_card3.account_id",
					"cq_card3.ref_id",
					"cq_card3.chk_sum",
					"cq_card3.time_stamp",
					"cq_card3.used",
					"cq_card3.flag",
					"cq_card3.ordernumber"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_card3")
                        .Select("cq_card3.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_card3.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_card3.type","%" + this.type.ToString() + "%");
			}
			if(this.account_id != null)
			{
				result = result.WhereLike("cq_card3.account_id","%" + this.account_id.ToString() + "%");
			}
			if(this.ref_id != null)
			{
				result = result.WhereLike("cq_card3.ref_id","%" + this.ref_id.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_card3.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.time_stamp != null)
			{
				result = result.WhereLike("cq_card3.time_stamp","%" + this.time_stamp.ToString() + "%");
			}
			if(this.used != null)
			{
				result = result.WhereLike("cq_card3.used","%" + this.used.ToString() + "%");
			}
			if(this.flag != null)
			{
				result = result.WhereLike("cq_card3.flag","%" + this.flag.ToString() + "%");
			}
			if(this.ordernumber != null)
			{
				result = result.WhereLike("cq_card3.ordernumber","%" + this.ordernumber.ToString() + "%");
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