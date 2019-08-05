using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobotTechnopointSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? Robot_Type { get; set; }
		public int? TYPE { get; set; }
		public string NAME { get; set; }
		public int? Robot_Model_level { get; set; }
		public int? Precondition0 { get; set; }
		public int? Precondition1 { get; set; }
		public int? Precondition2 { get; set; }
		public int? Precondition3 { get; set; }
		public int? Precondition4 { get; set; }
		public int? UsagePoint { get; set; }
		public int? Conflict0 { get; set; }
		public int? Conflict1 { get; set; }
		public int? Conflict2 { get; set; }
		public int? point { get; set; }
		public int? UsageIndex { get; set; }
		public int? Action0 { get; set; }
		public int? Action1 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_robot_technopoint")
				.Select(
					"cq_robot_technopoint.id",
					"cq_robot_technopoint.Robot_Type",
					"cq_robot_technopoint.TYPE",
					"cq_robot_technopoint.NAME",
					"cq_robot_technopoint.Robot_Model_level",
					"cq_robot_technopoint.Precondition0",
					"cq_robot_technopoint.Precondition1",
					"cq_robot_technopoint.Precondition2",
					"cq_robot_technopoint.Precondition3",
					"cq_robot_technopoint.Precondition4",
					"cq_robot_technopoint.UsagePoint",
					"cq_robot_technopoint.Conflict0",
					"cq_robot_technopoint.Conflict1",
					"cq_robot_technopoint.Conflict2",
					"cq_robot_technopoint.point",
					"cq_robot_technopoint.UsageIndex",
					"cq_robot_technopoint.Action0",
					"cq_robot_technopoint.Action1"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_robot_technopoint")
                        .Select("cq_robot_technopoint.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_robot_technopoint.id","%" + this.id.ToString() + "%");
			}
			if(this.Robot_Type != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Robot_Type","%" + this.Robot_Type.ToString() + "%");
			}
			if(this.TYPE != null)
			{
				result = result.WhereLike("cq_robot_technopoint.TYPE","%" + this.TYPE.ToString() + "%");
			}
			if(this.NAME != null)
			{
				result = result.WhereLike("cq_robot_technopoint.NAME","%" + this.NAME.ToString() + "%");
			}
			if(this.Robot_Model_level != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Robot_Model_level","%" + this.Robot_Model_level.ToString() + "%");
			}
			if(this.Precondition0 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Precondition0","%" + this.Precondition0.ToString() + "%");
			}
			if(this.Precondition1 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Precondition1","%" + this.Precondition1.ToString() + "%");
			}
			if(this.Precondition2 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Precondition2","%" + this.Precondition2.ToString() + "%");
			}
			if(this.Precondition3 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Precondition3","%" + this.Precondition3.ToString() + "%");
			}
			if(this.Precondition4 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Precondition4","%" + this.Precondition4.ToString() + "%");
			}
			if(this.UsagePoint != null)
			{
				result = result.WhereLike("cq_robot_technopoint.UsagePoint","%" + this.UsagePoint.ToString() + "%");
			}
			if(this.Conflict0 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Conflict0","%" + this.Conflict0.ToString() + "%");
			}
			if(this.Conflict1 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Conflict1","%" + this.Conflict1.ToString() + "%");
			}
			if(this.Conflict2 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Conflict2","%" + this.Conflict2.ToString() + "%");
			}
			if(this.point != null)
			{
				result = result.WhereLike("cq_robot_technopoint.point","%" + this.point.ToString() + "%");
			}
			if(this.UsageIndex != null)
			{
				result = result.WhereLike("cq_robot_technopoint.UsageIndex","%" + this.UsageIndex.ToString() + "%");
			}
			if(this.Action0 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Action0","%" + this.Action0.ToString() + "%");
			}
			if(this.Action1 != null)
			{
				result = result.WhereLike("cq_robot_technopoint.Action1","%" + this.Action1.ToString() + "%");
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