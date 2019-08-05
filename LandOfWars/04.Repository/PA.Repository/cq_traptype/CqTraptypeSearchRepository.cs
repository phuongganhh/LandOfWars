using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTraptypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? sort { get; set; }
		public int? look { get; set; }
		public int? action_id { get; set; }
		public int? level { get; set; }
		public int? dexterity { get; set; }
		public int? attack_speed { get; set; }
		public int? active_times { get; set; }
		public int? magic_type { get; set; }
		public int? magic_hitrate { get; set; }
		public int? size { get; set; }
		public int? atk_mode { get; set; }
		public int? atk_max { get; set; }
		public int? atk_min { get; set; }
		public int? atk_hot { get; set; }
		public int? atk_shake { get; set; }
		public int? atk_sting { get; set; }
		public int? atk_decay { get; set; }
		public int? immunity { get; set; }
		public int? touchoff_range { get; set; }
		public int? detonate_range { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_traptype")
				.Select(
					"cq_traptype.id",
					"cq_traptype.sort",
					"cq_traptype.look",
					"cq_traptype.action_id",
					"cq_traptype.level",
					"cq_traptype.dexterity",
					"cq_traptype.attack_speed",
					"cq_traptype.active_times",
					"cq_traptype.magic_type",
					"cq_traptype.magic_hitrate",
					"cq_traptype.size",
					"cq_traptype.atk_mode",
					"cq_traptype.atk_max",
					"cq_traptype.atk_min",
					"cq_traptype.atk_hot",
					"cq_traptype.atk_shake",
					"cq_traptype.atk_sting",
					"cq_traptype.atk_decay",
					"cq_traptype.immunity",
					"cq_traptype.touchoff_range",
					"cq_traptype.detonate_range"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_traptype")
                        .Select("cq_traptype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_traptype.id","%" + this.id.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_traptype.sort","%" + this.sort.ToString() + "%");
			}
			if(this.look != null)
			{
				result = result.WhereLike("cq_traptype.look","%" + this.look.ToString() + "%");
			}
			if(this.action_id != null)
			{
				result = result.WhereLike("cq_traptype.action_id","%" + this.action_id.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_traptype.level","%" + this.level.ToString() + "%");
			}
			if(this.dexterity != null)
			{
				result = result.WhereLike("cq_traptype.dexterity","%" + this.dexterity.ToString() + "%");
			}
			if(this.attack_speed != null)
			{
				result = result.WhereLike("cq_traptype.attack_speed","%" + this.attack_speed.ToString() + "%");
			}
			if(this.active_times != null)
			{
				result = result.WhereLike("cq_traptype.active_times","%" + this.active_times.ToString() + "%");
			}
			if(this.magic_type != null)
			{
				result = result.WhereLike("cq_traptype.magic_type","%" + this.magic_type.ToString() + "%");
			}
			if(this.magic_hitrate != null)
			{
				result = result.WhereLike("cq_traptype.magic_hitrate","%" + this.magic_hitrate.ToString() + "%");
			}
			if(this.size != null)
			{
				result = result.WhereLike("cq_traptype.size","%" + this.size.ToString() + "%");
			}
			if(this.atk_mode != null)
			{
				result = result.WhereLike("cq_traptype.atk_mode","%" + this.atk_mode.ToString() + "%");
			}
			if(this.atk_max != null)
			{
				result = result.WhereLike("cq_traptype.atk_max","%" + this.atk_max.ToString() + "%");
			}
			if(this.atk_min != null)
			{
				result = result.WhereLike("cq_traptype.atk_min","%" + this.atk_min.ToString() + "%");
			}
			if(this.atk_hot != null)
			{
				result = result.WhereLike("cq_traptype.atk_hot","%" + this.atk_hot.ToString() + "%");
			}
			if(this.atk_shake != null)
			{
				result = result.WhereLike("cq_traptype.atk_shake","%" + this.atk_shake.ToString() + "%");
			}
			if(this.atk_sting != null)
			{
				result = result.WhereLike("cq_traptype.atk_sting","%" + this.atk_sting.ToString() + "%");
			}
			if(this.atk_decay != null)
			{
				result = result.WhereLike("cq_traptype.atk_decay","%" + this.atk_decay.ToString() + "%");
			}
			if(this.immunity != null)
			{
				result = result.WhereLike("cq_traptype.immunity","%" + this.immunity.ToString() + "%");
			}
			if(this.touchoff_range != null)
			{
				result = result.WhereLike("cq_traptype.touchoff_range","%" + this.touchoff_range.ToString() + "%");
			}
			if(this.detonate_range != null)
			{
				result = result.WhereLike("cq_traptype.detonate_range","%" + this.detonate_range.ToString() + "%");
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