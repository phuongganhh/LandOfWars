using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqArtifactFunctionGradeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Function_std { get; set; }
		public int? Function_Max { get; set; }
		public int? Data_Min { get; set; }
		public int? Data_Max { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_artifact_function_grade")
				.Select(
					"cq_artifact_function_grade.id",
					"cq_artifact_function_grade.Function_std",
					"cq_artifact_function_grade.Function_Max",
					"cq_artifact_function_grade.Data_Min",
					"cq_artifact_function_grade.Data_Max"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_artifact_function_grade")
                        .Select("cq_artifact_function_grade.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_artifact_function_grade.id","%" + this.id.ToString() + "%");
			}
			if(this.Function_std != null)
			{
				result = result.WhereLike("cq_artifact_function_grade.Function_std","%" + this.Function_std.ToString() + "%");
			}
			if(this.Function_Max != null)
			{
				result = result.WhereLike("cq_artifact_function_grade.Function_Max","%" + this.Function_Max.ToString() + "%");
			}
			if(this.Data_Min != null)
			{
				result = result.WhereLike("cq_artifact_function_grade.Data_Min","%" + this.Data_Min.ToString() + "%");
			}
			if(this.Data_Max != null)
			{
				result = result.WhereLike("cq_artifact_function_grade.Data_Max","%" + this.Data_Max.ToString() + "%");
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