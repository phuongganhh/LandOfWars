using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTotemAddSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? totem_type { get; set; }
		public int? owner_id { get; set; }
		public int? battle_add { get; set; }
		public int? time_limit { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_totem_add")
				.Select(
					"cq_totem_add.id",
					"cq_totem_add.totem_type",
					"cq_totem_add.owner_id",
					"cq_totem_add.battle_add",
					"cq_totem_add.time_limit"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_totem_add")
                        .Select("cq_totem_add.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_totem_add.id","%" + this.id.ToString() + "%");
			}
			if(this.totem_type != null)
			{
				result = result.WhereLike("cq_totem_add.totem_type","%" + this.totem_type.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_totem_add.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.battle_add != null)
			{
				result = result.WhereLike("cq_totem_add.battle_add","%" + this.battle_add.ToString() + "%");
			}
			if(this.time_limit != null)
			{
				result = result.WhereLike("cq_totem_add.time_limit","%" + this.time_limit.ToString() + "%");
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