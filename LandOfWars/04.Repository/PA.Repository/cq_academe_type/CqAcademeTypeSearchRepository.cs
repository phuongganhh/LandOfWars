using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAcademeTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? map_id { get; set; }
		public int? create_action { get; set; }
		public int? portal0_x { get; set; }
		public int? portal0_y { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_academe_type")
				.Select(
					"cq_academe_type.id",
					"cq_academe_type.map_id",
					"cq_academe_type.create_action",
					"cq_academe_type.portal0_x",
					"cq_academe_type.portal0_y"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_academe_type")
                        .Select("cq_academe_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_academe_type.id","%" + this.id.ToString() + "%");
			}
			if(this.map_id != null)
			{
				result = result.WhereLike("cq_academe_type.map_id","%" + this.map_id.ToString() + "%");
			}
			if(this.create_action != null)
			{
				result = result.WhereLike("cq_academe_type.create_action","%" + this.create_action.ToString() + "%");
			}
			if(this.portal0_x != null)
			{
				result = result.WhereLike("cq_academe_type.portal0_x","%" + this.portal0_x.ToString() + "%");
			}
			if(this.portal0_y != null)
			{
				result = result.WhereLike("cq_academe_type.portal0_y","%" + this.portal0_y.ToString() + "%");
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