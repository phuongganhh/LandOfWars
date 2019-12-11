using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqProductionTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? item { get; set; }
		public int? production_sort { get; set; }
		public int? req_production { get; set; }
		public int? research_type { get; set; }
		public int? research_lv { get; set; }
		public int? lvup_stone { get; set; }
		public int? evolve1 { get; set; }
		public int? evolve2 { get; set; }
		public int? evolve3 { get; set; }
		public int? evolv_stone { get; set; }
		public int? material_lv { get; set; }
		public int? req_amount { get; set; }
		public int? compound_amount { get; set; }
		public int? activation { get; set; }
		public string name { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_production_type")
				.Select(
					"cq_production_type.id",
					"cq_production_type.item",
					"cq_production_type.production_sort",
					"cq_production_type.req_production",
					"cq_production_type.research_type",
					"cq_production_type.research_lv",
					"cq_production_type.lvup_stone",
					"cq_production_type.evolve1",
					"cq_production_type.evolve2",
					"cq_production_type.evolve3",
					"cq_production_type.evolv_stone",
					"cq_production_type.material_lv",
					"cq_production_type.req_amount",
					"cq_production_type.compound_amount",
					"cq_production_type.activation",
					"cq_production_type.name"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_production_type")
                        .Select("cq_production_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_production_type.id","%" + this.id.ToString() + "%");
			}
			if(this.item != null)
			{
				result = result.WhereLike("cq_production_type.item","%" + this.item.ToString() + "%");
			}
			if(this.production_sort != null)
			{
				result = result.WhereLike("cq_production_type.production_sort","%" + this.production_sort.ToString() + "%");
			}
			if(this.req_production != null)
			{
				result = result.WhereLike("cq_production_type.req_production","%" + this.req_production.ToString() + "%");
			}
			if(this.research_type != null)
			{
				result = result.WhereLike("cq_production_type.research_type","%" + this.research_type.ToString() + "%");
			}
			if(this.research_lv != null)
			{
				result = result.WhereLike("cq_production_type.research_lv","%" + this.research_lv.ToString() + "%");
			}
			if(this.lvup_stone != null)
			{
				result = result.WhereLike("cq_production_type.lvup_stone","%" + this.lvup_stone.ToString() + "%");
			}
			if(this.evolve1 != null)
			{
				result = result.WhereLike("cq_production_type.evolve1","%" + this.evolve1.ToString() + "%");
			}
			if(this.evolve2 != null)
			{
				result = result.WhereLike("cq_production_type.evolve2","%" + this.evolve2.ToString() + "%");
			}
			if(this.evolve3 != null)
			{
				result = result.WhereLike("cq_production_type.evolve3","%" + this.evolve3.ToString() + "%");
			}
			if(this.evolv_stone != null)
			{
				result = result.WhereLike("cq_production_type.evolv_stone","%" + this.evolv_stone.ToString() + "%");
			}
			if(this.material_lv != null)
			{
				result = result.WhereLike("cq_production_type.material_lv","%" + this.material_lv.ToString() + "%");
			}
			if(this.req_amount != null)
			{
				result = result.WhereLike("cq_production_type.req_amount","%" + this.req_amount.ToString() + "%");
			}
			if(this.compound_amount != null)
			{
				result = result.WhereLike("cq_production_type.compound_amount","%" + this.compound_amount.ToString() + "%");
			}
			if(this.activation != null)
			{
				result = result.WhereLike("cq_production_type.activation","%" + this.activation.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_production_type.name","%" + this.name.ToString() + "%");
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