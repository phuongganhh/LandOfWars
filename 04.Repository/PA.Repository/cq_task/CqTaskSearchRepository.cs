using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTaskSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? id_next { get; set; }
		public int? id_nextfail { get; set; }
		public string itemname1 { get; set; }
		public string itemname2 { get; set; }
		public int? money { get; set; }
		public int? profession { get; set; }
		public int? sex { get; set; }
		public int? min_pk { get; set; }
		public int? max_pk { get; set; }
		public int? team { get; set; }
		public int? metempsychosis { get; set; }
		public int? query { get; set; }
		public int? marriage { get; set; }
		public int? client_active { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_task")
				.Select(
					"cq_task.id",
					"cq_task.id_next",
					"cq_task.id_nextfail",
					"cq_task.itemname1",
					"cq_task.itemname2",
					"cq_task.money",
					"cq_task.profession",
					"cq_task.sex",
					"cq_task.min_pk",
					"cq_task.max_pk",
					"cq_task.team",
					"cq_task.metempsychosis",
					"cq_task.query",
					"cq_task.marriage",
					"cq_task.client_active"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_task")
                        .Select("cq_task.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_task.id","%" + this.id.ToString() + "%");
			}
			if(this.id_next != null)
			{
				result = result.WhereLike("cq_task.id_next","%" + this.id_next.ToString() + "%");
			}
			if(this.id_nextfail != null)
			{
				result = result.WhereLike("cq_task.id_nextfail","%" + this.id_nextfail.ToString() + "%");
			}
			if(this.itemname1 != null)
			{
				result = result.WhereLike("cq_task.itemname1","%" + this.itemname1.ToString() + "%");
			}
			if(this.itemname2 != null)
			{
				result = result.WhereLike("cq_task.itemname2","%" + this.itemname2.ToString() + "%");
			}
			if(this.money != null)
			{
				result = result.WhereLike("cq_task.money","%" + this.money.ToString() + "%");
			}
			if(this.profession != null)
			{
				result = result.WhereLike("cq_task.profession","%" + this.profession.ToString() + "%");
			}
			if(this.sex != null)
			{
				result = result.WhereLike("cq_task.sex","%" + this.sex.ToString() + "%");
			}
			if(this.min_pk != null)
			{
				result = result.WhereLike("cq_task.min_pk","%" + this.min_pk.ToString() + "%");
			}
			if(this.max_pk != null)
			{
				result = result.WhereLike("cq_task.max_pk","%" + this.max_pk.ToString() + "%");
			}
			if(this.team != null)
			{
				result = result.WhereLike("cq_task.team","%" + this.team.ToString() + "%");
			}
			if(this.metempsychosis != null)
			{
				result = result.WhereLike("cq_task.metempsychosis","%" + this.metempsychosis.ToString() + "%");
			}
			if(this.query != null)
			{
				result = result.WhereLike("cq_task.query","%" + this.query.ToString() + "%");
			}
			if(this.marriage != null)
			{
				result = result.WhereLike("cq_task.marriage","%" + this.marriage.ToString() + "%");
			}
			if(this.client_active != null)
			{
				result = result.WhereLike("cq_task.client_active","%" + this.client_active.ToString() + "%");
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