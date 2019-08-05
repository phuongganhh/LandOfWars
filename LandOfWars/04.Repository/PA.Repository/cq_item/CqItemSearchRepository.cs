using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? ownertype { get; set; }
		public int? owner_id { get; set; }
		public int? player_id { get; set; }
		public int? position { get; set; }
		public int? amount { get; set; }
		public int? ident { get; set; }
		public int? data { get; set; }
		public int? plunder { get; set; }
		public int? sale_time { get; set; }
		public int? chk_sum { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_item")
				.Select(
					"cq_item.id",
					"cq_item.type",
					"cq_item.ownertype",
					"cq_item.owner_id",
					"cq_item.player_id",
					"cq_item.position",
					"cq_item.amount",
					"cq_item.ident",
					"cq_item.data",
					"cq_item.plunder",
					"cq_item.sale_time",
					"cq_item.chk_sum"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_item")
                        .Select("cq_item.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_item.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_item.type","%" + this.type.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_item.ownertype","%" + this.ownertype.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_item.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_item.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.position != null)
			{
				result = result.WhereLike("cq_item.position","%" + this.position.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_item.amount","%" + this.amount.ToString() + "%");
			}
			if(this.ident != null)
			{
				result = result.WhereLike("cq_item.ident","%" + this.ident.ToString() + "%");
			}
			if(this.data != null)
			{
				result = result.WhereLike("cq_item.data","%" + this.data.ToString() + "%");
			}
			if(this.plunder != null)
			{
				result = result.WhereLike("cq_item.plunder","%" + this.plunder.ToString() + "%");
			}
			if(this.sale_time != null)
			{
				result = result.WhereLike("cq_item.sale_time","%" + this.sale_time.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_item.chk_sum","%" + this.chk_sum.ToString() + "%");
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