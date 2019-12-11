using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAtkGradeTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Robot_level_min { get; set; }
		public int? Robot_level_max { get; set; }
		public int? Quality { get; set; }
		public int? Addition { get; set; }
		public int? Grade { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_atk_grade_type")
				.Select(
					"cq_atk_grade_type.id",
					"cq_atk_grade_type.Robot_level_min",
					"cq_atk_grade_type.Robot_level_max",
					"cq_atk_grade_type.Quality",
					"cq_atk_grade_type.Addition",
					"cq_atk_grade_type.Grade"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_atk_grade_type")
                        .Select("cq_atk_grade_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_atk_grade_type.id","%" + this.id.ToString() + "%");
			}
			if(this.Robot_level_min != null)
			{
				result = result.WhereLike("cq_atk_grade_type.Robot_level_min","%" + this.Robot_level_min.ToString() + "%");
			}
			if(this.Robot_level_max != null)
			{
				result = result.WhereLike("cq_atk_grade_type.Robot_level_max","%" + this.Robot_level_max.ToString() + "%");
			}
			if(this.Quality != null)
			{
				result = result.WhereLike("cq_atk_grade_type.Quality","%" + this.Quality.ToString() + "%");
			}
			if(this.Addition != null)
			{
				result = result.WhereLike("cq_atk_grade_type.Addition","%" + this.Addition.ToString() + "%");
			}
			if(this.Grade != null)
			{
				result = result.WhereLike("cq_atk_grade_type.Grade","%" + this.Grade.ToString() + "%");
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