using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorBattleLimitTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Battle_lev_limit { get; set; }
		public int? family_battle_limit { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_tutor_battle_limit_type")
				.Select(
					"cq_tutor_battle_limit_type.id",
					"cq_tutor_battle_limit_type.Battle_lev_limit",
					"cq_tutor_battle_limit_type.family_battle_limit"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_tutor_battle_limit_type")
                        .Select("cq_tutor_battle_limit_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_tutor_battle_limit_type.id","%" + this.id.ToString() + "%");
			}
			if(this.Battle_lev_limit != null)
			{
				result = result.WhereLike("cq_tutor_battle_limit_type.Battle_lev_limit","%" + this.Battle_lev_limit.ToString() + "%");
			}
			if(this.family_battle_limit != null)
			{
				result = result.WhereLike("cq_tutor_battle_limit_type.family_battle_limit","%" + this.family_battle_limit.ToString() + "%");
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