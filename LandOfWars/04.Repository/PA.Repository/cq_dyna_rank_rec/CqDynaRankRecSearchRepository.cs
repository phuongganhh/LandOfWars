using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDynaRankRecSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public long? Value1 { get; set; }
		public int? Value2 { get; set; }
		public int? Value3 { get; set; }
		public int? Value4 { get; set; }
		public int? Obj_id { get; set; }
		public string datastr { get; set; }
		public int? User_id { get; set; }
		public string User_name { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_dyna_rank_rec")
				.Select(
					"cq_dyna_rank_rec.id",
					"cq_dyna_rank_rec.type",
					"cq_dyna_rank_rec.Value1",
					"cq_dyna_rank_rec.Value2",
					"cq_dyna_rank_rec.Value3",
					"cq_dyna_rank_rec.Value4",
					"cq_dyna_rank_rec.Obj_id",
					"cq_dyna_rank_rec.datastr",
					"cq_dyna_rank_rec.User_id",
					"cq_dyna_rank_rec.User_name"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_dyna_rank_rec")
                        .Select("cq_dyna_rank_rec.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.type","%" + this.type.ToString() + "%");
			}
			if(this.Value1 != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.Value1","%" + this.Value1.ToString() + "%");
			}
			if(this.Value2 != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.Value2","%" + this.Value2.ToString() + "%");
			}
			if(this.Value3 != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.Value3","%" + this.Value3.ToString() + "%");
			}
			if(this.Value4 != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.Value4","%" + this.Value4.ToString() + "%");
			}
			if(this.Obj_id != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.Obj_id","%" + this.Obj_id.ToString() + "%");
			}
			if(this.datastr != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.datastr","%" + this.datastr.ToString() + "%");
			}
			if(this.User_id != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.User_id","%" + this.User_id.ToString() + "%");
			}
			if(this.User_name != null)
			{
				result = result.WhereLike("cq_dyna_rank_rec.User_name","%" + this.User_name.ToString() + "%");
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