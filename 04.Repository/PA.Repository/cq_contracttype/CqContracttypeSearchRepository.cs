using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqContracttypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? maxlv_header { get; set; }
		public int? minlv_header { get; set; }
		public int? maxlv_member { get; set; }
		public int? minlv_member { get; set; }
		public int? item { get; set; }
		public int? money { get; set; }
		public int? sociality { get; set; }
		public int? time { get; set; }
		public int? troop { get; set; }
		public int? magic1 { get; set; }
		public int? magic2 { get; set; }
		public int? magic3 { get; set; }
		public int? magic4 { get; set; }
		public int? magic5 { get; set; }
		public int? magic6 { get; set; }
		public int? maxhp_adj { get; set; }
		public int? maxen_adj { get; set; }
		public int? maxfu_adj { get; set; }
		public int? maxxp_adj { get; set; }
		public int? hp_regenerate { get; set; }
		public int? en_regenerate { get; set; }
		public int? fu_regenerate { get; set; }
		public int? troop_skill_id { get; set; }
		public int? sociality_id { get; set; }
		public int? rate_affect { get; set; }
		public int? stone_expend { get; set; }
		public int? req_sort { get; set; }
		public int? range { get; set; }
		public int? equip { get; set; }
		public int? def { get; set; }
		public int? hot_def { get; set; }
		public int? shake_def { get; set; }
		public int? sting_def { get; set; }
		public int? decay_def { get; set; }
		public int? pk_def { get; set; }
		public int? status_immunity { get; set; }
		public int? lv_contrast { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_contracttype")
				.Select(
					"cq_contracttype.id",
					"cq_contracttype.name",
					"cq_contracttype.maxlv_header",
					"cq_contracttype.minlv_header",
					"cq_contracttype.maxlv_member",
					"cq_contracttype.minlv_member",
					"cq_contracttype.item",
					"cq_contracttype.money",
					"cq_contracttype.sociality",
					"cq_contracttype.time",
					"cq_contracttype.troop",
					"cq_contracttype.magic1",
					"cq_contracttype.magic2",
					"cq_contracttype.magic3",
					"cq_contracttype.magic4",
					"cq_contracttype.magic5",
					"cq_contracttype.magic6",
					"cq_contracttype.maxhp_adj",
					"cq_contracttype.maxen_adj",
					"cq_contracttype.maxfu_adj",
					"cq_contracttype.maxxp_adj",
					"cq_contracttype.hp_regenerate",
					"cq_contracttype.en_regenerate",
					"cq_contracttype.fu_regenerate",
					"cq_contracttype.troop_skill_id",
					"cq_contracttype.sociality_id",
					"cq_contracttype.rate_affect",
					"cq_contracttype.stone_expend",
					"cq_contracttype.req_sort",
					"cq_contracttype.range",
					"cq_contracttype.equip",
					"cq_contracttype.def",
					"cq_contracttype.hot_def",
					"cq_contracttype.shake_def",
					"cq_contracttype.sting_def",
					"cq_contracttype.decay_def",
					"cq_contracttype.pk_def",
					"cq_contracttype.status_immunity",
					"cq_contracttype.lv_contrast"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_contracttype")
                        .Select("cq_contracttype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_contracttype.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_contracttype.name","%" + this.name.ToString() + "%");
			}
			if(this.maxlv_header != null)
			{
				result = result.WhereLike("cq_contracttype.maxlv_header","%" + this.maxlv_header.ToString() + "%");
			}
			if(this.minlv_header != null)
			{
				result = result.WhereLike("cq_contracttype.minlv_header","%" + this.minlv_header.ToString() + "%");
			}
			if(this.maxlv_member != null)
			{
				result = result.WhereLike("cq_contracttype.maxlv_member","%" + this.maxlv_member.ToString() + "%");
			}
			if(this.minlv_member != null)
			{
				result = result.WhereLike("cq_contracttype.minlv_member","%" + this.minlv_member.ToString() + "%");
			}
			if(this.item != null)
			{
				result = result.WhereLike("cq_contracttype.item","%" + this.item.ToString() + "%");
			}
			if(this.money != null)
			{
				result = result.WhereLike("cq_contracttype.money","%" + this.money.ToString() + "%");
			}
			if(this.sociality != null)
			{
				result = result.WhereLike("cq_contracttype.sociality","%" + this.sociality.ToString() + "%");
			}
			if(this.time != null)
			{
				result = result.WhereLike("cq_contracttype.time","%" + this.time.ToString() + "%");
			}
			if(this.troop != null)
			{
				result = result.WhereLike("cq_contracttype.troop","%" + this.troop.ToString() + "%");
			}
			if(this.magic1 != null)
			{
				result = result.WhereLike("cq_contracttype.magic1","%" + this.magic1.ToString() + "%");
			}
			if(this.magic2 != null)
			{
				result = result.WhereLike("cq_contracttype.magic2","%" + this.magic2.ToString() + "%");
			}
			if(this.magic3 != null)
			{
				result = result.WhereLike("cq_contracttype.magic3","%" + this.magic3.ToString() + "%");
			}
			if(this.magic4 != null)
			{
				result = result.WhereLike("cq_contracttype.magic4","%" + this.magic4.ToString() + "%");
			}
			if(this.magic5 != null)
			{
				result = result.WhereLike("cq_contracttype.magic5","%" + this.magic5.ToString() + "%");
			}
			if(this.magic6 != null)
			{
				result = result.WhereLike("cq_contracttype.magic6","%" + this.magic6.ToString() + "%");
			}
			if(this.maxhp_adj != null)
			{
				result = result.WhereLike("cq_contracttype.maxhp_adj","%" + this.maxhp_adj.ToString() + "%");
			}
			if(this.maxen_adj != null)
			{
				result = result.WhereLike("cq_contracttype.maxen_adj","%" + this.maxen_adj.ToString() + "%");
			}
			if(this.maxfu_adj != null)
			{
				result = result.WhereLike("cq_contracttype.maxfu_adj","%" + this.maxfu_adj.ToString() + "%");
			}
			if(this.maxxp_adj != null)
			{
				result = result.WhereLike("cq_contracttype.maxxp_adj","%" + this.maxxp_adj.ToString() + "%");
			}
			if(this.hp_regenerate != null)
			{
				result = result.WhereLike("cq_contracttype.hp_regenerate","%" + this.hp_regenerate.ToString() + "%");
			}
			if(this.en_regenerate != null)
			{
				result = result.WhereLike("cq_contracttype.en_regenerate","%" + this.en_regenerate.ToString() + "%");
			}
			if(this.fu_regenerate != null)
			{
				result = result.WhereLike("cq_contracttype.fu_regenerate","%" + this.fu_regenerate.ToString() + "%");
			}
			if(this.troop_skill_id != null)
			{
				result = result.WhereLike("cq_contracttype.troop_skill_id","%" + this.troop_skill_id.ToString() + "%");
			}
			if(this.sociality_id != null)
			{
				result = result.WhereLike("cq_contracttype.sociality_id","%" + this.sociality_id.ToString() + "%");
			}
			if(this.rate_affect != null)
			{
				result = result.WhereLike("cq_contracttype.rate_affect","%" + this.rate_affect.ToString() + "%");
			}
			if(this.stone_expend != null)
			{
				result = result.WhereLike("cq_contracttype.stone_expend","%" + this.stone_expend.ToString() + "%");
			}
			if(this.req_sort != null)
			{
				result = result.WhereLike("cq_contracttype.req_sort","%" + this.req_sort.ToString() + "%");
			}
			if(this.range != null)
			{
				result = result.WhereLike("cq_contracttype.range","%" + this.range.ToString() + "%");
			}
			if(this.equip != null)
			{
				result = result.WhereLike("cq_contracttype.equip","%" + this.equip.ToString() + "%");
			}
			if(this.def != null)
			{
				result = result.WhereLike("cq_contracttype.def","%" + this.def.ToString() + "%");
			}
			if(this.hot_def != null)
			{
				result = result.WhereLike("cq_contracttype.hot_def","%" + this.hot_def.ToString() + "%");
			}
			if(this.shake_def != null)
			{
				result = result.WhereLike("cq_contracttype.shake_def","%" + this.shake_def.ToString() + "%");
			}
			if(this.sting_def != null)
			{
				result = result.WhereLike("cq_contracttype.sting_def","%" + this.sting_def.ToString() + "%");
			}
			if(this.decay_def != null)
			{
				result = result.WhereLike("cq_contracttype.decay_def","%" + this.decay_def.ToString() + "%");
			}
			if(this.pk_def != null)
			{
				result = result.WhereLike("cq_contracttype.pk_def","%" + this.pk_def.ToString() + "%");
			}
			if(this.status_immunity != null)
			{
				result = result.WhereLike("cq_contracttype.status_immunity","%" + this.status_immunity.ToString() + "%");
			}
			if(this.lv_contrast != null)
			{
				result = result.WhereLike("cq_contracttype.lv_contrast","%" + this.lv_contrast.ToString() + "%");
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