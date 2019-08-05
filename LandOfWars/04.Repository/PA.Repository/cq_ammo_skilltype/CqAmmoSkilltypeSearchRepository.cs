using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAmmoSkilltypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? lev { get; set; }
		public int? exp { get; set; }
		public int? compound_amount { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_ammo_skilltype")
				.Select(
					"cq_ammo_skilltype.id",
					"cq_ammo_skilltype.type",
					"cq_ammo_skilltype.lev",
					"cq_ammo_skilltype.exp",
					"cq_ammo_skilltype.compound_amount"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_ammo_skilltype")
                        .Select("cq_ammo_skilltype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_ammo_skilltype.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_ammo_skilltype.type","%" + this.type.ToString() + "%");
			}
			if(this.lev != null)
			{
				result = result.WhereLike("cq_ammo_skilltype.lev","%" + this.lev.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_ammo_skilltype.exp","%" + this.exp.ToString() + "%");
			}
			if(this.compound_amount != null)
			{
				result = result.WhereLike("cq_ammo_skilltype.compound_amount","%" + this.compound_amount.ToString() + "%");
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