using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPkBonusSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Target { get; set; }
		public string Target_name { get; set; }
		public int? Hunter { get; set; }
		public string Hunter_name { get; set; }
		public int? B_type { get; set; }
		public int? Bonus { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_pk_bonus")
				.Select(
					"cq_pk_bonus.id",
					"cq_pk_bonus.Target",
					"cq_pk_bonus.Target_name",
					"cq_pk_bonus.Hunter",
					"cq_pk_bonus.Hunter_name",
					"cq_pk_bonus.B_type",
					"cq_pk_bonus.Bonus"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_pk_bonus")
                        .Select("cq_pk_bonus.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_pk_bonus.id","%" + this.id.ToString() + "%");
			}
			if(this.Target != null)
			{
				result = result.WhereLike("cq_pk_bonus.Target","%" + this.Target.ToString() + "%");
			}
			if(this.Target_name != null)
			{
				result = result.WhereLike("cq_pk_bonus.Target_name","%" + this.Target_name.ToString() + "%");
			}
			if(this.Hunter != null)
			{
				result = result.WhereLike("cq_pk_bonus.Hunter","%" + this.Hunter.ToString() + "%");
			}
			if(this.Hunter_name != null)
			{
				result = result.WhereLike("cq_pk_bonus.Hunter_name","%" + this.Hunter_name.ToString() + "%");
			}
			if(this.B_type != null)
			{
				result = result.WhereLike("cq_pk_bonus.B_type","%" + this.B_type.ToString() + "%");
			}
			if(this.Bonus != null)
			{
				result = result.WhereLike("cq_pk_bonus.Bonus","%" + this.Bonus.ToString() + "%");
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