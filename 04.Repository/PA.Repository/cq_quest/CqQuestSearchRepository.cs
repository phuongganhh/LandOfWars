using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqQuestSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? iduser { get; set; }
		public int? quest_id { get; set; }
		public int? flag { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? data3 { get; set; }
		public int? data4 { get; set; }
		public int? data5 { get; set; }
		public int? data6 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_quest")
				.Select(
					"cq_quest.id",
					"cq_quest.iduser",
					"cq_quest.quest_id",
					"cq_quest.flag",
					"cq_quest.data1",
					"cq_quest.data2",
					"cq_quest.data3",
					"cq_quest.data4",
					"cq_quest.data5",
					"cq_quest.data6"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_quest")
                        .Select("cq_quest.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_quest.id","%" + this.id.ToString() + "%");
			}
			if(this.iduser != null)
			{
				result = result.WhereLike("cq_quest.iduser","%" + this.iduser.ToString() + "%");
			}
			if(this.quest_id != null)
			{
				result = result.WhereLike("cq_quest.quest_id","%" + this.quest_id.ToString() + "%");
			}
			if(this.flag != null)
			{
				result = result.WhereLike("cq_quest.flag","%" + this.flag.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_quest.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_quest.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_quest.data3","%" + this.data3.ToString() + "%");
			}
			if(this.data4 != null)
			{
				result = result.WhereLike("cq_quest.data4","%" + this.data4.ToString() + "%");
			}
			if(this.data5 != null)
			{
				result = result.WhereLike("cq_quest.data5","%" + this.data5.ToString() + "%");
			}
			if(this.data6 != null)
			{
				result = result.WhereLike("cq_quest.data6","%" + this.data6.ToString() + "%");
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