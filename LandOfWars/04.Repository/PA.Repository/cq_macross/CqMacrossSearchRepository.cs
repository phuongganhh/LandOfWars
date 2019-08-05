using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMacrossSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? unit1 { get; set; }
		public int? unit2 { get; set; }
		public int? unit3 { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? data3 { get; set; }
		public int? data4 { get; set; }
		public int? data5 { get; set; }
		public int? data6 { get; set; }
		public int? data7 { get; set; }
		public int? data8 { get; set; }
		public string name { get; set; }
		public string fuse { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_macross")
				.Select(
					"cq_macross.id",
					"cq_macross.unit1",
					"cq_macross.unit2",
					"cq_macross.unit3",
					"cq_macross.data1",
					"cq_macross.data2",
					"cq_macross.data3",
					"cq_macross.data4",
					"cq_macross.data5",
					"cq_macross.data6",
					"cq_macross.data7",
					"cq_macross.data8",
					"cq_macross.name",
					"cq_macross.fuse"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_macross")
                        .Select("cq_macross.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_macross.id","%" + this.id.ToString() + "%");
			}
			if(this.unit1 != null)
			{
				result = result.WhereLike("cq_macross.unit1","%" + this.unit1.ToString() + "%");
			}
			if(this.unit2 != null)
			{
				result = result.WhereLike("cq_macross.unit2","%" + this.unit2.ToString() + "%");
			}
			if(this.unit3 != null)
			{
				result = result.WhereLike("cq_macross.unit3","%" + this.unit3.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_macross.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_macross.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_macross.data3","%" + this.data3.ToString() + "%");
			}
			if(this.data4 != null)
			{
				result = result.WhereLike("cq_macross.data4","%" + this.data4.ToString() + "%");
			}
			if(this.data5 != null)
			{
				result = result.WhereLike("cq_macross.data5","%" + this.data5.ToString() + "%");
			}
			if(this.data6 != null)
			{
				result = result.WhereLike("cq_macross.data6","%" + this.data6.ToString() + "%");
			}
			if(this.data7 != null)
			{
				result = result.WhereLike("cq_macross.data7","%" + this.data7.ToString() + "%");
			}
			if(this.data8 != null)
			{
				result = result.WhereLike("cq_macross.data8","%" + this.data8.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_macross.name","%" + this.name.ToString() + "%");
			}
			if(this.fuse != null)
			{
				result = result.WhereLike("cq_macross.fuse","%" + this.fuse.ToString() + "%");
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