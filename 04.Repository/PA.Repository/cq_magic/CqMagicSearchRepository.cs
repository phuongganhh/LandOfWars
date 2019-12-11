using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMagicSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? ownerid { get; set; }
		public int? type { get; set; }
		public int? level { get; set; }
		public int? exp { get; set; }
		public int? unlearn { get; set; }
		public int? old_level { get; set; }
		public int? owner_type { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_magic")
				.Select(
					"cq_magic.id",
					"cq_magic.ownerid",
					"cq_magic.type",
					"cq_magic.level",
					"cq_magic.exp",
					"cq_magic.unlearn",
					"cq_magic.old_level",
					"cq_magic.owner_type"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_magic")
                        .Select("cq_magic.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_magic.id","%" + this.id.ToString() + "%");
			}
			if(this.ownerid != null)
			{
				result = result.WhereLike("cq_magic.ownerid","%" + this.ownerid.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_magic.type","%" + this.type.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_magic.level","%" + this.level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_magic.exp","%" + this.exp.ToString() + "%");
			}
			if(this.unlearn != null)
			{
				result = result.WhereLike("cq_magic.unlearn","%" + this.unlearn.ToString() + "%");
			}
			if(this.old_level != null)
			{
				result = result.WhereLike("cq_magic.old_level","%" + this.old_level.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_magic.owner_type","%" + this.owner_type.ToString() + "%");
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