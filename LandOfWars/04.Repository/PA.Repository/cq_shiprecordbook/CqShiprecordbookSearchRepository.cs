using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShiprecordbookSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? player { get; set; }
		public int? mission { get; set; }
		public int? joins { get; set; }
		public int? finish { get; set; }
		public int? perfect { get; set; }
		public int? finish_record { get; set; }
		public int? finish_time { get; set; }
		public int? perfect_record { get; set; }
		public int? perfect_time { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shiprecordbook")
				.Select(
					"cq_shiprecordbook.id",
					"cq_shiprecordbook.player",
					"cq_shiprecordbook.mission",
					"cq_shiprecordbook.joins",
					"cq_shiprecordbook.finish",
					"cq_shiprecordbook.perfect",
					"cq_shiprecordbook.finish_record",
					"cq_shiprecordbook.finish_time",
					"cq_shiprecordbook.perfect_record",
					"cq_shiprecordbook.perfect_time"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shiprecordbook")
                        .Select("cq_shiprecordbook.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shiprecordbook.id","%" + this.id.ToString() + "%");
			}
			if(this.player != null)
			{
				result = result.WhereLike("cq_shiprecordbook.player","%" + this.player.ToString() + "%");
			}
			if(this.mission != null)
			{
				result = result.WhereLike("cq_shiprecordbook.mission","%" + this.mission.ToString() + "%");
			}
			if(this.joins != null)
			{
				result = result.WhereLike("cq_shiprecordbook.joins","%" + this.joins.ToString() + "%");
			}
			if(this.finish != null)
			{
				result = result.WhereLike("cq_shiprecordbook.finish","%" + this.finish.ToString() + "%");
			}
			if(this.perfect != null)
			{
				result = result.WhereLike("cq_shiprecordbook.perfect","%" + this.perfect.ToString() + "%");
			}
			if(this.finish_record != null)
			{
				result = result.WhereLike("cq_shiprecordbook.finish_record","%" + this.finish_record.ToString() + "%");
			}
			if(this.finish_time != null)
			{
				result = result.WhereLike("cq_shiprecordbook.finish_time","%" + this.finish_time.ToString() + "%");
			}
			if(this.perfect_record != null)
			{
				result = result.WhereLike("cq_shiprecordbook.perfect_record","%" + this.perfect_record.ToString() + "%");
			}
			if(this.perfect_time != null)
			{
				result = result.WhereLike("cq_shiprecordbook.perfect_time","%" + this.perfect_time.ToString() + "%");
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