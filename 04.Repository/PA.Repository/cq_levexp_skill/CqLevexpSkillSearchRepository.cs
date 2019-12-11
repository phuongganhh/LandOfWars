using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexpSkillSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? level { get; set; }
		public long? exp { get; set; }
		public int? Uplevtime { get; set; }
		public long? FinalExp { get; set; }
		public int? OverAdjFinal { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_levexp_skill")
				.Select(
					"cq_levexp_skill.id",
					"cq_levexp_skill.type",
					"cq_levexp_skill.level",
					"cq_levexp_skill.exp",
					"cq_levexp_skill.Uplevtime",
					"cq_levexp_skill.FinalExp",
					"cq_levexp_skill.OverAdjFinal"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_levexp_skill")
                        .Select("cq_levexp_skill.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_levexp_skill.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_levexp_skill.type","%" + this.type.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_levexp_skill.level","%" + this.level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_levexp_skill.exp","%" + this.exp.ToString() + "%");
			}
			if(this.Uplevtime != null)
			{
				result = result.WhereLike("cq_levexp_skill.Uplevtime","%" + this.Uplevtime.ToString() + "%");
			}
			if(this.FinalExp != null)
			{
				result = result.WhereLike("cq_levexp_skill.FinalExp","%" + this.FinalExp.ToString() + "%");
			}
			if(this.OverAdjFinal != null)
			{
				result = result.WhereLike("cq_levexp_skill.OverAdjFinal","%" + this.OverAdjFinal.ToString() + "%");
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