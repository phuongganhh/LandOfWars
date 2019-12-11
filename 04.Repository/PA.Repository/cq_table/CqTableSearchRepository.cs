using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTableSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? npc_id { get; set; }
		public int? type { get; set; }
		public int? key_id { get; set; }
		public string datastr { get; set; }
		public int? data0 { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? data3 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_table")
				.Select(
					"cq_table.id",
					"cq_table.npc_id",
					"cq_table.type",
					"cq_table.key_id",
					"cq_table.datastr",
					"cq_table.data0",
					"cq_table.data1",
					"cq_table.data2",
					"cq_table.data3"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_table")
                        .Select("cq_table.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_table.id","%" + this.id.ToString() + "%");
			}
			if(this.npc_id != null)
			{
				result = result.WhereLike("cq_table.npc_id","%" + this.npc_id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_table.type","%" + this.type.ToString() + "%");
			}
			if(this.key_id != null)
			{
				result = result.WhereLike("cq_table.key_id","%" + this.key_id.ToString() + "%");
			}
			if(this.datastr != null)
			{
				result = result.WhereLike("cq_table.datastr","%" + this.datastr.ToString() + "%");
			}
			if(this.data0 != null)
			{
				result = result.WhereLike("cq_table.data0","%" + this.data0.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_table.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_table.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_table.data3","%" + this.data3.ToString() + "%");
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