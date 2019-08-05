using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Id { get; set; }
		public int? User_lev_min { get; set; }
		public int? User_lev_max { get; set; }
		public int? Student_num { get; set; }
		public int? Battle_lev_share { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_tutor_type")
				.Select(
					"cq_tutor_type.Id",
					"cq_tutor_type.User_lev_min",
					"cq_tutor_type.User_lev_max",
					"cq_tutor_type.Student_num",
					"cq_tutor_type.Battle_lev_share"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_tutor_type")
                        .Select("cq_tutor_type.Id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Id != null)
			{
				result = result.WhereLike("cq_tutor_type.Id","%" + this.Id.ToString() + "%");
			}
			if(this.User_lev_min != null)
			{
				result = result.WhereLike("cq_tutor_type.User_lev_min","%" + this.User_lev_min.ToString() + "%");
			}
			if(this.User_lev_max != null)
			{
				result = result.WhereLike("cq_tutor_type.User_lev_max","%" + this.User_lev_max.ToString() + "%");
			}
			if(this.Student_num != null)
			{
				result = result.WhereLike("cq_tutor_type.Student_num","%" + this.Student_num.ToString() + "%");
			}
			if(this.Battle_lev_share != null)
			{
				result = result.WhereLike("cq_tutor_type.Battle_lev_share","%" + this.Battle_lev_share.ToString() + "%");
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