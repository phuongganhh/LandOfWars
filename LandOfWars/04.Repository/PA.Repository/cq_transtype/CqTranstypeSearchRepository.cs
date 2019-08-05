using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTranstypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? sort { get; set; }
		public string name { get; set; }
		public int? data0 { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? data3 { get; set; }
		public int? data4 { get; set; }
		public int? data5 { get; set; }
		public int? data6 { get; set; }
		public int? data7 { get; set; }
		public int? data8 { get; set; }
		public int? data9 { get; set; }
		public int? data10 { get; set; }
		public int? data11 { get; set; }
		public int? data12 { get; set; }
		public int? data13 { get; set; }
		public int? data14 { get; set; }
		public int? data15 { get; set; }
		public int? data16 { get; set; }
		public int? data17 { get; set; }
		public int? data18 { get; set; }
		public int? data19 { get; set; }
		public int? size { get; set; }
		public int? atk_speed { get; set; }
		public int? atk_delay { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_transtype")
				.Select(
					"cq_transtype.id",
					"cq_transtype.sort",
					"cq_transtype.name",
					"cq_transtype.data0",
					"cq_transtype.data1",
					"cq_transtype.data2",
					"cq_transtype.data3",
					"cq_transtype.data4",
					"cq_transtype.data5",
					"cq_transtype.data6",
					"cq_transtype.data7",
					"cq_transtype.data8",
					"cq_transtype.data9",
					"cq_transtype.data10",
					"cq_transtype.data11",
					"cq_transtype.data12",
					"cq_transtype.data13",
					"cq_transtype.data14",
					"cq_transtype.data15",
					"cq_transtype.data16",
					"cq_transtype.data17",
					"cq_transtype.data18",
					"cq_transtype.data19",
					"cq_transtype.size",
					"cq_transtype.atk_speed",
					"cq_transtype.atk_delay"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_transtype")
                        .Select("cq_transtype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_transtype.id","%" + this.id.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_transtype.sort","%" + this.sort.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_transtype.name","%" + this.name.ToString() + "%");
			}
			if(this.data0 != null)
			{
				result = result.WhereLike("cq_transtype.data0","%" + this.data0.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_transtype.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_transtype.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_transtype.data3","%" + this.data3.ToString() + "%");
			}
			if(this.data4 != null)
			{
				result = result.WhereLike("cq_transtype.data4","%" + this.data4.ToString() + "%");
			}
			if(this.data5 != null)
			{
				result = result.WhereLike("cq_transtype.data5","%" + this.data5.ToString() + "%");
			}
			if(this.data6 != null)
			{
				result = result.WhereLike("cq_transtype.data6","%" + this.data6.ToString() + "%");
			}
			if(this.data7 != null)
			{
				result = result.WhereLike("cq_transtype.data7","%" + this.data7.ToString() + "%");
			}
			if(this.data8 != null)
			{
				result = result.WhereLike("cq_transtype.data8","%" + this.data8.ToString() + "%");
			}
			if(this.data9 != null)
			{
				result = result.WhereLike("cq_transtype.data9","%" + this.data9.ToString() + "%");
			}
			if(this.data10 != null)
			{
				result = result.WhereLike("cq_transtype.data10","%" + this.data10.ToString() + "%");
			}
			if(this.data11 != null)
			{
				result = result.WhereLike("cq_transtype.data11","%" + this.data11.ToString() + "%");
			}
			if(this.data12 != null)
			{
				result = result.WhereLike("cq_transtype.data12","%" + this.data12.ToString() + "%");
			}
			if(this.data13 != null)
			{
				result = result.WhereLike("cq_transtype.data13","%" + this.data13.ToString() + "%");
			}
			if(this.data14 != null)
			{
				result = result.WhereLike("cq_transtype.data14","%" + this.data14.ToString() + "%");
			}
			if(this.data15 != null)
			{
				result = result.WhereLike("cq_transtype.data15","%" + this.data15.ToString() + "%");
			}
			if(this.data16 != null)
			{
				result = result.WhereLike("cq_transtype.data16","%" + this.data16.ToString() + "%");
			}
			if(this.data17 != null)
			{
				result = result.WhereLike("cq_transtype.data17","%" + this.data17.ToString() + "%");
			}
			if(this.data18 != null)
			{
				result = result.WhereLike("cq_transtype.data18","%" + this.data18.ToString() + "%");
			}
			if(this.data19 != null)
			{
				result = result.WhereLike("cq_transtype.data19","%" + this.data19.ToString() + "%");
			}
			if(this.size != null)
			{
				result = result.WhereLike("cq_transtype.size","%" + this.size.ToString() + "%");
			}
			if(this.atk_speed != null)
			{
				result = result.WhereLike("cq_transtype.atk_speed","%" + this.atk_speed.ToString() + "%");
			}
			if(this.atk_delay != null)
			{
				result = result.WhereLike("cq_transtype.atk_delay","%" + this.atk_delay.ToString() + "%");
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