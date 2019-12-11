using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShapeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? cx { get; set; }
		public int? cy { get; set; }
		public int? line0 { get; set; }
		public int? line1 { get; set; }
		public int? line2 { get; set; }
		public int? line3 { get; set; }
		public int? line4 { get; set; }
		public int? line5 { get; set; }
		public int? line6 { get; set; }
		public int? line7 { get; set; }
		public int? line8 { get; set; }
		public int? line9 { get; set; }
		public int? Artifact { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shape")
				.Select(
					"cq_shape.id",
					"cq_shape.cx",
					"cq_shape.cy",
					"cq_shape.line0",
					"cq_shape.line1",
					"cq_shape.line2",
					"cq_shape.line3",
					"cq_shape.line4",
					"cq_shape.line5",
					"cq_shape.line6",
					"cq_shape.line7",
					"cq_shape.line8",
					"cq_shape.line9",
					"cq_shape.Artifact"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shape")
                        .Select("cq_shape.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shape.id","%" + this.id.ToString() + "%");
			}
			if(this.cx != null)
			{
				result = result.WhereLike("cq_shape.cx","%" + this.cx.ToString() + "%");
			}
			if(this.cy != null)
			{
				result = result.WhereLike("cq_shape.cy","%" + this.cy.ToString() + "%");
			}
			if(this.line0 != null)
			{
				result = result.WhereLike("cq_shape.line0","%" + this.line0.ToString() + "%");
			}
			if(this.line1 != null)
			{
				result = result.WhereLike("cq_shape.line1","%" + this.line1.ToString() + "%");
			}
			if(this.line2 != null)
			{
				result = result.WhereLike("cq_shape.line2","%" + this.line2.ToString() + "%");
			}
			if(this.line3 != null)
			{
				result = result.WhereLike("cq_shape.line3","%" + this.line3.ToString() + "%");
			}
			if(this.line4 != null)
			{
				result = result.WhereLike("cq_shape.line4","%" + this.line4.ToString() + "%");
			}
			if(this.line5 != null)
			{
				result = result.WhereLike("cq_shape.line5","%" + this.line5.ToString() + "%");
			}
			if(this.line6 != null)
			{
				result = result.WhereLike("cq_shape.line6","%" + this.line6.ToString() + "%");
			}
			if(this.line7 != null)
			{
				result = result.WhereLike("cq_shape.line7","%" + this.line7.ToString() + "%");
			}
			if(this.line8 != null)
			{
				result = result.WhereLike("cq_shape.line8","%" + this.line8.ToString() + "%");
			}
			if(this.line9 != null)
			{
				result = result.WhereLike("cq_shape.line9","%" + this.line9.ToString() + "%");
			}
			if(this.Artifact != null)
			{
				result = result.WhereLike("cq_shape.Artifact","%" + this.Artifact.ToString() + "%");
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