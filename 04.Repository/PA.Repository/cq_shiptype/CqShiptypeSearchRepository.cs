using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShiptypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? mapdoc { get; set; }
		public int? level { get; set; }
		public int? price { get; set; }
		public int? maxplayers { get; set; }
		public int? rows { get; set; }
		public int? cols { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shiptype")
				.Select(
					"cq_shiptype.id",
					"cq_shiptype.name",
					"cq_shiptype.mapdoc",
					"cq_shiptype.level",
					"cq_shiptype.price",
					"cq_shiptype.maxplayers",
					"cq_shiptype.rows",
					"cq_shiptype.cols"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shiptype")
                        .Select("cq_shiptype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shiptype.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_shiptype.name","%" + this.name.ToString() + "%");
			}
			if(this.mapdoc != null)
			{
				result = result.WhereLike("cq_shiptype.mapdoc","%" + this.mapdoc.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_shiptype.level","%" + this.level.ToString() + "%");
			}
			if(this.price != null)
			{
				result = result.WhereLike("cq_shiptype.price","%" + this.price.ToString() + "%");
			}
			if(this.maxplayers != null)
			{
				result = result.WhereLike("cq_shiptype.maxplayers","%" + this.maxplayers.ToString() + "%");
			}
			if(this.rows != null)
			{
				result = result.WhereLike("cq_shiptype.rows","%" + this.rows.ToString() + "%");
			}
			if(this.cols != null)
			{
				result = result.WhereLike("cq_shiptype.cols","%" + this.cols.ToString() + "%");
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