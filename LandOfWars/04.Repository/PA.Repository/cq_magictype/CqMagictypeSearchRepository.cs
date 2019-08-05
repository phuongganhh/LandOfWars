using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMagictypeSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? sort { get; set; }
		public string name { get; set; }
		public int? crime { get; set; }
		public int? ground { get; set; }
		public int? multi { get; set; }
		public int? target { get; set; }
		public int? immunity { get; set; }
		public int? passive { get; set; }
		public int? loop { get; set; }
		public int? intone_ms { get; set; }
		public int? delay_ms { get; set; }
		public int? step_secs { get; set; }
		public int? active_times { get; set; }
		public int? power { get; set; }
		public int? data { get; set; }
		public int? percent { get; set; }
		public int? distance { get; set; }
		public int? range { get; set; }
		public int? width { get; set; }
		public int? need_weapon { get; set; }
		public int? need_ammo { get; set; }
		public int? expend_life { get; set; }
		public int? expend_mana { get; set; }
		public int? expend_fuel { get; set; }
		public int? expend_xp { get; set; }
		public int? expend_ammo { get; set; }
		public int? status { get; set; }
		public int? pos { get; set; }
		public int? mode { get; set; }
		public int? attack { get; set; }
		public int? atk_fighter { get; set; }
		public int? atk_gunner { get; set; }
		public int? atk_energy { get; set; }
		public int? atk_hot { get; set; }
		public int? atk_shake { get; set; }
		public int? atk_sting { get; set; }
		public int? atk_decay { get; set; }
		public int? atk_final { get; set; }
		public int? subskill1 { get; set; }
		public int? subskill2 { get; set; }
		public int? subskill3 { get; set; }
		public int? subskill4 { get; set; }
		public int? subskill5 { get; set; }
		public int? capacity { get; set; }
		public int? delay_chgskill { get; set; }
		public int? forbidatktype { get; set; }
		public int? reinforce_team { get; set; }
		public int? reinforce_self { get; set; }
		public int? classify { get; set; }
		public int? robot_sort { get; set; }
		public int? robot_lv { get; set; }
		public int? translook { get; set; }
		public int? together { get; set; }
		public int? usufruct { get; set; }
		public int? need_exp { get; set; }
		public int? Action { get; set; }
		public int? Uplevtime { get; set; }
		public int? robot_model_lev { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_magictype")
				.Select(
					"cq_magictype.id",
					"cq_magictype.sort",
					"cq_magictype.name",
					"cq_magictype.crime",
					"cq_magictype.ground",
					"cq_magictype.multi",
					"cq_magictype.target",
					"cq_magictype.immunity",
					"cq_magictype.passive",
					"cq_magictype.loop",
					"cq_magictype.intone_ms",
					"cq_magictype.delay_ms",
					"cq_magictype.step_secs",
					"cq_magictype.active_times",
					"cq_magictype.power",
					"cq_magictype.data",
					"cq_magictype.percent",
					"cq_magictype.distance",
					"cq_magictype.range",
					"cq_magictype.width",
					"cq_magictype.need_weapon",
					"cq_magictype.need_ammo",
					"cq_magictype.expend_life",
					"cq_magictype.expend_mana",
					"cq_magictype.expend_fuel",
					"cq_magictype.expend_xp",
					"cq_magictype.expend_ammo",
					"cq_magictype.status",
					"cq_magictype.pos",
					"cq_magictype.mode",
					"cq_magictype.attack",
					"cq_magictype.atk_fighter",
					"cq_magictype.atk_gunner",
					"cq_magictype.atk_energy",
					"cq_magictype.atk_hot",
					"cq_magictype.atk_shake",
					"cq_magictype.atk_sting",
					"cq_magictype.atk_decay",
					"cq_magictype.atk_final",
					"cq_magictype.subskill1",
					"cq_magictype.subskill2",
					"cq_magictype.subskill3",
					"cq_magictype.subskill4",
					"cq_magictype.subskill5",
					"cq_magictype.capacity",
					"cq_magictype.delay_chgskill",
					"cq_magictype.forbidatktype",
					"cq_magictype.reinforce_team",
					"cq_magictype.reinforce_self",
					"cq_magictype.classify",
					"cq_magictype.robot_sort",
					"cq_magictype.robot_lv",
					"cq_magictype.translook",
					"cq_magictype.together",
					"cq_magictype.usufruct",
					"cq_magictype.need_exp",
					"cq_magictype.Action",
					"cq_magictype.Uplevtime",
					"cq_magictype.robot_model_lev"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_magictype")
                        .Select("cq_magictype.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_magictype.id","%" + this.id.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_magictype.sort","%" + this.sort.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_magictype.name","%" + this.name.ToString() + "%");
			}
			if(this.crime != null)
			{
				result = result.WhereLike("cq_magictype.crime","%" + this.crime.ToString() + "%");
			}
			if(this.ground != null)
			{
				result = result.WhereLike("cq_magictype.ground","%" + this.ground.ToString() + "%");
			}
			if(this.multi != null)
			{
				result = result.WhereLike("cq_magictype.multi","%" + this.multi.ToString() + "%");
			}
			if(this.target != null)
			{
				result = result.WhereLike("cq_magictype.target","%" + this.target.ToString() + "%");
			}
			if(this.immunity != null)
			{
				result = result.WhereLike("cq_magictype.immunity","%" + this.immunity.ToString() + "%");
			}
			if(this.passive != null)
			{
				result = result.WhereLike("cq_magictype.passive","%" + this.passive.ToString() + "%");
			}
			if(this.loop != null)
			{
				result = result.WhereLike("cq_magictype.loop","%" + this.loop.ToString() + "%");
			}
			if(this.intone_ms != null)
			{
				result = result.WhereLike("cq_magictype.intone_ms","%" + this.intone_ms.ToString() + "%");
			}
			if(this.delay_ms != null)
			{
				result = result.WhereLike("cq_magictype.delay_ms","%" + this.delay_ms.ToString() + "%");
			}
			if(this.step_secs != null)
			{
				result = result.WhereLike("cq_magictype.step_secs","%" + this.step_secs.ToString() + "%");
			}
			if(this.active_times != null)
			{
				result = result.WhereLike("cq_magictype.active_times","%" + this.active_times.ToString() + "%");
			}
			if(this.power != null)
			{
				result = result.WhereLike("cq_magictype.power","%" + this.power.ToString() + "%");
			}
			if(this.data != null)
			{
				result = result.WhereLike("cq_magictype.data","%" + this.data.ToString() + "%");
			}
			if(this.percent != null)
			{
				result = result.WhereLike("cq_magictype.percent","%" + this.percent.ToString() + "%");
			}
			if(this.distance != null)
			{
				result = result.WhereLike("cq_magictype.distance","%" + this.distance.ToString() + "%");
			}
			if(this.range != null)
			{
				result = result.WhereLike("cq_magictype.range","%" + this.range.ToString() + "%");
			}
			if(this.width != null)
			{
				result = result.WhereLike("cq_magictype.width","%" + this.width.ToString() + "%");
			}
			if(this.need_weapon != null)
			{
				result = result.WhereLike("cq_magictype.need_weapon","%" + this.need_weapon.ToString() + "%");
			}
			if(this.need_ammo != null)
			{
				result = result.WhereLike("cq_magictype.need_ammo","%" + this.need_ammo.ToString() + "%");
			}
			if(this.expend_life != null)
			{
				result = result.WhereLike("cq_magictype.expend_life","%" + this.expend_life.ToString() + "%");
			}
			if(this.expend_mana != null)
			{
				result = result.WhereLike("cq_magictype.expend_mana","%" + this.expend_mana.ToString() + "%");
			}
			if(this.expend_fuel != null)
			{
				result = result.WhereLike("cq_magictype.expend_fuel","%" + this.expend_fuel.ToString() + "%");
			}
			if(this.expend_xp != null)
			{
				result = result.WhereLike("cq_magictype.expend_xp","%" + this.expend_xp.ToString() + "%");
			}
			if(this.expend_ammo != null)
			{
				result = result.WhereLike("cq_magictype.expend_ammo","%" + this.expend_ammo.ToString() + "%");
			}
			if(this.status != null)
			{
				result = result.WhereLike("cq_magictype.status","%" + this.status.ToString() + "%");
			}
			if(this.pos != null)
			{
				result = result.WhereLike("cq_magictype.pos","%" + this.pos.ToString() + "%");
			}
			if(this.mode != null)
			{
				result = result.WhereLike("cq_magictype.mode","%" + this.mode.ToString() + "%");
			}
			if(this.attack != null)
			{
				result = result.WhereLike("cq_magictype.attack","%" + this.attack.ToString() + "%");
			}
			if(this.atk_fighter != null)
			{
				result = result.WhereLike("cq_magictype.atk_fighter","%" + this.atk_fighter.ToString() + "%");
			}
			if(this.atk_gunner != null)
			{
				result = result.WhereLike("cq_magictype.atk_gunner","%" + this.atk_gunner.ToString() + "%");
			}
			if(this.atk_energy != null)
			{
				result = result.WhereLike("cq_magictype.atk_energy","%" + this.atk_energy.ToString() + "%");
			}
			if(this.atk_hot != null)
			{
				result = result.WhereLike("cq_magictype.atk_hot","%" + this.atk_hot.ToString() + "%");
			}
			if(this.atk_shake != null)
			{
				result = result.WhereLike("cq_magictype.atk_shake","%" + this.atk_shake.ToString() + "%");
			}
			if(this.atk_sting != null)
			{
				result = result.WhereLike("cq_magictype.atk_sting","%" + this.atk_sting.ToString() + "%");
			}
			if(this.atk_decay != null)
			{
				result = result.WhereLike("cq_magictype.atk_decay","%" + this.atk_decay.ToString() + "%");
			}
			if(this.atk_final != null)
			{
				result = result.WhereLike("cq_magictype.atk_final","%" + this.atk_final.ToString() + "%");
			}
			if(this.subskill1 != null)
			{
				result = result.WhereLike("cq_magictype.subskill1","%" + this.subskill1.ToString() + "%");
			}
			if(this.subskill2 != null)
			{
				result = result.WhereLike("cq_magictype.subskill2","%" + this.subskill2.ToString() + "%");
			}
			if(this.subskill3 != null)
			{
				result = result.WhereLike("cq_magictype.subskill3","%" + this.subskill3.ToString() + "%");
			}
			if(this.subskill4 != null)
			{
				result = result.WhereLike("cq_magictype.subskill4","%" + this.subskill4.ToString() + "%");
			}
			if(this.subskill5 != null)
			{
				result = result.WhereLike("cq_magictype.subskill5","%" + this.subskill5.ToString() + "%");
			}
			if(this.capacity != null)
			{
				result = result.WhereLike("cq_magictype.capacity","%" + this.capacity.ToString() + "%");
			}
			if(this.delay_chgskill != null)
			{
				result = result.WhereLike("cq_magictype.delay_chgskill","%" + this.delay_chgskill.ToString() + "%");
			}
			if(this.forbidatktype != null)
			{
				result = result.WhereLike("cq_magictype.forbidatktype","%" + this.forbidatktype.ToString() + "%");
			}
			if(this.reinforce_team != null)
			{
				result = result.WhereLike("cq_magictype.reinforce_team","%" + this.reinforce_team.ToString() + "%");
			}
			if(this.reinforce_self != null)
			{
				result = result.WhereLike("cq_magictype.reinforce_self","%" + this.reinforce_self.ToString() + "%");
			}
			if(this.classify != null)
			{
				result = result.WhereLike("cq_magictype.classify","%" + this.classify.ToString() + "%");
			}
			if(this.robot_sort != null)
			{
				result = result.WhereLike("cq_magictype.robot_sort","%" + this.robot_sort.ToString() + "%");
			}
			if(this.robot_lv != null)
			{
				result = result.WhereLike("cq_magictype.robot_lv","%" + this.robot_lv.ToString() + "%");
			}
			if(this.translook != null)
			{
				result = result.WhereLike("cq_magictype.translook","%" + this.translook.ToString() + "%");
			}
			if(this.together != null)
			{
				result = result.WhereLike("cq_magictype.together","%" + this.together.ToString() + "%");
			}
			if(this.usufruct != null)
			{
				result = result.WhereLike("cq_magictype.usufruct","%" + this.usufruct.ToString() + "%");
			}
			if(this.need_exp != null)
			{
				result = result.WhereLike("cq_magictype.need_exp","%" + this.need_exp.ToString() + "%");
			}
			if(this.Action != null)
			{
				result = result.WhereLike("cq_magictype.Action","%" + this.Action.ToString() + "%");
			}
			if(this.Uplevtime != null)
			{
				result = result.WhereLike("cq_magictype.Uplevtime","%" + this.Uplevtime.ToString() + "%");
			}
			if(this.robot_model_lev != null)
			{
				result = result.WhereLike("cq_magictype.robot_model_lev","%" + this.robot_model_lev.ToString() + "%");
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