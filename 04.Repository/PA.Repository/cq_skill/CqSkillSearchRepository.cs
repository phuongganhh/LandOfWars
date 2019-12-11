using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSkillSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? ownerid { get; set; }
		public int? main { get; set; }
		public int? sub1 { get; set; }
		public int? sub2 { get; set; }
		public int? sub3 { get; set; }
		public int? hotkey { get; set; }
		public int? weapon_pos { get; set; }
		public int? owner_type { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_skill")
				.Select(
					"cq_skill.id",
					"cq_skill.ownerid",
					"cq_skill.main",
					"cq_skill.sub1",
					"cq_skill.sub2",
					"cq_skill.sub3",
					"cq_skill.hotkey",
					"cq_skill.weapon_pos",
					"cq_skill.owner_type"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_skill")
                        .Select("cq_skill.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_skill.id","%" + this.id.ToString() + "%");
			}
			if(this.ownerid != null)
			{
				result = result.WhereLike("cq_skill.ownerid","%" + this.ownerid.ToString() + "%");
			}
			if(this.main != null)
			{
				result = result.WhereLike("cq_skill.main","%" + this.main.ToString() + "%");
			}
			if(this.sub1 != null)
			{
				result = result.WhereLike("cq_skill.sub1","%" + this.sub1.ToString() + "%");
			}
			if(this.sub2 != null)
			{
				result = result.WhereLike("cq_skill.sub2","%" + this.sub2.ToString() + "%");
			}
			if(this.sub3 != null)
			{
				result = result.WhereLike("cq_skill.sub3","%" + this.sub3.ToString() + "%");
			}
			if(this.hotkey != null)
			{
				result = result.WhereLike("cq_skill.hotkey","%" + this.hotkey.ToString() + "%");
			}
			if(this.weapon_pos != null)
			{
				result = result.WhereLike("cq_skill.weapon_pos","%" + this.weapon_pos.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_skill.owner_type","%" + this.owner_type.ToString() + "%");
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