using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? tutor_id { get; set; }
		public string tutor_name { get; set; }
		public int? Student { get; set; }
		public string Student_name { get; set; }
		public int? Betrayal_flag { get; set; }
		public int? LastLogout { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_tutor")
				.Select(
					"cq_tutor.id",
					"cq_tutor.tutor_id",
					"cq_tutor.tutor_name",
					"cq_tutor.Student",
					"cq_tutor.Student_name",
					"cq_tutor.Betrayal_flag",
					"cq_tutor.LastLogout"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_tutor")
                        .Select("cq_tutor.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_tutor.id","%" + this.id.ToString() + "%");
			}
			if(this.tutor_id != null)
			{
				result = result.WhereLike("cq_tutor.tutor_id","%" + this.tutor_id.ToString() + "%");
			}
			if(this.tutor_name != null)
			{
				result = result.WhereLike("cq_tutor.tutor_name","%" + this.tutor_name.ToString() + "%");
			}
			if(this.Student != null)
			{
				result = result.WhereLike("cq_tutor.Student","%" + this.Student.ToString() + "%");
			}
			if(this.Student_name != null)
			{
				result = result.WhereLike("cq_tutor.Student_name","%" + this.Student_name.ToString() + "%");
			}
			if(this.Betrayal_flag != null)
			{
				result = result.WhereLike("cq_tutor.Betrayal_flag","%" + this.Betrayal_flag.ToString() + "%");
			}
			if(this.LastLogout != null)
			{
				result = result.WhereLike("cq_tutor.LastLogout","%" + this.LastLogout.ToString() + "%");
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