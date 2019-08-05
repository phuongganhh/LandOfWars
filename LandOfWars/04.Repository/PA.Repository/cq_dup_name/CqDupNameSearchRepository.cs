using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDupNameSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? Id { get; set; }
		public int? Complete { get; set; }
		public int? Type { get; set; }
		public int? object_id { get; set; }
		public string Old_name { get; set; }
		public string Name { get; set; }
		public string New_name { get; set; }
		public int? serverflag { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_dup_name")
				.Select(
					"cq_dup_name.Id",
					"cq_dup_name.Complete",
					"cq_dup_name.Type",
					"cq_dup_name.object_id",
					"cq_dup_name.Old_name",
					"cq_dup_name.Name",
					"cq_dup_name.New_name",
					"cq_dup_name.serverflag"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_dup_name")
                        .Select("cq_dup_name.Id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.Id != null)
			{
				result = result.WhereLike("cq_dup_name.Id","%" + this.Id.ToString() + "%");
			}
			if(this.Complete != null)
			{
				result = result.WhereLike("cq_dup_name.Complete","%" + this.Complete.ToString() + "%");
			}
			if(this.Type != null)
			{
				result = result.WhereLike("cq_dup_name.Type","%" + this.Type.ToString() + "%");
			}
			if(this.object_id != null)
			{
				result = result.WhereLike("cq_dup_name.object_id","%" + this.object_id.ToString() + "%");
			}
			if(this.Old_name != null)
			{
				result = result.WhereLike("cq_dup_name.Old_name","%" + this.Old_name.ToString() + "%");
			}
			if(this.Name != null)
			{
				result = result.WhereLike("cq_dup_name.Name","%" + this.Name.ToString() + "%");
			}
			if(this.New_name != null)
			{
				result = result.WhereLike("cq_dup_name.New_name","%" + this.New_name.ToString() + "%");
			}
			if(this.serverflag != null)
			{
				result = result.WhereLike("cq_dup_name.serverflag","%" + this.serverflag.ToString() + "%");
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