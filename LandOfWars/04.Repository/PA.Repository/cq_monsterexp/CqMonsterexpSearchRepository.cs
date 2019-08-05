using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMonsterexpSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? monstersort { get; set; }
		public int? level { get; set; }
		public int? monsterexp { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_monsterexp")
				.Select(
					"cq_monsterexp.id",
					"cq_monsterexp.monstersort",
					"cq_monsterexp.level",
					"cq_monsterexp.monsterexp"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_monsterexp")
                        .Select("cq_monsterexp.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_monsterexp.id","%" + this.id.ToString() + "%");
			}
			if(this.monstersort != null)
			{
				result = result.WhereLike("cq_monsterexp.monstersort","%" + this.monstersort.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_monsterexp.level","%" + this.level.ToString() + "%");
			}
			if(this.monsterexp != null)
			{
				result = result.WhereLike("cq_monsterexp.monsterexp","%" + this.monsterexp.ToString() + "%");
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