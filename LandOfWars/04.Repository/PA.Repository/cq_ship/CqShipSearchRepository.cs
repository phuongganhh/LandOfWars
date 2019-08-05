using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShipSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public string name { get; set; }
		public string IdName { get; set; }
		public int? captain { get; set; }
		public int? captain_lev { get; set; }
		public int? owner_type { get; set; }
		public int? owner_id { get; set; }
		public int? record_fly { get; set; }
		public int? record_finish { get; set; }
		public int? npc1 { get; set; }
		public int? npc2 { get; set; }
		public int? npc3 { get; set; }
		public int? npc4 { get; set; }
		public int? npc5 { get; set; }
		public int? npc6 { get; set; }
		public int? npc7 { get; set; }
		public int? npc8 { get; set; }
		public int? lookface { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_ship")
				.Select(
					"cq_ship.id",
					"cq_ship.type",
					"cq_ship.name",
					"cq_ship.IdName",
					"cq_ship.captain",
					"cq_ship.captain_lev",
					"cq_ship.owner_type",
					"cq_ship.owner_id",
					"cq_ship.record_fly",
					"cq_ship.record_finish",
					"cq_ship.npc1",
					"cq_ship.npc2",
					"cq_ship.npc3",
					"cq_ship.npc4",
					"cq_ship.npc5",
					"cq_ship.npc6",
					"cq_ship.npc7",
					"cq_ship.npc8",
					"cq_ship.lookface"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_ship")
                        .Select("cq_ship.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_ship.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_ship.type","%" + this.type.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_ship.name","%" + this.name.ToString() + "%");
			}
			if(this.IdName != null)
			{
				result = result.WhereLike("cq_ship.IdName","%" + this.IdName.ToString() + "%");
			}
			if(this.captain != null)
			{
				result = result.WhereLike("cq_ship.captain","%" + this.captain.ToString() + "%");
			}
			if(this.captain_lev != null)
			{
				result = result.WhereLike("cq_ship.captain_lev","%" + this.captain_lev.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_ship.owner_type","%" + this.owner_type.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_ship.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.record_fly != null)
			{
				result = result.WhereLike("cq_ship.record_fly","%" + this.record_fly.ToString() + "%");
			}
			if(this.record_finish != null)
			{
				result = result.WhereLike("cq_ship.record_finish","%" + this.record_finish.ToString() + "%");
			}
			if(this.npc1 != null)
			{
				result = result.WhereLike("cq_ship.npc1","%" + this.npc1.ToString() + "%");
			}
			if(this.npc2 != null)
			{
				result = result.WhereLike("cq_ship.npc2","%" + this.npc2.ToString() + "%");
			}
			if(this.npc3 != null)
			{
				result = result.WhereLike("cq_ship.npc3","%" + this.npc3.ToString() + "%");
			}
			if(this.npc4 != null)
			{
				result = result.WhereLike("cq_ship.npc4","%" + this.npc4.ToString() + "%");
			}
			if(this.npc5 != null)
			{
				result = result.WhereLike("cq_ship.npc5","%" + this.npc5.ToString() + "%");
			}
			if(this.npc6 != null)
			{
				result = result.WhereLike("cq_ship.npc6","%" + this.npc6.ToString() + "%");
			}
			if(this.npc7 != null)
			{
				result = result.WhereLike("cq_ship.npc7","%" + this.npc7.ToString() + "%");
			}
			if(this.npc8 != null)
			{
				result = result.WhereLike("cq_ship.npc8","%" + this.npc8.ToString() + "%");
			}
			if(this.lookface != null)
			{
				result = result.WhereLike("cq_ship.lookface","%" + this.lookface.ToString() + "%");
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