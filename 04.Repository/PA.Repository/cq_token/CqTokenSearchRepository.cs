using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTokenSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? id_source { get; set; }
		public int? id_target { get; set; }
		public int? number { get; set; }
		public int? chk_sum { get; set; }
		public int? time_stamp { get; set; }
		public int? sourceBalance { get; set; }
		public int? targetBalance { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_token")
				.Select(
					"cq_token.id",
					"cq_token.type",
					"cq_token.id_source",
					"cq_token.id_target",
					"cq_token.number",
					"cq_token.chk_sum",
					"cq_token.time_stamp",
					"cq_token.sourceBalance",
					"cq_token.targetBalance"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_token")
                        .Select("cq_token.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_token.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_token.type","%" + this.type.ToString() + "%");
			}
			if(this.id_source != null)
			{
				result = result.WhereLike("cq_token.id_source","%" + this.id_source.ToString() + "%");
			}
			if(this.id_target != null)
			{
				result = result.WhereLike("cq_token.id_target","%" + this.id_target.ToString() + "%");
			}
			if(this.number != null)
			{
				result = result.WhereLike("cq_token.number","%" + this.number.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_token.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.time_stamp != null)
			{
				result = result.WhereLike("cq_token.time_stamp","%" + this.time_stamp.ToString() + "%");
			}
			if(this.sourceBalance != null)
			{
				result = result.WhereLike("cq_token.sourceBalance","%" + this.sourceBalance.ToString() + "%");
			}
			if(this.targetBalance != null)
			{
				result = result.WhereLike("cq_token.targetBalance","%" + this.targetBalance.ToString() + "%");
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