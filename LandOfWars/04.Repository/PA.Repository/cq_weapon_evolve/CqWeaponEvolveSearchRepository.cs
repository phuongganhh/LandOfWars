using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponEvolveSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? evolve_weapon { get; set; }
		public int? req_lv { get; set; }
		public int? req_atk { get; set; }
		public int? req_hot_atk { get; set; }
		public int? req_shake_atk { get; set; }
		public int? req_sting_atk { get; set; }
		public int? req_decay_atk { get; set; }
		public int? req_fighter_atk { get; set; }
		public int? req_gunner_atk { get; set; }
		public int? req_energy_atk { get; set; }
		public int? req_type { get; set; }
		public int? req_data { get; set; }
		public int? add_atk { get; set; }
		public int? add_hot_atk { get; set; }
		public int? add_shake_atk { get; set; }
		public int? add_sting_atk { get; set; }
		public int? add_decay_atk { get; set; }
		public int? add_fighter_atk { get; set; }
		public int? add_gunner_atk { get; set; }
		public int? add_energy_atk { get; set; }
		public int? add_point { get; set; }
		public int? add_fittings { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_weapon_evolve")
				.Select(
					"cq_weapon_evolve.id",
					"cq_weapon_evolve.evolve_weapon",
					"cq_weapon_evolve.req_lv",
					"cq_weapon_evolve.req_atk",
					"cq_weapon_evolve.req_hot_atk",
					"cq_weapon_evolve.req_shake_atk",
					"cq_weapon_evolve.req_sting_atk",
					"cq_weapon_evolve.req_decay_atk",
					"cq_weapon_evolve.req_fighter_atk",
					"cq_weapon_evolve.req_gunner_atk",
					"cq_weapon_evolve.req_energy_atk",
					"cq_weapon_evolve.req_type",
					"cq_weapon_evolve.req_data",
					"cq_weapon_evolve.add_atk",
					"cq_weapon_evolve.add_hot_atk",
					"cq_weapon_evolve.add_shake_atk",
					"cq_weapon_evolve.add_sting_atk",
					"cq_weapon_evolve.add_decay_atk",
					"cq_weapon_evolve.add_fighter_atk",
					"cq_weapon_evolve.add_gunner_atk",
					"cq_weapon_evolve.add_energy_atk",
					"cq_weapon_evolve.add_point",
					"cq_weapon_evolve.add_fittings"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_weapon_evolve")
                        .Select("cq_weapon_evolve.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_weapon_evolve.id","%" + this.id.ToString() + "%");
			}
			if(this.evolve_weapon != null)
			{
				result = result.WhereLike("cq_weapon_evolve.evolve_weapon","%" + this.evolve_weapon.ToString() + "%");
			}
			if(this.req_lv != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_lv","%" + this.req_lv.ToString() + "%");
			}
			if(this.req_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_atk","%" + this.req_atk.ToString() + "%");
			}
			if(this.req_hot_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_hot_atk","%" + this.req_hot_atk.ToString() + "%");
			}
			if(this.req_shake_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_shake_atk","%" + this.req_shake_atk.ToString() + "%");
			}
			if(this.req_sting_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_sting_atk","%" + this.req_sting_atk.ToString() + "%");
			}
			if(this.req_decay_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_decay_atk","%" + this.req_decay_atk.ToString() + "%");
			}
			if(this.req_fighter_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_fighter_atk","%" + this.req_fighter_atk.ToString() + "%");
			}
			if(this.req_gunner_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_gunner_atk","%" + this.req_gunner_atk.ToString() + "%");
			}
			if(this.req_energy_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_energy_atk","%" + this.req_energy_atk.ToString() + "%");
			}
			if(this.req_type != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_type","%" + this.req_type.ToString() + "%");
			}
			if(this.req_data != null)
			{
				result = result.WhereLike("cq_weapon_evolve.req_data","%" + this.req_data.ToString() + "%");
			}
			if(this.add_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_atk","%" + this.add_atk.ToString() + "%");
			}
			if(this.add_hot_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_hot_atk","%" + this.add_hot_atk.ToString() + "%");
			}
			if(this.add_shake_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_shake_atk","%" + this.add_shake_atk.ToString() + "%");
			}
			if(this.add_sting_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_sting_atk","%" + this.add_sting_atk.ToString() + "%");
			}
			if(this.add_decay_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_decay_atk","%" + this.add_decay_atk.ToString() + "%");
			}
			if(this.add_fighter_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_fighter_atk","%" + this.add_fighter_atk.ToString() + "%");
			}
			if(this.add_gunner_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_gunner_atk","%" + this.add_gunner_atk.ToString() + "%");
			}
			if(this.add_energy_atk != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_energy_atk","%" + this.add_energy_atk.ToString() + "%");
			}
			if(this.add_point != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_point","%" + this.add_point.ToString() + "%");
			}
			if(this.add_fittings != null)
			{
				result = result.WhereLike("cq_weapon_evolve.add_fittings","%" + this.add_fittings.ToString() + "%");
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