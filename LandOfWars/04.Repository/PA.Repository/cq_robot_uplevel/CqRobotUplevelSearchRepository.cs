using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobotUplevelSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? origin_type { get; set; }
		public int? req1 { get; set; }
		public int? req2 { get; set; }
		public int? req3 { get; set; }
		public int? req4 { get; set; }
		public int? req5 { get; set; }
		public int? req6 { get; set; }
		public int? add1 { get; set; }
		public int? add2 { get; set; }
		public int? add3 { get; set; }
		public int? add4 { get; set; }
		public int? add5 { get; set; }
		public int? add6 { get; set; }
		public int? equip_pos { get; set; }
		public int? equip_itemtype { get; set; }
		public int? add_register { get; set; }
		public int? req_level { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_robot_uplevel")
				.Select(
					"cq_robot_uplevel.id",
					"cq_robot_uplevel.origin_type",
					"cq_robot_uplevel.req1",
					"cq_robot_uplevel.req2",
					"cq_robot_uplevel.req3",
					"cq_robot_uplevel.req4",
					"cq_robot_uplevel.req5",
					"cq_robot_uplevel.req6",
					"cq_robot_uplevel.add1",
					"cq_robot_uplevel.add2",
					"cq_robot_uplevel.add3",
					"cq_robot_uplevel.add4",
					"cq_robot_uplevel.add5",
					"cq_robot_uplevel.add6",
					"cq_robot_uplevel.equip_pos",
					"cq_robot_uplevel.equip_itemtype",
					"cq_robot_uplevel.add_register",
					"cq_robot_uplevel.req_level"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_robot_uplevel")
                        .Select("cq_robot_uplevel.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_robot_uplevel.id","%" + this.id.ToString() + "%");
			}
			if(this.origin_type != null)
			{
				result = result.WhereLike("cq_robot_uplevel.origin_type","%" + this.origin_type.ToString() + "%");
			}
			if(this.req1 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.req1","%" + this.req1.ToString() + "%");
			}
			if(this.req2 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.req2","%" + this.req2.ToString() + "%");
			}
			if(this.req3 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.req3","%" + this.req3.ToString() + "%");
			}
			if(this.req4 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.req4","%" + this.req4.ToString() + "%");
			}
			if(this.req5 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.req5","%" + this.req5.ToString() + "%");
			}
			if(this.req6 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.req6","%" + this.req6.ToString() + "%");
			}
			if(this.add1 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.add1","%" + this.add1.ToString() + "%");
			}
			if(this.add2 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.add2","%" + this.add2.ToString() + "%");
			}
			if(this.add3 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.add3","%" + this.add3.ToString() + "%");
			}
			if(this.add4 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.add4","%" + this.add4.ToString() + "%");
			}
			if(this.add5 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.add5","%" + this.add5.ToString() + "%");
			}
			if(this.add6 != null)
			{
				result = result.WhereLike("cq_robot_uplevel.add6","%" + this.add6.ToString() + "%");
			}
			if(this.equip_pos != null)
			{
				result = result.WhereLike("cq_robot_uplevel.equip_pos","%" + this.equip_pos.ToString() + "%");
			}
			if(this.equip_itemtype != null)
			{
				result = result.WhereLike("cq_robot_uplevel.equip_itemtype","%" + this.equip_itemtype.ToString() + "%");
			}
			if(this.add_register != null)
			{
				result = result.WhereLike("cq_robot_uplevel.add_register","%" + this.add_register.ToString() + "%");
			}
			if(this.req_level != null)
			{
				result = result.WhereLike("cq_robot_uplevel.req_level","%" + this.req_level.ToString() + "%");
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