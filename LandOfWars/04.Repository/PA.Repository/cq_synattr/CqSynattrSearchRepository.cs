using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSynattrSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? syn_id { get; set; }
		public int? rank { get; set; }
		public int? proffer_money { get; set; }
		public int? days { get; set; }
		public int? assistant_id { get; set; }
		public int? employ_time { get; set; }
		public int? proffer_exploit { get; set; }
		public int? flower { get; set; }
		public int? master_id { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_synattr")
				.Select(
					"cq_synattr.id",
					"cq_synattr.syn_id",
					"cq_synattr.rank",
					"cq_synattr.proffer_money",
					"cq_synattr.days",
					"cq_synattr.assistant_id",
					"cq_synattr.employ_time",
					"cq_synattr.proffer_exploit",
					"cq_synattr.flower",
					"cq_synattr.master_id"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_synattr")
                        .Select("cq_synattr.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_synattr.id","%" + this.id.ToString() + "%");
			}
			if(this.syn_id != null)
			{
				result = result.WhereLike("cq_synattr.syn_id","%" + this.syn_id.ToString() + "%");
			}
			if(this.rank != null)
			{
				result = result.WhereLike("cq_synattr.rank","%" + this.rank.ToString() + "%");
			}
			if(this.proffer_money != null)
			{
				result = result.WhereLike("cq_synattr.proffer_money","%" + this.proffer_money.ToString() + "%");
			}
			if(this.days != null)
			{
				result = result.WhereLike("cq_synattr.days","%" + this.days.ToString() + "%");
			}
			if(this.assistant_id != null)
			{
				result = result.WhereLike("cq_synattr.assistant_id","%" + this.assistant_id.ToString() + "%");
			}
			if(this.employ_time != null)
			{
				result = result.WhereLike("cq_synattr.employ_time","%" + this.employ_time.ToString() + "%");
			}
			if(this.proffer_exploit != null)
			{
				result = result.WhereLike("cq_synattr.proffer_exploit","%" + this.proffer_exploit.ToString() + "%");
			}
			if(this.flower != null)
			{
				result = result.WhereLike("cq_synattr.flower","%" + this.flower.ToString() + "%");
			}
			if(this.master_id != null)
			{
				result = result.WhereLike("cq_synattr.master_id","%" + this.master_id.ToString() + "%");
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