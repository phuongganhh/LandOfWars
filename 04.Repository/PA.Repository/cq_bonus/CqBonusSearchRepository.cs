using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqBonusSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? action { get; set; }
		public int? id { get; set; }
		public int? id_account { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_bonus")
				.Select(
					"cq_bonus.action",
					"cq_bonus.id",
					"cq_bonus.id_account"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_bonus")
                        .Select("cq_bonus.action")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.action != null)
			{
				result = result.WhereLike("cq_bonus.action","%" + this.action.ToString() + "%");
			}
			if(this.id != null)
			{
				result = result.WhereLike("cq_bonus.id","%" + this.id.ToString() + "%");
			}
			if(this.id_account != null)
			{
				result = result.WhereLike("cq_bonus.id_account","%" + this.id_account.ToString() + "%");
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