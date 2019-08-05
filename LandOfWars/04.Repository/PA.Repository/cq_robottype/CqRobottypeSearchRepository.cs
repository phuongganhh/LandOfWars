using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobottypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? price { get; set; }
		public int? hp { get; set; }
		public int? hp_inc { get; set; }
		public int? totalinside_size { get; set; }
		public int? sizex { get; set; }
		public int? weight { get; set; }
		public int? attack_inc { get; set; }
		public int? def_inc { get; set; }
		public int? power_inc { get; set; }
		public int? powerrevert_inc { get; set; }
		public int? en_inc { get; set; }
		public int? enrevert_inc { get; set; }
		public int? skill1 { get; set; }
		public int? skill2 { get; set; }
		public int? skill3 { get; set; }
		public int? req_lev { get; set; }
		public int? req_weaponskill { get; set; }
		public int? req_sex { get; set; }
		public int? hot_def { get; set; }
		public int? shake_def { get; set; }
		public int? cold_def { get; set; }
		public int? decay_def { get; set; }
		public int? look { get; set; }
		public string typename { get; set; }
		public int? amount_add { get; set; }
		public string Robotname { get; set; }
		public int? dodge { get; set; }
		public int? exptype { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_robottype")
				.Select(
					"cq_robottype.id",
					"cq_robottype.price",
					"cq_robottype.hp",
					"cq_robottype.hp_inc",
					"cq_robottype.totalinside_size",
					"cq_robottype.sizex",
					"cq_robottype.weight",
					"cq_robottype.attack_inc",
					"cq_robottype.def_inc",
					"cq_robottype.power_inc",
					"cq_robottype.powerrevert_inc",
					"cq_robottype.en_inc",
					"cq_robottype.enrevert_inc",
					"cq_robottype.skill1",
					"cq_robottype.skill2",
					"cq_robottype.skill3",
					"cq_robottype.req_lev",
					"cq_robottype.req_weaponskill",
					"cq_robottype.req_sex",
					"cq_robottype.hot_def",
					"cq_robottype.shake_def",
					"cq_robottype.cold_def",
					"cq_robottype.decay_def",
					"cq_robottype.look",
					"cq_robottype.typename",
					"cq_robottype.amount_add",
					"cq_robottype.Robotname",
					"cq_robottype.dodge",
					"cq_robottype.exptype"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_robottype")
                        .Select("cq_robottype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_robottype.id","%" + this.id.ToString() + "%");
			}
			if(this.price != null)
			{
				result = result.WhereLike("cq_robottype.price","%" + this.price.ToString() + "%");
			}
			if(this.hp != null)
			{
				result = result.WhereLike("cq_robottype.hp","%" + this.hp.ToString() + "%");
			}
			if(this.hp_inc != null)
			{
				result = result.WhereLike("cq_robottype.hp_inc","%" + this.hp_inc.ToString() + "%");
			}
			if(this.totalinside_size != null)
			{
				result = result.WhereLike("cq_robottype.totalinside_size","%" + this.totalinside_size.ToString() + "%");
			}
			if(this.sizex != null)
			{
				result = result.WhereLike("cq_robottype.sizex","%" + this.sizex.ToString() + "%");
			}
			if(this.weight != null)
			{
				result = result.WhereLike("cq_robottype.weight","%" + this.weight.ToString() + "%");
			}
			if(this.attack_inc != null)
			{
				result = result.WhereLike("cq_robottype.attack_inc","%" + this.attack_inc.ToString() + "%");
			}
			if(this.def_inc != null)
			{
				result = result.WhereLike("cq_robottype.def_inc","%" + this.def_inc.ToString() + "%");
			}
			if(this.power_inc != null)
			{
				result = result.WhereLike("cq_robottype.power_inc","%" + this.power_inc.ToString() + "%");
			}
			if(this.powerrevert_inc != null)
			{
				result = result.WhereLike("cq_robottype.powerrevert_inc","%" + this.powerrevert_inc.ToString() + "%");
			}
			if(this.en_inc != null)
			{
				result = result.WhereLike("cq_robottype.en_inc","%" + this.en_inc.ToString() + "%");
			}
			if(this.enrevert_inc != null)
			{
				result = result.WhereLike("cq_robottype.enrevert_inc","%" + this.enrevert_inc.ToString() + "%");
			}
			if(this.skill1 != null)
			{
				result = result.WhereLike("cq_robottype.skill1","%" + this.skill1.ToString() + "%");
			}
			if(this.skill2 != null)
			{
				result = result.WhereLike("cq_robottype.skill2","%" + this.skill2.ToString() + "%");
			}
			if(this.skill3 != null)
			{
				result = result.WhereLike("cq_robottype.skill3","%" + this.skill3.ToString() + "%");
			}
			if(this.req_lev != null)
			{
				result = result.WhereLike("cq_robottype.req_lev","%" + this.req_lev.ToString() + "%");
			}
			if(this.req_weaponskill != null)
			{
				result = result.WhereLike("cq_robottype.req_weaponskill","%" + this.req_weaponskill.ToString() + "%");
			}
			if(this.req_sex != null)
			{
				result = result.WhereLike("cq_robottype.req_sex","%" + this.req_sex.ToString() + "%");
			}
			if(this.hot_def != null)
			{
				result = result.WhereLike("cq_robottype.hot_def","%" + this.hot_def.ToString() + "%");
			}
			if(this.shake_def != null)
			{
				result = result.WhereLike("cq_robottype.shake_def","%" + this.shake_def.ToString() + "%");
			}
			if(this.cold_def != null)
			{
				result = result.WhereLike("cq_robottype.cold_def","%" + this.cold_def.ToString() + "%");
			}
			if(this.decay_def != null)
			{
				result = result.WhereLike("cq_robottype.decay_def","%" + this.decay_def.ToString() + "%");
			}
			if(this.look != null)
			{
				result = result.WhereLike("cq_robottype.look","%" + this.look.ToString() + "%");
			}
			if(this.typename != null)
			{
				result = result.WhereLike("cq_robottype.typename","%" + this.typename.ToString() + "%");
			}
			if(this.amount_add != null)
			{
				result = result.WhereLike("cq_robottype.amount_add","%" + this.amount_add.ToString() + "%");
			}
			if(this.Robotname != null)
			{
				result = result.WhereLike("cq_robottype.Robotname","%" + this.Robotname.ToString() + "%");
			}
			if(this.dodge != null)
			{
				result = result.WhereLike("cq_robottype.dodge","%" + this.dodge.ToString() + "%");
			}
			if(this.exptype != null)
			{
				result = result.WhereLike("cq_robottype.exptype","%" + this.exptype.ToString() + "%");
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