using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLifeskilltypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Id { get; set; }
		public int? Type { get; set; }
		public int? Sort { get; set; }
		public string Name { get; set; }
		public int? Multi { get; set; }
		public int? Target { get; set; }
		public int? Level { get; set; }
		public int? consume_type { get; set; }
		public int? consume_amount { get; set; }
		public int? Intone_speed { get; set; }
		public int? Step_secs { get; set; }
		public int? Delay_ms { get; set; }
		public int? Range { get; set; }
		public int? Distance { get; set; }
		public int? Status { get; set; }
		public int? Need_prof { get; set; }
		public int? Need_exp { get; set; }
		public int? Auto_uplev { get; set; }
		public int? Need_level { get; set; }
		public int? Auto_learn { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_lifeskilltype")
				.Select(
					"cq_lifeskilltype.Id",
					"cq_lifeskilltype.Type",
					"cq_lifeskilltype.Sort",
					"cq_lifeskilltype.Name",
					"cq_lifeskilltype.Multi",
					"cq_lifeskilltype.Target",
					"cq_lifeskilltype.Level",
					"cq_lifeskilltype.consume_type",
					"cq_lifeskilltype.consume_amount",
					"cq_lifeskilltype.Intone_speed",
					"cq_lifeskilltype.Step_secs",
					"cq_lifeskilltype.Delay_ms",
					"cq_lifeskilltype.Range",
					"cq_lifeskilltype.Distance",
					"cq_lifeskilltype.Status",
					"cq_lifeskilltype.Need_prof",
					"cq_lifeskilltype.Need_exp",
					"cq_lifeskilltype.Auto_uplev",
					"cq_lifeskilltype.Need_level",
					"cq_lifeskilltype.Auto_learn"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_lifeskilltype")
                        .Select("cq_lifeskilltype.Id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Id != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Id","%" + this.Id.ToString() + "%");
			}
			if(this.Type != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Type","%" + this.Type.ToString() + "%");
			}
			if(this.Sort != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Sort","%" + this.Sort.ToString() + "%");
			}
			if(this.Name != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Name","%" + this.Name.ToString() + "%");
			}
			if(this.Multi != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Multi","%" + this.Multi.ToString() + "%");
			}
			if(this.Target != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Target","%" + this.Target.ToString() + "%");
			}
			if(this.Level != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Level","%" + this.Level.ToString() + "%");
			}
			if(this.consume_type != null)
			{
				result = result.WhereLike("cq_lifeskilltype.consume_type","%" + this.consume_type.ToString() + "%");
			}
			if(this.consume_amount != null)
			{
				result = result.WhereLike("cq_lifeskilltype.consume_amount","%" + this.consume_amount.ToString() + "%");
			}
			if(this.Intone_speed != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Intone_speed","%" + this.Intone_speed.ToString() + "%");
			}
			if(this.Step_secs != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Step_secs","%" + this.Step_secs.ToString() + "%");
			}
			if(this.Delay_ms != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Delay_ms","%" + this.Delay_ms.ToString() + "%");
			}
			if(this.Range != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Range","%" + this.Range.ToString() + "%");
			}
			if(this.Distance != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Distance","%" + this.Distance.ToString() + "%");
			}
			if(this.Status != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Status","%" + this.Status.ToString() + "%");
			}
			if(this.Need_prof != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Need_prof","%" + this.Need_prof.ToString() + "%");
			}
			if(this.Need_exp != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Need_exp","%" + this.Need_exp.ToString() + "%");
			}
			if(this.Auto_uplev != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Auto_uplev","%" + this.Auto_uplev.ToString() + "%");
			}
			if(this.Need_level != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Need_level","%" + this.Need_level.ToString() + "%");
			}
			if(this.Auto_learn != null)
			{
				result = result.WhereLike("cq_lifeskilltype.Auto_learn","%" + this.Auto_learn.ToString() + "%");
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