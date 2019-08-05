using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDeluserSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public string mate { get; set; }
		public int? mate_id { get; set; }
		public int? lookface { get; set; }
		public int? hair { get; set; }
		public int? money { get; set; }
		public int? money_saved { get; set; }
		public int? RMB { get; set; }
		public int? level { get; set; }
		public long? exp { get; set; }
		public int? storage_lv { get; set; }
		public int? deed { get; set; }
		public int? pk { get; set; }
		public int? medal { get; set; }
		public int? storage_stone_limit { get; set; }
		public int? CreateTime { get; set; }
		public int? recordmap_id { get; set; }
		public int? recordx { get; set; }
		public int? recordy { get; set; }
		public int? account_id { get; set; }
		public int? last_login { get; set; }
		public int? task_mask { get; set; }
		public int? home_id { get; set; }
		public int? title { get; set; }
		public int? storage_weight_limit { get; set; }
		public int? lock_key { get; set; }
		public int? reborn_mapid { get; set; }
		public int? newtype_lv { get; set; }
		public int? Coach { get; set; }
		public int? Coach_time { get; set; }
		public int? Coach_date { get; set; }
		public int? virtue { get; set; }
		public int? xp_beat { get; set; }
		public int? camp { get; set; }
		public int? pkenable { get; set; }
		public int? militaryrank1 { get; set; }
		public int? militaryrank2 { get; set; }
		public int? militaryrank3 { get; set; }
		public int? militaryrank4 { get; set; }
		public int? marrytime { get; set; }
		public int? robotstorage_lev { get; set; }
		public int? accumulate { get; set; }
		public int? Emoney { get; set; }
		public int? Emoney_chk { get; set; }
		public int? money_saved2 { get; set; }
		public int? ExpBallUsage { get; set; }
		public int? status { get; set; }
		public int? stratagem { get; set; }
		public int? online_time { get; set; }
		public int? auto_exercise { get; set; }
		public int? flower { get; set; }
		public int? BagNum { get; set; }
		public int? forbitdden_words { get; set; }
		public int? CrystalPoint { get; set; }
		public int? CrystalUsage0 { get; set; }
		public int? CrystalUsage1 { get; set; }
		public int? CrystalUsage2 { get; set; }
		public int? CrystalUsage3 { get; set; }
		public int? CrystalUsage4 { get; set; }
		public int? password_id { get; set; }
		public int? locktime { get; set; }
		public int? chk_sum { get; set; }
		public int? flower_w { get; set; }
		public int? tutor_level { get; set; }
		public long? Tutor_exp { get; set; }
		public int? online_time2 { get; set; }
		public int? offine_time { get; set; }
		public int? last_logout2 { get; set; }
		public int? list1 { get; set; }
		public int? list2 { get; set; }
		public long? friend_share { get; set; }
		public int? Battle_lev { get; set; }
		public long? Income { get; set; }
		public int? business { get; set; }
		public int? airborne { get; set; }
		public int? emoney2 { get; set; }
		public int? Emoney3 { get; set; }
		public int? Emoney3_chk { get; set; }
		public long? donation { get; set; }
		public int? login_time { get; set; }
		public string ip { get; set; }
		public int? brother_team_id { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_deluser")
				.Select(
					"cq_deluser.id",
					"cq_deluser.name",
					"cq_deluser.mate",
					"cq_deluser.mate_id",
					"cq_deluser.lookface",
					"cq_deluser.hair",
					"cq_deluser.money",
					"cq_deluser.money_saved",
					"cq_deluser.RMB",
					"cq_deluser.level",
					"cq_deluser.exp",
					"cq_deluser.storage_lv",
					"cq_deluser.deed",
					"cq_deluser.pk",
					"cq_deluser.medal",
					"cq_deluser.storage_stone_limit",
					"cq_deluser.CreateTime",
					"cq_deluser.recordmap_id",
					"cq_deluser.recordx",
					"cq_deluser.recordy",
					"cq_deluser.account_id",
					"cq_deluser.last_login",
					"cq_deluser.task_mask",
					"cq_deluser.home_id",
					"cq_deluser.title",
					"cq_deluser.storage_weight_limit",
					"cq_deluser.lock_key",
					"cq_deluser.reborn_mapid",
					"cq_deluser.newtype_lv",
					"cq_deluser.Coach",
					"cq_deluser.Coach_time",
					"cq_deluser.Coach_date",
					"cq_deluser.virtue",
					"cq_deluser.xp_beat",
					"cq_deluser.camp",
					"cq_deluser.pkenable",
					"cq_deluser.militaryrank1",
					"cq_deluser.militaryrank2",
					"cq_deluser.militaryrank3",
					"cq_deluser.militaryrank4",
					"cq_deluser.marrytime",
					"cq_deluser.robotstorage_lev",
					"cq_deluser.accumulate",
					"cq_deluser.Emoney",
					"cq_deluser.Emoney_chk",
					"cq_deluser.money_saved2",
					"cq_deluser.ExpBallUsage",
					"cq_deluser.status",
					"cq_deluser.stratagem",
					"cq_deluser.online_time",
					"cq_deluser.auto_exercise",
					"cq_deluser.flower",
					"cq_deluser.BagNum",
					"cq_deluser.forbitdden_words",
					"cq_deluser.CrystalPoint",
					"cq_deluser.CrystalUsage0",
					"cq_deluser.CrystalUsage1",
					"cq_deluser.CrystalUsage2",
					"cq_deluser.CrystalUsage3",
					"cq_deluser.CrystalUsage4",
					"cq_deluser.password_id",
					"cq_deluser.locktime",
					"cq_deluser.chk_sum",
					"cq_deluser.flower_w",
					"cq_deluser.tutor_level",
					"cq_deluser.Tutor_exp",
					"cq_deluser.online_time2",
					"cq_deluser.offine_time",
					"cq_deluser.last_logout2",
					"cq_deluser.list1",
					"cq_deluser.list2",
					"cq_deluser.friend_share",
					"cq_deluser.Battle_lev",
					"cq_deluser.Income",
					"cq_deluser.business",
					"cq_deluser.airborne",
					"cq_deluser.emoney2",
					"cq_deluser.Emoney3",
					"cq_deluser.Emoney3_chk",
					"cq_deluser.donation",
					"cq_deluser.login_time",
					"cq_deluser.ip",
					"cq_deluser.brother_team_id"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_deluser")
                        .Select("cq_deluser.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_deluser.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_deluser.name","%" + this.name.ToString() + "%");
			}
			if(this.mate != null)
			{
				result = result.WhereLike("cq_deluser.mate","%" + this.mate.ToString() + "%");
			}
			if(this.mate_id != null)
			{
				result = result.WhereLike("cq_deluser.mate_id","%" + this.mate_id.ToString() + "%");
			}
			if(this.lookface != null)
			{
				result = result.WhereLike("cq_deluser.lookface","%" + this.lookface.ToString() + "%");
			}
			if(this.hair != null)
			{
				result = result.WhereLike("cq_deluser.hair","%" + this.hair.ToString() + "%");
			}
			if(this.money != null)
			{
				result = result.WhereLike("cq_deluser.money","%" + this.money.ToString() + "%");
			}
			if(this.money_saved != null)
			{
				result = result.WhereLike("cq_deluser.money_saved","%" + this.money_saved.ToString() + "%");
			}
			if(this.RMB != null)
			{
				result = result.WhereLike("cq_deluser.RMB","%" + this.RMB.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_deluser.level","%" + this.level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_deluser.exp","%" + this.exp.ToString() + "%");
			}
			if(this.storage_lv != null)
			{
				result = result.WhereLike("cq_deluser.storage_lv","%" + this.storage_lv.ToString() + "%");
			}
			if(this.deed != null)
			{
				result = result.WhereLike("cq_deluser.deed","%" + this.deed.ToString() + "%");
			}
			if(this.pk != null)
			{
				result = result.WhereLike("cq_deluser.pk","%" + this.pk.ToString() + "%");
			}
			if(this.medal != null)
			{
				result = result.WhereLike("cq_deluser.medal","%" + this.medal.ToString() + "%");
			}
			if(this.storage_stone_limit != null)
			{
				result = result.WhereLike("cq_deluser.storage_stone_limit","%" + this.storage_stone_limit.ToString() + "%");
			}
			if(this.CreateTime != null)
			{
				result = result.WhereLike("cq_deluser.CreateTime","%" + this.CreateTime.ToString() + "%");
			}
			if(this.recordmap_id != null)
			{
				result = result.WhereLike("cq_deluser.recordmap_id","%" + this.recordmap_id.ToString() + "%");
			}
			if(this.recordx != null)
			{
				result = result.WhereLike("cq_deluser.recordx","%" + this.recordx.ToString() + "%");
			}
			if(this.recordy != null)
			{
				result = result.WhereLike("cq_deluser.recordy","%" + this.recordy.ToString() + "%");
			}
			if(this.account_id != null)
			{
				result = result.WhereLike("cq_deluser.account_id","%" + this.account_id.ToString() + "%");
			}
			if(this.last_login != null)
			{
				result = result.WhereLike("cq_deluser.last_login","%" + this.last_login.ToString() + "%");
			}
			if(this.task_mask != null)
			{
				result = result.WhereLike("cq_deluser.task_mask","%" + this.task_mask.ToString() + "%");
			}
			if(this.home_id != null)
			{
				result = result.WhereLike("cq_deluser.home_id","%" + this.home_id.ToString() + "%");
			}
			if(this.title != null)
			{
				result = result.WhereLike("cq_deluser.title","%" + this.title.ToString() + "%");
			}
			if(this.storage_weight_limit != null)
			{
				result = result.WhereLike("cq_deluser.storage_weight_limit","%" + this.storage_weight_limit.ToString() + "%");
			}
			if(this.lock_key != null)
			{
				result = result.WhereLike("cq_deluser.lock_key","%" + this.lock_key.ToString() + "%");
			}
			if(this.reborn_mapid != null)
			{
				result = result.WhereLike("cq_deluser.reborn_mapid","%" + this.reborn_mapid.ToString() + "%");
			}
			if(this.newtype_lv != null)
			{
				result = result.WhereLike("cq_deluser.newtype_lv","%" + this.newtype_lv.ToString() + "%");
			}
			if(this.Coach != null)
			{
				result = result.WhereLike("cq_deluser.Coach","%" + this.Coach.ToString() + "%");
			}
			if(this.Coach_time != null)
			{
				result = result.WhereLike("cq_deluser.Coach_time","%" + this.Coach_time.ToString() + "%");
			}
			if(this.Coach_date != null)
			{
				result = result.WhereLike("cq_deluser.Coach_date","%" + this.Coach_date.ToString() + "%");
			}
			if(this.virtue != null)
			{
				result = result.WhereLike("cq_deluser.virtue","%" + this.virtue.ToString() + "%");
			}
			if(this.xp_beat != null)
			{
				result = result.WhereLike("cq_deluser.xp_beat","%" + this.xp_beat.ToString() + "%");
			}
			if(this.camp != null)
			{
				result = result.WhereLike("cq_deluser.camp","%" + this.camp.ToString() + "%");
			}
			if(this.pkenable != null)
			{
				result = result.WhereLike("cq_deluser.pkenable","%" + this.pkenable.ToString() + "%");
			}
			if(this.militaryrank1 != null)
			{
				result = result.WhereLike("cq_deluser.militaryrank1","%" + this.militaryrank1.ToString() + "%");
			}
			if(this.militaryrank2 != null)
			{
				result = result.WhereLike("cq_deluser.militaryrank2","%" + this.militaryrank2.ToString() + "%");
			}
			if(this.militaryrank3 != null)
			{
				result = result.WhereLike("cq_deluser.militaryrank3","%" + this.militaryrank3.ToString() + "%");
			}
			if(this.militaryrank4 != null)
			{
				result = result.WhereLike("cq_deluser.militaryrank4","%" + this.militaryrank4.ToString() + "%");
			}
			if(this.marrytime != null)
			{
				result = result.WhereLike("cq_deluser.marrytime","%" + this.marrytime.ToString() + "%");
			}
			if(this.robotstorage_lev != null)
			{
				result = result.WhereLike("cq_deluser.robotstorage_lev","%" + this.robotstorage_lev.ToString() + "%");
			}
			if(this.accumulate != null)
			{
				result = result.WhereLike("cq_deluser.accumulate","%" + this.accumulate.ToString() + "%");
			}
			if(this.Emoney != null)
			{
				result = result.WhereLike("cq_deluser.Emoney","%" + this.Emoney.ToString() + "%");
			}
			if(this.Emoney_chk != null)
			{
				result = result.WhereLike("cq_deluser.Emoney_chk","%" + this.Emoney_chk.ToString() + "%");
			}
			if(this.money_saved2 != null)
			{
				result = result.WhereLike("cq_deluser.money_saved2","%" + this.money_saved2.ToString() + "%");
			}
			if(this.ExpBallUsage != null)
			{
				result = result.WhereLike("cq_deluser.ExpBallUsage","%" + this.ExpBallUsage.ToString() + "%");
			}
			if(this.status != null)
			{
				result = result.WhereLike("cq_deluser.status","%" + this.status.ToString() + "%");
			}
			if(this.stratagem != null)
			{
				result = result.WhereLike("cq_deluser.stratagem","%" + this.stratagem.ToString() + "%");
			}
			if(this.online_time != null)
			{
				result = result.WhereLike("cq_deluser.online_time","%" + this.online_time.ToString() + "%");
			}
			if(this.auto_exercise != null)
			{
				result = result.WhereLike("cq_deluser.auto_exercise","%" + this.auto_exercise.ToString() + "%");
			}
			if(this.flower != null)
			{
				result = result.WhereLike("cq_deluser.flower","%" + this.flower.ToString() + "%");
			}
			if(this.BagNum != null)
			{
				result = result.WhereLike("cq_deluser.BagNum","%" + this.BagNum.ToString() + "%");
			}
			if(this.forbitdden_words != null)
			{
				result = result.WhereLike("cq_deluser.forbitdden_words","%" + this.forbitdden_words.ToString() + "%");
			}
			if(this.CrystalPoint != null)
			{
				result = result.WhereLike("cq_deluser.CrystalPoint","%" + this.CrystalPoint.ToString() + "%");
			}
			if(this.CrystalUsage0 != null)
			{
				result = result.WhereLike("cq_deluser.CrystalUsage0","%" + this.CrystalUsage0.ToString() + "%");
			}
			if(this.CrystalUsage1 != null)
			{
				result = result.WhereLike("cq_deluser.CrystalUsage1","%" + this.CrystalUsage1.ToString() + "%");
			}
			if(this.CrystalUsage2 != null)
			{
				result = result.WhereLike("cq_deluser.CrystalUsage2","%" + this.CrystalUsage2.ToString() + "%");
			}
			if(this.CrystalUsage3 != null)
			{
				result = result.WhereLike("cq_deluser.CrystalUsage3","%" + this.CrystalUsage3.ToString() + "%");
			}
			if(this.CrystalUsage4 != null)
			{
				result = result.WhereLike("cq_deluser.CrystalUsage4","%" + this.CrystalUsage4.ToString() + "%");
			}
			if(this.password_id != null)
			{
				result = result.WhereLike("cq_deluser.password_id","%" + this.password_id.ToString() + "%");
			}
			if(this.locktime != null)
			{
				result = result.WhereLike("cq_deluser.locktime","%" + this.locktime.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_deluser.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.flower_w != null)
			{
				result = result.WhereLike("cq_deluser.flower_w","%" + this.flower_w.ToString() + "%");
			}
			if(this.tutor_level != null)
			{
				result = result.WhereLike("cq_deluser.tutor_level","%" + this.tutor_level.ToString() + "%");
			}
			if(this.Tutor_exp != null)
			{
				result = result.WhereLike("cq_deluser.Tutor_exp","%" + this.Tutor_exp.ToString() + "%");
			}
			if(this.online_time2 != null)
			{
				result = result.WhereLike("cq_deluser.online_time2","%" + this.online_time2.ToString() + "%");
			}
			if(this.offine_time != null)
			{
				result = result.WhereLike("cq_deluser.offine_time","%" + this.offine_time.ToString() + "%");
			}
			if(this.last_logout2 != null)
			{
				result = result.WhereLike("cq_deluser.last_logout2","%" + this.last_logout2.ToString() + "%");
			}
			if(this.list1 != null)
			{
				result = result.WhereLike("cq_deluser.list1","%" + this.list1.ToString() + "%");
			}
			if(this.list2 != null)
			{
				result = result.WhereLike("cq_deluser.list2","%" + this.list2.ToString() + "%");
			}
			if(this.friend_share != null)
			{
				result = result.WhereLike("cq_deluser.friend_share","%" + this.friend_share.ToString() + "%");
			}
			if(this.Battle_lev != null)
			{
				result = result.WhereLike("cq_deluser.Battle_lev","%" + this.Battle_lev.ToString() + "%");
			}
			if(this.Income != null)
			{
				result = result.WhereLike("cq_deluser.Income","%" + this.Income.ToString() + "%");
			}
			if(this.business != null)
			{
				result = result.WhereLike("cq_deluser.business","%" + this.business.ToString() + "%");
			}
			if(this.airborne != null)
			{
				result = result.WhereLike("cq_deluser.airborne","%" + this.airborne.ToString() + "%");
			}
			if(this.emoney2 != null)
			{
				result = result.WhereLike("cq_deluser.emoney2","%" + this.emoney2.ToString() + "%");
			}
			if(this.Emoney3 != null)
			{
				result = result.WhereLike("cq_deluser.Emoney3","%" + this.Emoney3.ToString() + "%");
			}
			if(this.Emoney3_chk != null)
			{
				result = result.WhereLike("cq_deluser.Emoney3_chk","%" + this.Emoney3_chk.ToString() + "%");
			}
			if(this.donation != null)
			{
				result = result.WhereLike("cq_deluser.donation","%" + this.donation.ToString() + "%");
			}
			if(this.login_time != null)
			{
				result = result.WhereLike("cq_deluser.login_time","%" + this.login_time.ToString() + "%");
			}
			if(this.ip != null)
			{
				result = result.WhereLike("cq_deluser.ip","%" + this.ip.ToString() + "%");
			}
			if(this.brother_team_id != null)
			{
				result = result.WhereLike("cq_deluser.brother_team_id","%" + this.brother_team_id.ToString() + "%");
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