using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqArtifactDropShapeChanceSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Type { get; set; }
		public int? shapeminsize { get; set; }
		public int? chance { get; set; }
		public int? Function_id { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_artifact_drop_shape_chance")
				.Select(
					"cq_artifact_drop_shape_chance.id",
					"cq_artifact_drop_shape_chance.Type",
					"cq_artifact_drop_shape_chance.shapeminsize",
					"cq_artifact_drop_shape_chance.chance",
					"cq_artifact_drop_shape_chance.Function_id"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_artifact_drop_shape_chance")
                        .Select("cq_artifact_drop_shape_chance.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_artifact_drop_shape_chance.id","%" + this.id.ToString() + "%");
			}
			if(this.Type != null)
			{
				result = result.WhereLike("cq_artifact_drop_shape_chance.Type","%" + this.Type.ToString() + "%");
			}
			if(this.shapeminsize != null)
			{
				result = result.WhereLike("cq_artifact_drop_shape_chance.shapeminsize","%" + this.shapeminsize.ToString() + "%");
			}
			if(this.chance != null)
			{
				result = result.WhereLike("cq_artifact_drop_shape_chance.chance","%" + this.chance.ToString() + "%");
			}
			if(this.Function_id != null)
			{
				result = result.WhereLike("cq_artifact_drop_shape_chance.Function_id","%" + this.Function_id.ToString() + "%");
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