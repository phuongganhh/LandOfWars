using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStudentTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Id { get; set; }
		public int? User_lev_min { get; set; }
		public int? User_lev_max { get; set; }
		public int? Uplevtime { get; set; }
		public int? God_time { get; set; }
		public int? Artifact { get; set; }
		public int? Stone0 { get; set; }
		public int? Stone1 { get; set; }
		public int? Stone2 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_student_type")
				.Select(
					"cq_student_type.Id",
					"cq_student_type.User_lev_min",
					"cq_student_type.User_lev_max",
					"cq_student_type.Uplevtime",
					"cq_student_type.God_time",
					"cq_student_type.Artifact",
					"cq_student_type.Stone0",
					"cq_student_type.Stone1",
					"cq_student_type.Stone2"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_student_type")
                        .Select("cq_student_type.Id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Id != null)
			{
				result = result.WhereLike("cq_student_type.Id","%" + this.Id.ToString() + "%");
			}
			if(this.User_lev_min != null)
			{
				result = result.WhereLike("cq_student_type.User_lev_min","%" + this.User_lev_min.ToString() + "%");
			}
			if(this.User_lev_max != null)
			{
				result = result.WhereLike("cq_student_type.User_lev_max","%" + this.User_lev_max.ToString() + "%");
			}
			if(this.Uplevtime != null)
			{
				result = result.WhereLike("cq_student_type.Uplevtime","%" + this.Uplevtime.ToString() + "%");
			}
			if(this.God_time != null)
			{
				result = result.WhereLike("cq_student_type.God_time","%" + this.God_time.ToString() + "%");
			}
			if(this.Artifact != null)
			{
				result = result.WhereLike("cq_student_type.Artifact","%" + this.Artifact.ToString() + "%");
			}
			if(this.Stone0 != null)
			{
				result = result.WhereLike("cq_student_type.Stone0","%" + this.Stone0.ToString() + "%");
			}
			if(this.Stone1 != null)
			{
				result = result.WhereLike("cq_student_type.Stone1","%" + this.Stone1.ToString() + "%");
			}
			if(this.Stone2 != null)
			{
				result = result.WhereLike("cq_student_type.Stone2","%" + this.Stone2.ToString() + "%");
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