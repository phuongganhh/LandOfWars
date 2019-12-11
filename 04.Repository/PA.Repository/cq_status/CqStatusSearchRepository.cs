using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStatusSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? owner_id { get; set; }
		public int? robot_id { get; set; }
		public int? status { get; set; }
		public int? power { get; set; }
		public int? sort { get; set; }
		public int? leave_times { get; set; }
		public int? remain_time { get; set; }
		public int? end_time { get; set; }
		public int? nParam { get; set; }
		public int? nWParam { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_status")
				.Select(
					"cq_status.id",
					"cq_status.owner_id",
					"cq_status.robot_id",
					"cq_status.status",
					"cq_status.power",
					"cq_status.sort",
					"cq_status.leave_times",
					"cq_status.remain_time",
					"cq_status.end_time",
					"cq_status.nParam",
					"cq_status.nWParam"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_status")
                        .Select("cq_status.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_status.id","%" + this.id.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_status.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.robot_id != null)
			{
				result = result.WhereLike("cq_status.robot_id","%" + this.robot_id.ToString() + "%");
			}
			if(this.status != null)
			{
				result = result.WhereLike("cq_status.status","%" + this.status.ToString() + "%");
			}
			if(this.power != null)
			{
				result = result.WhereLike("cq_status.power","%" + this.power.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_status.sort","%" + this.sort.ToString() + "%");
			}
			if(this.leave_times != null)
			{
				result = result.WhereLike("cq_status.leave_times","%" + this.leave_times.ToString() + "%");
			}
			if(this.remain_time != null)
			{
				result = result.WhereLike("cq_status.remain_time","%" + this.remain_time.ToString() + "%");
			}
			if(this.end_time != null)
			{
				result = result.WhereLike("cq_status.end_time","%" + this.end_time.ToString() + "%");
			}
			if(this.nParam != null)
			{
				result = result.WhereLike("cq_status.nParam","%" + this.nParam.ToString() + "%");
			}
			if(this.nWParam != null)
			{
				result = result.WhereLike("cq_status.nWParam","%" + this.nWParam.ToString() + "%");
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