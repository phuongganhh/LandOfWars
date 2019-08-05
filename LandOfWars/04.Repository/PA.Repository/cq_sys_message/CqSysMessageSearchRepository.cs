using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSysMessageSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? priority { get; set; }
		public int? time_validity { get; set; }
		public int? level { get; set; }
		public int? robot_level { get; set; }
		public int? god_status { get; set; }
		public int? user_emoney { get; set; }
		public int? account_vip { get; set; }
		public int? mes_type { get; set; }
		public string message { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_sys_message")
				.Select(
					"cq_sys_message.id",
					"cq_sys_message.priority",
					"cq_sys_message.time_validity",
					"cq_sys_message.level",
					"cq_sys_message.robot_level",
					"cq_sys_message.god_status",
					"cq_sys_message.user_emoney",
					"cq_sys_message.account_vip",
					"cq_sys_message.mes_type",
					"cq_sys_message.message"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_sys_message")
                        .Select("cq_sys_message.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_sys_message.id","%" + this.id.ToString() + "%");
			}
			if(this.priority != null)
			{
				result = result.WhereLike("cq_sys_message.priority","%" + this.priority.ToString() + "%");
			}
			if(this.time_validity != null)
			{
				result = result.WhereLike("cq_sys_message.time_validity","%" + this.time_validity.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_sys_message.level","%" + this.level.ToString() + "%");
			}
			if(this.robot_level != null)
			{
				result = result.WhereLike("cq_sys_message.robot_level","%" + this.robot_level.ToString() + "%");
			}
			if(this.god_status != null)
			{
				result = result.WhereLike("cq_sys_message.god_status","%" + this.god_status.ToString() + "%");
			}
			if(this.user_emoney != null)
			{
				result = result.WhereLike("cq_sys_message.user_emoney","%" + this.user_emoney.ToString() + "%");
			}
			if(this.account_vip != null)
			{
				result = result.WhereLike("cq_sys_message.account_vip","%" + this.account_vip.ToString() + "%");
			}
			if(this.mes_type != null)
			{
				result = result.WhereLike("cq_sys_message.mes_type","%" + this.mes_type.ToString() + "%");
			}
			if(this.message != null)
			{
				result = result.WhereLike("cq_sys_message.message","%" + this.message.ToString() + "%");
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