using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTutorContributionsSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? tutor_id { get; set; }
		public int? Student_id { get; set; }
		public int? Date { get; set; }
		public int? Uplevtime { get; set; }
		public int? God_time { get; set; }
		public int? Artifact { get; set; }
		public int? Stone0 { get; set; }
		public int? Stone1 { get; set; }
		public int? Stone2 { get; set; }
		public long? Exp { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_tutor_contributions")
				.Select(
					"cq_tutor_contributions.id",
					"cq_tutor_contributions.tutor_id",
					"cq_tutor_contributions.Student_id",
					"cq_tutor_contributions.Date",
					"cq_tutor_contributions.Uplevtime",
					"cq_tutor_contributions.God_time",
					"cq_tutor_contributions.Artifact",
					"cq_tutor_contributions.Stone0",
					"cq_tutor_contributions.Stone1",
					"cq_tutor_contributions.Stone2",
					"cq_tutor_contributions.Exp"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_tutor_contributions")
                        .Select("cq_tutor_contributions.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_tutor_contributions.id","%" + this.id.ToString() + "%");
			}
			if(this.tutor_id != null)
			{
				result = result.WhereLike("cq_tutor_contributions.tutor_id","%" + this.tutor_id.ToString() + "%");
			}
			if(this.Student_id != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Student_id","%" + this.Student_id.ToString() + "%");
			}
			if(this.Date != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Date","%" + this.Date.ToString() + "%");
			}
			if(this.Uplevtime != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Uplevtime","%" + this.Uplevtime.ToString() + "%");
			}
			if(this.God_time != null)
			{
				result = result.WhereLike("cq_tutor_contributions.God_time","%" + this.God_time.ToString() + "%");
			}
			if(this.Artifact != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Artifact","%" + this.Artifact.ToString() + "%");
			}
			if(this.Stone0 != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Stone0","%" + this.Stone0.ToString() + "%");
			}
			if(this.Stone1 != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Stone1","%" + this.Stone1.ToString() + "%");
			}
			if(this.Stone2 != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Stone2","%" + this.Stone2.ToString() + "%");
			}
			if(this.Exp != null)
			{
				result = result.WhereLike("cq_tutor_contributions.Exp","%" + this.Exp.ToString() + "%");
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