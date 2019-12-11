using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponSkillSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? type { get; set; }
		public int? level { get; set; }
		public long? exp { get; set; }
		public int? old_level { get; set; }
		public int? owner_id { get; set; }
		public int? id { get; set; }
		public int? unlearn { get; set; }
		public int? ownertype { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_weapon_skill")
				.Select(
					"cq_weapon_skill.type",
					"cq_weapon_skill.level",
					"cq_weapon_skill.exp",
					"cq_weapon_skill.old_level",
					"cq_weapon_skill.owner_id",
					"cq_weapon_skill.id",
					"cq_weapon_skill.unlearn",
					"cq_weapon_skill.ownertype"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_weapon_skill")
                        .Select("cq_weapon_skill.type")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.type != null)
			{
				result = result.WhereLike("cq_weapon_skill.type","%" + this.type.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_weapon_skill.level","%" + this.level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_weapon_skill.exp","%" + this.exp.ToString() + "%");
			}
			if(this.old_level != null)
			{
				result = result.WhereLike("cq_weapon_skill.old_level","%" + this.old_level.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_weapon_skill.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.id != null)
			{
				result = result.WhereLike("cq_weapon_skill.id","%" + this.id.ToString() + "%");
			}
			if(this.unlearn != null)
			{
				result = result.WhereLike("cq_weapon_skill.unlearn","%" + this.unlearn.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_weapon_skill.ownertype","%" + this.ownertype.ToString() + "%");
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