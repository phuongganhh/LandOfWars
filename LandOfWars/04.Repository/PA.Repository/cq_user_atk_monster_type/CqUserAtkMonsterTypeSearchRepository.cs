using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserAtkMonsterTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Delta_lev { get; set; }
		public int? Atk_grade { get; set; }
		public int? Atk_times { get; set; }
		public int? Type { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_user_atk_monster_type")
				.Select(
					"cq_user_atk_monster_type.id",
					"cq_user_atk_monster_type.Delta_lev",
					"cq_user_atk_monster_type.Atk_grade",
					"cq_user_atk_monster_type.Atk_times",
					"cq_user_atk_monster_type.Type"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_user_atk_monster_type")
                        .Select("cq_user_atk_monster_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_user_atk_monster_type.id","%" + this.id.ToString() + "%");
			}
			if(this.Delta_lev != null)
			{
				result = result.WhereLike("cq_user_atk_monster_type.Delta_lev","%" + this.Delta_lev.ToString() + "%");
			}
			if(this.Atk_grade != null)
			{
				result = result.WhereLike("cq_user_atk_monster_type.Atk_grade","%" + this.Atk_grade.ToString() + "%");
			}
			if(this.Atk_times != null)
			{
				result = result.WhereLike("cq_user_atk_monster_type.Atk_times","%" + this.Atk_times.ToString() + "%");
			}
			if(this.Type != null)
			{
				result = result.WhereLike("cq_user_atk_monster_type.Type","%" + this.Type.ToString() + "%");
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