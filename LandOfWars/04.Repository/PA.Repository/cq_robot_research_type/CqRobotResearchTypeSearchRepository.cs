using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobotResearchTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? robot_type { get; set; }
		public int? need_starlevel { get; set; }
		public int? position { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_robot_research_type")
				.Select(
					"cq_robot_research_type.id",
					"cq_robot_research_type.name",
					"cq_robot_research_type.robot_type",
					"cq_robot_research_type.need_starlevel",
					"cq_robot_research_type.position"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_robot_research_type")
                        .Select("cq_robot_research_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_robot_research_type.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_robot_research_type.name","%" + this.name.ToString() + "%");
			}
			if(this.robot_type != null)
			{
				result = result.WhereLike("cq_robot_research_type.robot_type","%" + this.robot_type.ToString() + "%");
			}
			if(this.need_starlevel != null)
			{
				result = result.WhereLike("cq_robot_research_type.need_starlevel","%" + this.need_starlevel.ToString() + "%");
			}
			if(this.position != null)
			{
				result = result.WhereLike("cq_robot_research_type.position","%" + this.position.ToString() + "%");
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