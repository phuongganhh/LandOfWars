using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRelationTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? relation_lev { get; set; }
		public int? relation_need { get; set; }
		public string brother_lev_name { get; set; }
		public int? pk_relation_reduce { get; set; }
		public int? talk_add { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_relation_type")
				.Select(
					"cq_relation_type.id",
					"cq_relation_type.relation_lev",
					"cq_relation_type.relation_need",
					"cq_relation_type.brother_lev_name",
					"cq_relation_type.pk_relation_reduce",
					"cq_relation_type.talk_add"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_relation_type")
                        .Select("cq_relation_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_relation_type.id","%" + this.id.ToString() + "%");
			}
			if(this.relation_lev != null)
			{
				result = result.WhereLike("cq_relation_type.relation_lev","%" + this.relation_lev.ToString() + "%");
			}
			if(this.relation_need != null)
			{
				result = result.WhereLike("cq_relation_type.relation_need","%" + this.relation_need.ToString() + "%");
			}
			if(this.brother_lev_name != null)
			{
				result = result.WhereLike("cq_relation_type.brother_lev_name","%" + this.brother_lev_name.ToString() + "%");
			}
			if(this.pk_relation_reduce != null)
			{
				result = result.WhereLike("cq_relation_type.pk_relation_reduce","%" + this.pk_relation_reduce.ToString() + "%");
			}
			if(this.talk_add != null)
			{
				result = result.WhereLike("cq_relation_type.talk_add","%" + this.talk_add.ToString() + "%");
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