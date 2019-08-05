using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMonsterAttributeTypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? def_strafe { get; set; }
		public int? def_fire { get; set; }
		public int? def_shake { get; set; }
		public int? def_ice { get; set; }
		public int? def_snipe { get; set; }
		public int? weakness { get; set; }
		public int? Def_C { get; set; }
		public int? Def_hot { get; set; }
		public int? def_MGun { get; set; }
		public int? def_shakegun { get; set; }
		public int? max_wrath { get; set; }
		public int? def_beat { get; set; }
		public int? Def_musket { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_monster_attribute_type")
				.Select(
					"cq_monster_attribute_type.id",
					"cq_monster_attribute_type.def_strafe",
					"cq_monster_attribute_type.def_fire",
					"cq_monster_attribute_type.def_shake",
					"cq_monster_attribute_type.def_ice",
					"cq_monster_attribute_type.def_snipe",
					"cq_monster_attribute_type.weakness",
					"cq_monster_attribute_type.Def_C",
					"cq_monster_attribute_type.Def_hot",
					"cq_monster_attribute_type.def_MGun",
					"cq_monster_attribute_type.def_shakegun",
					"cq_monster_attribute_type.max_wrath",
					"cq_monster_attribute_type.def_beat",
					"cq_monster_attribute_type.Def_musket"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_monster_attribute_type")
                        .Select("cq_monster_attribute_type.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.id","%" + this.id.ToString() + "%");
			}
			if(this.def_strafe != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_strafe","%" + this.def_strafe.ToString() + "%");
			}
			if(this.def_fire != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_fire","%" + this.def_fire.ToString() + "%");
			}
			if(this.def_shake != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_shake","%" + this.def_shake.ToString() + "%");
			}
			if(this.def_ice != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_ice","%" + this.def_ice.ToString() + "%");
			}
			if(this.def_snipe != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_snipe","%" + this.def_snipe.ToString() + "%");
			}
			if(this.weakness != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.weakness","%" + this.weakness.ToString() + "%");
			}
			if(this.Def_C != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.Def_C","%" + this.Def_C.ToString() + "%");
			}
			if(this.Def_hot != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.Def_hot","%" + this.Def_hot.ToString() + "%");
			}
			if(this.def_MGun != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_MGun","%" + this.def_MGun.ToString() + "%");
			}
			if(this.def_shakegun != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_shakegun","%" + this.def_shakegun.ToString() + "%");
			}
			if(this.max_wrath != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.max_wrath","%" + this.max_wrath.ToString() + "%");
			}
			if(this.def_beat != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.def_beat","%" + this.def_beat.ToString() + "%");
			}
			if(this.Def_musket != null)
			{
				result = result.WhereLike("cq_monster_attribute_type.Def_musket","%" + this.Def_musket.ToString() + "%");
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