using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqForgeGemSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? gem_type { get; set; }
		public int? forge_type { get; set; }
		public int? quality_luck { get; set; }
		public int? chance { get; set; }
		public int? append_chance { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_forge_gem")
				.Select(
					"cq_forge_gem.id",
					"cq_forge_gem.gem_type",
					"cq_forge_gem.forge_type",
					"cq_forge_gem.quality_luck",
					"cq_forge_gem.chance",
					"cq_forge_gem.append_chance"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_forge_gem")
                        .Select("cq_forge_gem.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_forge_gem.id","%" + this.id.ToString() + "%");
			}
			if(this.gem_type != null)
			{
				result = result.WhereLike("cq_forge_gem.gem_type","%" + this.gem_type.ToString() + "%");
			}
			if(this.forge_type != null)
			{
				result = result.WhereLike("cq_forge_gem.forge_type","%" + this.forge_type.ToString() + "%");
			}
			if(this.quality_luck != null)
			{
				result = result.WhereLike("cq_forge_gem.quality_luck","%" + this.quality_luck.ToString() + "%");
			}
			if(this.chance != null)
			{
				result = result.WhereLike("cq_forge_gem.chance","%" + this.chance.ToString() + "%");
			}
			if(this.append_chance != null)
			{
				result = result.WhereLike("cq_forge_gem.append_chance","%" + this.append_chance.ToString() + "%");
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