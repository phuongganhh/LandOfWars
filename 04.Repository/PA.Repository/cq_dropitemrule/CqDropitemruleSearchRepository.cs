using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDropitemruleSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? RuleId { get; set; }
		public int? Chance { get; set; }
		public int? Item0 { get; set; }
		public int? Item1 { get; set; }
		public int? Item2 { get; set; }
		public int? Item3 { get; set; }
		public int? Item4 { get; set; }
		public int? Item5 { get; set; }
		public int? Item6 { get; set; }
		public int? Item7 { get; set; }
		public int? Item8 { get; set; }
		public int? Item9 { get; set; }
		public int? Item10 { get; set; }
		public int? Item11 { get; set; }
		public int? Item12 { get; set; }
		public int? Item13 { get; set; }
		public int? Item14 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_dropitemrule")
				.Select(
					"cq_dropitemrule.id",
					"cq_dropitemrule.RuleId",
					"cq_dropitemrule.Chance",
					"cq_dropitemrule.Item0",
					"cq_dropitemrule.Item1",
					"cq_dropitemrule.Item2",
					"cq_dropitemrule.Item3",
					"cq_dropitemrule.Item4",
					"cq_dropitemrule.Item5",
					"cq_dropitemrule.Item6",
					"cq_dropitemrule.Item7",
					"cq_dropitemrule.Item8",
					"cq_dropitemrule.Item9",
					"cq_dropitemrule.Item10",
					"cq_dropitemrule.Item11",
					"cq_dropitemrule.Item12",
					"cq_dropitemrule.Item13",
					"cq_dropitemrule.Item14"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_dropitemrule")
                        .Select("cq_dropitemrule.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_dropitemrule.id","%" + this.id.ToString() + "%");
			}
			if(this.RuleId != null)
			{
				result = result.WhereLike("cq_dropitemrule.RuleId","%" + this.RuleId.ToString() + "%");
			}
			if(this.Chance != null)
			{
				result = result.WhereLike("cq_dropitemrule.Chance","%" + this.Chance.ToString() + "%");
			}
			if(this.Item0 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item0","%" + this.Item0.ToString() + "%");
			}
			if(this.Item1 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item1","%" + this.Item1.ToString() + "%");
			}
			if(this.Item2 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item2","%" + this.Item2.ToString() + "%");
			}
			if(this.Item3 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item3","%" + this.Item3.ToString() + "%");
			}
			if(this.Item4 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item4","%" + this.Item4.ToString() + "%");
			}
			if(this.Item5 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item5","%" + this.Item5.ToString() + "%");
			}
			if(this.Item6 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item6","%" + this.Item6.ToString() + "%");
			}
			if(this.Item7 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item7","%" + this.Item7.ToString() + "%");
			}
			if(this.Item8 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item8","%" + this.Item8.ToString() + "%");
			}
			if(this.Item9 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item9","%" + this.Item9.ToString() + "%");
			}
			if(this.Item10 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item10","%" + this.Item10.ToString() + "%");
			}
			if(this.Item11 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item11","%" + this.Item11.ToString() + "%");
			}
			if(this.Item12 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item12","%" + this.Item12.ToString() + "%");
			}
			if(this.Item13 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item13","%" + this.Item13.ToString() + "%");
			}
			if(this.Item14 != null)
			{
				result = result.WhereLike("cq_dropitemrule.Item14","%" + this.Item14.ToString() + "%");
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