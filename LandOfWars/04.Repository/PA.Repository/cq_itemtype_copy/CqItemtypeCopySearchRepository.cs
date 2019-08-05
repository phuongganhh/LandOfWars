using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemtypeCopySearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? level { get; set; }
		public int? weight { get; set; }
		public int? price { get; set; }
		public int? id_action { get; set; }
		public int? life { get; set; }
		public int? max_en { get; set; }
		public int? charge_en { get; set; }
		public int? max_power { get; set; }
		public int? charge_power { get; set; }
		public int? amount_limit { get; set; }
		public int? ident { get; set; }
		public int? equip_type { get; set; }
		public int? equip_level { get; set; }
		public int? equip_skill { get; set; }
		public int? gem1 { get; set; }
		public int? gem2 { get; set; }
		public int? magic1 { get; set; }
		public int? magic2 { get; set; }
		public int? magic3 { get; set; }
		public int? max_range { get; set; }
		public int? atk_speed { get; set; }
		public int? nicety { get; set; }
		public int? pack_size { get; set; }
		public int? pack_width { get; set; }
		public int? max_atk { get; set; }
		public int? min_atk { get; set; }
		public int? hot_atk { get; set; }
		public int? shake_atk { get; set; }
		public int? sting_atk { get; set; }
		public int? decay_atk { get; set; }
		public int? defence_max { get; set; }
		public int? defence_percent { get; set; }
		public int? hot_def { get; set; }
		public int? shake_def { get; set; }
		public int? cold_def { get; set; }
		public int? light_def { get; set; }
		public int? shape { get; set; }
		public int? Emoney { get; set; }
		public int? Req_Engine { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_itemtype_copy")
				.Select(
					"cq_itemtype_copy.id",
					"cq_itemtype_copy.name",
					"cq_itemtype_copy.level",
					"cq_itemtype_copy.weight",
					"cq_itemtype_copy.price",
					"cq_itemtype_copy.id_action",
					"cq_itemtype_copy.life",
					"cq_itemtype_copy.max_en",
					"cq_itemtype_copy.charge_en",
					"cq_itemtype_copy.max_power",
					"cq_itemtype_copy.charge_power",
					"cq_itemtype_copy.amount_limit",
					"cq_itemtype_copy.ident",
					"cq_itemtype_copy.equip_type",
					"cq_itemtype_copy.equip_level",
					"cq_itemtype_copy.equip_skill",
					"cq_itemtype_copy.gem1",
					"cq_itemtype_copy.gem2",
					"cq_itemtype_copy.magic1",
					"cq_itemtype_copy.magic2",
					"cq_itemtype_copy.magic3",
					"cq_itemtype_copy.max_range",
					"cq_itemtype_copy.atk_speed",
					"cq_itemtype_copy.nicety",
					"cq_itemtype_copy.pack_size",
					"cq_itemtype_copy.pack_width",
					"cq_itemtype_copy.max_atk",
					"cq_itemtype_copy.min_atk",
					"cq_itemtype_copy.hot_atk",
					"cq_itemtype_copy.shake_atk",
					"cq_itemtype_copy.sting_atk",
					"cq_itemtype_copy.decay_atk",
					"cq_itemtype_copy.defence_max",
					"cq_itemtype_copy.defence_percent",
					"cq_itemtype_copy.hot_def",
					"cq_itemtype_copy.shake_def",
					"cq_itemtype_copy.cold_def",
					"cq_itemtype_copy.light_def",
					"cq_itemtype_copy.shape",
					"cq_itemtype_copy.Emoney",
					"cq_itemtype_copy.Req_Engine"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_itemtype_copy")
                        .Select("cq_itemtype_copy.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_itemtype_copy.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_itemtype_copy.name","%" + this.name.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_itemtype_copy.level","%" + this.level.ToString() + "%");
			}
			if(this.weight != null)
			{
				result = result.WhereLike("cq_itemtype_copy.weight","%" + this.weight.ToString() + "%");
			}
			if(this.price != null)
			{
				result = result.WhereLike("cq_itemtype_copy.price","%" + this.price.ToString() + "%");
			}
			if(this.id_action != null)
			{
				result = result.WhereLike("cq_itemtype_copy.id_action","%" + this.id_action.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_itemtype_copy.life","%" + this.life.ToString() + "%");
			}
			if(this.max_en != null)
			{
				result = result.WhereLike("cq_itemtype_copy.max_en","%" + this.max_en.ToString() + "%");
			}
			if(this.charge_en != null)
			{
				result = result.WhereLike("cq_itemtype_copy.charge_en","%" + this.charge_en.ToString() + "%");
			}
			if(this.max_power != null)
			{
				result = result.WhereLike("cq_itemtype_copy.max_power","%" + this.max_power.ToString() + "%");
			}
			if(this.charge_power != null)
			{
				result = result.WhereLike("cq_itemtype_copy.charge_power","%" + this.charge_power.ToString() + "%");
			}
			if(this.amount_limit != null)
			{
				result = result.WhereLike("cq_itemtype_copy.amount_limit","%" + this.amount_limit.ToString() + "%");
			}
			if(this.ident != null)
			{
				result = result.WhereLike("cq_itemtype_copy.ident","%" + this.ident.ToString() + "%");
			}
			if(this.equip_type != null)
			{
				result = result.WhereLike("cq_itemtype_copy.equip_type","%" + this.equip_type.ToString() + "%");
			}
			if(this.equip_level != null)
			{
				result = result.WhereLike("cq_itemtype_copy.equip_level","%" + this.equip_level.ToString() + "%");
			}
			if(this.equip_skill != null)
			{
				result = result.WhereLike("cq_itemtype_copy.equip_skill","%" + this.equip_skill.ToString() + "%");
			}
			if(this.gem1 != null)
			{
				result = result.WhereLike("cq_itemtype_copy.gem1","%" + this.gem1.ToString() + "%");
			}
			if(this.gem2 != null)
			{
				result = result.WhereLike("cq_itemtype_copy.gem2","%" + this.gem2.ToString() + "%");
			}
			if(this.magic1 != null)
			{
				result = result.WhereLike("cq_itemtype_copy.magic1","%" + this.magic1.ToString() + "%");
			}
			if(this.magic2 != null)
			{
				result = result.WhereLike("cq_itemtype_copy.magic2","%" + this.magic2.ToString() + "%");
			}
			if(this.magic3 != null)
			{
				result = result.WhereLike("cq_itemtype_copy.magic3","%" + this.magic3.ToString() + "%");
			}
			if(this.max_range != null)
			{
				result = result.WhereLike("cq_itemtype_copy.max_range","%" + this.max_range.ToString() + "%");
			}
			if(this.atk_speed != null)
			{
				result = result.WhereLike("cq_itemtype_copy.atk_speed","%" + this.atk_speed.ToString() + "%");
			}
			if(this.nicety != null)
			{
				result = result.WhereLike("cq_itemtype_copy.nicety","%" + this.nicety.ToString() + "%");
			}
			if(this.pack_size != null)
			{
				result = result.WhereLike("cq_itemtype_copy.pack_size","%" + this.pack_size.ToString() + "%");
			}
			if(this.pack_width != null)
			{
				result = result.WhereLike("cq_itemtype_copy.pack_width","%" + this.pack_width.ToString() + "%");
			}
			if(this.max_atk != null)
			{
				result = result.WhereLike("cq_itemtype_copy.max_atk","%" + this.max_atk.ToString() + "%");
			}
			if(this.min_atk != null)
			{
				result = result.WhereLike("cq_itemtype_copy.min_atk","%" + this.min_atk.ToString() + "%");
			}
			if(this.hot_atk != null)
			{
				result = result.WhereLike("cq_itemtype_copy.hot_atk","%" + this.hot_atk.ToString() + "%");
			}
			if(this.shake_atk != null)
			{
				result = result.WhereLike("cq_itemtype_copy.shake_atk","%" + this.shake_atk.ToString() + "%");
			}
			if(this.sting_atk != null)
			{
				result = result.WhereLike("cq_itemtype_copy.sting_atk","%" + this.sting_atk.ToString() + "%");
			}
			if(this.decay_atk != null)
			{
				result = result.WhereLike("cq_itemtype_copy.decay_atk","%" + this.decay_atk.ToString() + "%");
			}
			if(this.defence_max != null)
			{
				result = result.WhereLike("cq_itemtype_copy.defence_max","%" + this.defence_max.ToString() + "%");
			}
			if(this.defence_percent != null)
			{
				result = result.WhereLike("cq_itemtype_copy.defence_percent","%" + this.defence_percent.ToString() + "%");
			}
			if(this.hot_def != null)
			{
				result = result.WhereLike("cq_itemtype_copy.hot_def","%" + this.hot_def.ToString() + "%");
			}
			if(this.shake_def != null)
			{
				result = result.WhereLike("cq_itemtype_copy.shake_def","%" + this.shake_def.ToString() + "%");
			}
			if(this.cold_def != null)
			{
				result = result.WhereLike("cq_itemtype_copy.cold_def","%" + this.cold_def.ToString() + "%");
			}
			if(this.light_def != null)
			{
				result = result.WhereLike("cq_itemtype_copy.light_def","%" + this.light_def.ToString() + "%");
			}
			if(this.shape != null)
			{
				result = result.WhereLike("cq_itemtype_copy.shape","%" + this.shape.ToString() + "%");
			}
			if(this.Emoney != null)
			{
				result = result.WhereLike("cq_itemtype_copy.Emoney","%" + this.Emoney.ToString() + "%");
			}
			if(this.Req_Engine != null)
			{
				result = result.WhereLike("cq_itemtype_copy.Req_Engine","%" + this.Req_Engine.ToString() + "%");
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