using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMonsterbookSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? userid { get; set; }
		public int? sort { get; set; }
		public int? level { get; set; }
		public int? exp { get; set; }
		public int? total { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_monsterbook")
				.Select(
					"cq_monsterbook.id",
					"cq_monsterbook.userid",
					"cq_monsterbook.sort",
					"cq_monsterbook.level",
					"cq_monsterbook.exp",
					"cq_monsterbook.total"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_monsterbook")
                        .Select("cq_monsterbook.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_monsterbook.id","%" + this.id.ToString() + "%");
			}
			if(this.userid != null)
			{
				result = result.WhereLike("cq_monsterbook.userid","%" + this.userid.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_monsterbook.sort","%" + this.sort.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_monsterbook.level","%" + this.level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_monsterbook.exp","%" + this.exp.ToString() + "%");
			}
			if(this.total != null)
			{
				result = result.WhereLike("cq_monsterbook.total","%" + this.total.ToString() + "%");
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