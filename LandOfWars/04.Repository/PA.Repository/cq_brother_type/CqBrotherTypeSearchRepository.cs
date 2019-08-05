using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqBrotherTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? relation_lev { get; set; }
		public int? battle_leb_share { get; set; }
		public int? stay_time { get; set; }
		public int? chgmap_times_limit { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_brother_type")
				.Select(
					"cq_brother_type.id",
					"cq_brother_type.relation_lev",
					"cq_brother_type.battle_leb_share",
					"cq_brother_type.stay_time",
					"cq_brother_type.chgmap_times_limit"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_brother_type")
                        .Select("cq_brother_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_brother_type.id","%" + this.id.ToString() + "%");
			}
			if(this.relation_lev != null)
			{
				result = result.WhereLike("cq_brother_type.relation_lev","%" + this.relation_lev.ToString() + "%");
			}
			if(this.battle_leb_share != null)
			{
				result = result.WhereLike("cq_brother_type.battle_leb_share","%" + this.battle_leb_share.ToString() + "%");
			}
			if(this.stay_time != null)
			{
				result = result.WhereLike("cq_brother_type.stay_time","%" + this.stay_time.ToString() + "%");
			}
			if(this.chgmap_times_limit != null)
			{
				result = result.WhereLike("cq_brother_type.chgmap_times_limit","%" + this.chgmap_times_limit.ToString() + "%");
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