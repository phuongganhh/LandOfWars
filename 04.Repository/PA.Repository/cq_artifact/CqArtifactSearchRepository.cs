using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqArtifactSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Type { get; set; }
		public int? Rank { get; set; }
		public int? Function_Code { get; set; }
		public int? Chance { get; set; }
		public int? Conflict0 { get; set; }
		public int? Conflict1 { get; set; }
		public int? Conflict2 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_artifact")
				.Select(
					"cq_artifact.id",
					"cq_artifact.Type",
					"cq_artifact.Rank",
					"cq_artifact.Function_Code",
					"cq_artifact.Chance",
					"cq_artifact.Conflict0",
					"cq_artifact.Conflict1",
					"cq_artifact.Conflict2"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_artifact")
                        .Select("cq_artifact.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_artifact.id","%" + this.id.ToString() + "%");
			}
			if(this.Type != null)
			{
				result = result.WhereLike("cq_artifact.Type","%" + this.Type.ToString() + "%");
			}
			if(this.Rank != null)
			{
				result = result.WhereLike("cq_artifact.Rank","%" + this.Rank.ToString() + "%");
			}
			if(this.Function_Code != null)
			{
				result = result.WhereLike("cq_artifact.Function_Code","%" + this.Function_Code.ToString() + "%");
			}
			if(this.Chance != null)
			{
				result = result.WhereLike("cq_artifact.Chance","%" + this.Chance.ToString() + "%");
			}
			if(this.Conflict0 != null)
			{
				result = result.WhereLike("cq_artifact.Conflict0","%" + this.Conflict0.ToString() + "%");
			}
			if(this.Conflict1 != null)
			{
				result = result.WhereLike("cq_artifact.Conflict1","%" + this.Conflict1.ToString() + "%");
			}
			if(this.Conflict2 != null)
			{
				result = result.WhereLike("cq_artifact.Conflict2","%" + this.Conflict2.ToString() + "%");
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