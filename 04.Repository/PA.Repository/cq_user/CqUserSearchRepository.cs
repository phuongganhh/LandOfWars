using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
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
                .From("cq_user")
				.Select(
					"cq_user.id",
					"cq_user.name",
					"cq_user.mate",
					"cq_user.mate_id",
					"cq_user.lookface",
					"cq_user.hair",
					"cq_user.money",
					"cq_user.money_saved",
					"cq_user.RMB",
					"cq_user.level",
					"cq_user.exp",
					"cq_user.storage_lv",
					"cq_user.deed",
					"cq_user.pk",
					"cq_user.medal",
					"cq_user.storage_stone_limit",
					"cq_user.CreateTime",
					"cq_user.recordmap_id",
					"cq_user.recordx",
					"cq_user.recordy",
					"cq_user.account_id",
					"cq_user.last_login",
					"cq_user.task_mask",
					"cq_user.home_id",
					"cq_user.title",
					"cq_user.storage_weight_limit",
					"cq_user.lock_key",
					"cq_user.reborn_mapid",
					"cq_user.newtype_lv",
					"cq_user.Coach",
					"cq_user.Coach_time",
					"cq_user.Coach_date",
					"cq_user.virtue",
					"cq_user.xp_beat",
					"cq_user.camp",
					"cq_user.pkenable",
					"cq_user.militaryrank1",
					"cq_user.militaryrank2",
					"cq_user.militaryrank3",
					"cq_user.militaryrank4",
					"cq_user.marrytime",
					"cq_user.robotstorage_lev",
					"cq_user.accumulate",
					"cq_user.Emoney",
					"cq_user.Emoney_chk",
					"cq_user.money_saved2",
					"cq_user.ExpBallUsage",
					"cq_user.status",
					"cq_user.stratagem",
					"cq_user.online_time",
					"cq_user.auto_exercise",
					"cq_user.flower",
					"cq_user.BagNum",
					"cq_user.forbitdden_words",
					"cq_user.CrystalPoint",
					"cq_user.CrystalUsage0",
					"cq_user.CrystalUsage1",
					"cq_user.CrystalUsage2",
					"cq_user.CrystalUsage3",
					"cq_user.CrystalUsage4",
					"cq_user.password_id",
					"cq_user.locktime",
					"cq_user.chk_sum",
					"cq_user.flower_w",
					"cq_user.tutor_level",
					"cq_user.Tutor_exp",
					"cq_user.online_time2",
					"cq_user.offine_time",
					"cq_user.last_logout2",
					"cq_user.list1",
					"cq_user.list2",
					"cq_user.friend_share",
					"cq_user.Battle_lev",
					"cq_user.Income",
					"cq_user.business",
					"cq_user.airborne",
					"cq_user.emoney2",
					"cq_user.Emoney3",
					"cq_user.Emoney3_chk",
					"cq_user.donation",
					"cq_user.login_time",
					"cq_user.ip",
					"cq_user.brother_team_id"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_user")
                        .Select("cq_user.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_user.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_user.name","%" + this.name.ToString() + "%");
			}
			if(this.mate != null)
			{
				result = result.WhereLike("cq_user.mate","%" + this.mate.ToString() + "%");
			}
			if(this.mate_id != null)
			{
				result = result.WhereLike("cq_user.mate_id","%" + this.mate_id.ToString() + "%");
			}
			if(this.lookface != null)
			{
				result = result.WhereLike("cq_user.lookface","%" + this.lookface.ToString() + "%");
			}
			if(this.hair != null)
			{
				result = result.WhereLike("cq_user.hair","%" + this.hair.ToString() + "%");
			}
			if(this.money != null)
			{
				result = result.WhereLike("cq_user.money","%" + this.money.ToString() + "%");
			}
			if(this.money_saved != null)
			{
				result = result.WhereLike("cq_user.money_saved","%" + this.money_saved.ToString() + "%");
			}
			if(this.RMB != null)
			{
				result = result.WhereLike("cq_user.RMB","%" + this.RMB.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_user.level","%" + this.level.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_user.exp","%" + this.exp.ToString() + "%");
			}
			if(this.storage_lv != null)
			{
				result = result.WhereLike("cq_user.storage_lv","%" + this.storage_lv.ToString() + "%");
			}
			if(this.deed != null)
			{
				result = result.WhereLike("cq_user.deed","%" + this.deed.ToString() + "%");
			}
			if(this.pk != null)
			{
				result = result.WhereLike("cq_user.pk","%" + this.pk.ToString() + "%");
			}
			if(this.medal != null)
			{
				result = result.WhereLike("cq_user.medal","%" + this.medal.ToString() + "%");
			}
			if(this.storage_stone_limit != null)
			{
				result = result.WhereLike("cq_user.storage_stone_limit","%" + this.storage_stone_limit.ToString() + "%");
			}
			if(this.CreateTime != null)
			{
				result = result.WhereLike("cq_user.CreateTime","%" + this.CreateTime.ToString() + "%");
			}
			if(this.recordmap_id != null)
			{
				result = result.WhereLike("cq_user.recordmap_id","%" + this.recordmap_id.ToString() + "%");
			}
			if(this.recordx != null)
			{
				result = result.WhereLike("cq_user.recordx","%" + this.recordx.ToString() + "%");
			}
			if(this.recordy != null)
			{
				result = result.WhereLike("cq_user.recordy","%" + this.recordy.ToString() + "%");
			}
			if(this.account_id != null)
			{
				result = result.WhereLike("cq_user.account_id","%" + this.account_id.ToString() + "%");
			}
			if(this.last_login != null)
			{
				result = result.WhereLike("cq_user.last_login","%" + this.last_login.ToString() + "%");
			}
			if(this.task_mask != null)
			{
				result = result.WhereLike("cq_user.task_mask","%" + this.task_mask.ToString() + "%");
			}
			if(this.home_id != null)
			{
				result = result.WhereLike("cq_user.home_id","%" + this.home_id.ToString() + "%");
			}
			if(this.title != null)
			{
				result = result.WhereLike("cq_user.title","%" + this.title.ToString() + "%");
			}
			if(this.storage_weight_limit != null)
			{
				result = result.WhereLike("cq_user.storage_weight_limit","%" + this.storage_weight_limit.ToString() + "%");
			}
			if(this.lock_key != null)
			{
				result = result.WhereLike("cq_user.lock_key","%" + this.lock_key.ToString() + "%");
			}
			if(this.reborn_mapid != null)
			{
				result = result.WhereLike("cq_user.reborn_mapid","%" + this.reborn_mapid.ToString() + "%");
			}
			if(this.newtype_lv != null)
			{
				result = result.WhereLike("cq_user.newtype_lv","%" + this.newtype_lv.ToString() + "%");
			}
			if(this.Coach != null)
			{
				result = result.WhereLike("cq_user.Coach","%" + this.Coach.ToString() + "%");
			}
			if(this.Coach_time != null)
			{
				result = result.WhereLike("cq_user.Coach_time","%" + this.Coach_time.ToString() + "%");
			}
			if(this.Coach_date != null)
			{
				result = result.WhereLike("cq_user.Coach_date","%" + this.Coach_date.ToString() + "%");
			}
			if(this.virtue != null)
			{
				result = result.WhereLike("cq_user.virtue","%" + this.virtue.ToString() + "%");
			}
			if(this.xp_beat != null)
			{
				result = result.WhereLike("cq_user.xp_beat","%" + this.xp_beat.ToString() + "%");
			}
			if(this.camp != null)
			{
				result = result.WhereLike("cq_user.camp","%" + this.camp.ToString() + "%");
			}
			if(this.pkenable != null)
			{
				result = result.WhereLike("cq_user.pkenable","%" + this.pkenable.ToString() + "%");
			}
			if(this.militaryrank1 != null)
			{
				result = result.WhereLike("cq_user.militaryrank1","%" + this.militaryrank1.ToString() + "%");
			}
			if(this.militaryrank2 != null)
			{
				result = result.WhereLike("cq_user.militaryrank2","%" + this.militaryrank2.ToString() + "%");
			}
			if(this.militaryrank3 != null)
			{
				result = result.WhereLike("cq_user.militaryrank3","%" + this.militaryrank3.ToString() + "%");
			}
			if(this.militaryrank4 != null)
			{
				result = result.WhereLike("cq_user.militaryrank4","%" + this.militaryrank4.ToString() + "%");
			}
			if(this.marrytime != null)
			{
				result = result.WhereLike("cq_user.marrytime","%" + this.marrytime.ToString() + "%");
			}
			if(this.robotstorage_lev != null)
			{
				result = result.WhereLike("cq_user.robotstorage_lev","%" + this.robotstorage_lev.ToString() + "%");
			}
			if(this.accumulate != null)
			{
				result = result.WhereLike("cq_user.accumulate","%" + this.accumulate.ToString() + "%");
			}
			if(this.Emoney != null)
			{
				result = result.WhereLike("cq_user.Emoney","%" + this.Emoney.ToString() + "%");
			}
			if(this.Emoney_chk != null)
			{
				result = result.WhereLike("cq_user.Emoney_chk","%" + this.Emoney_chk.ToString() + "%");
			}
			if(this.money_saved2 != null)
			{
				result = result.WhereLike("cq_user.money_saved2","%" + this.money_saved2.ToString() + "%");
			}
			if(this.ExpBallUsage != null)
			{
				result = result.WhereLike("cq_user.ExpBallUsage","%" + this.ExpBallUsage.ToString() + "%");
			}
			if(this.status != null)
			{
				result = result.WhereLike("cq_user.status","%" + this.status.ToString() + "%");
			}
			if(this.stratagem != null)
			{
				result = result.WhereLike("cq_user.stratagem","%" + this.stratagem.ToString() + "%");
			}
			if(this.online_time != null)
			{
				result = result.WhereLike("cq_user.online_time","%" + this.online_time.ToString() + "%");
			}
			if(this.auto_exercise != null)
			{
				result = result.WhereLike("cq_user.auto_exercise","%" + this.auto_exercise.ToString() + "%");
			}
			if(this.flower != null)
			{
				result = result.WhereLike("cq_user.flower","%" + this.flower.ToString() + "%");
			}
			if(this.BagNum != null)
			{
				result = result.WhereLike("cq_user.BagNum","%" + this.BagNum.ToString() + "%");
			}
			if(this.forbitdden_words != null)
			{
				result = result.WhereLike("cq_user.forbitdden_words","%" + this.forbitdden_words.ToString() + "%");
			}
			if(this.CrystalPoint != null)
			{
				result = result.WhereLike("cq_user.CrystalPoint","%" + this.CrystalPoint.ToString() + "%");
			}
			if(this.CrystalUsage0 != null)
			{
				result = result.WhereLike("cq_user.CrystalUsage0","%" + this.CrystalUsage0.ToString() + "%");
			}
			if(this.CrystalUsage1 != null)
			{
				result = result.WhereLike("cq_user.CrystalUsage1","%" + this.CrystalUsage1.ToString() + "%");
			}
			if(this.CrystalUsage2 != null)
			{
				result = result.WhereLike("cq_user.CrystalUsage2","%" + this.CrystalUsage2.ToString() + "%");
			}
			if(this.CrystalUsage3 != null)
			{
				result = result.WhereLike("cq_user.CrystalUsage3","%" + this.CrystalUsage3.ToString() + "%");
			}
			if(this.CrystalUsage4 != null)
			{
				result = result.WhereLike("cq_user.CrystalUsage4","%" + this.CrystalUsage4.ToString() + "%");
			}
			if(this.password_id != null)
			{
				result = result.WhereLike("cq_user.password_id","%" + this.password_id.ToString() + "%");
			}
			if(this.locktime != null)
			{
				result = result.WhereLike("cq_user.locktime","%" + this.locktime.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_user.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.flower_w != null)
			{
				result = result.WhereLike("cq_user.flower_w","%" + this.flower_w.ToString() + "%");
			}
			if(this.tutor_level != null)
			{
				result = result.WhereLike("cq_user.tutor_level","%" + this.tutor_level.ToString() + "%");
			}
			if(this.Tutor_exp != null)
			{
				result = result.WhereLike("cq_user.Tutor_exp","%" + this.Tutor_exp.ToString() + "%");
			}
			if(this.online_time2 != null)
			{
				result = result.WhereLike("cq_user.online_time2","%" + this.online_time2.ToString() + "%");
			}
			if(this.offine_time != null)
			{
				result = result.WhereLike("cq_user.offine_time","%" + this.offine_time.ToString() + "%");
			}
			if(this.last_logout2 != null)
			{
				result = result.WhereLike("cq_user.last_logout2","%" + this.last_logout2.ToString() + "%");
			}
			if(this.list1 != null)
			{
				result = result.WhereLike("cq_user.list1","%" + this.list1.ToString() + "%");
			}
			if(this.list2 != null)
			{
				result = result.WhereLike("cq_user.list2","%" + this.list2.ToString() + "%");
			}
			if(this.friend_share != null)
			{
				result = result.WhereLike("cq_user.friend_share","%" + this.friend_share.ToString() + "%");
			}
			if(this.Battle_lev != null)
			{
				result = result.WhereLike("cq_user.Battle_lev","%" + this.Battle_lev.ToString() + "%");
			}
			if(this.Income != null)
			{
				result = result.WhereLike("cq_user.Income","%" + this.Income.ToString() + "%");
			}
			if(this.business != null)
			{
				result = result.WhereLike("cq_user.business","%" + this.business.ToString() + "%");
			}
			if(this.airborne != null)
			{
				result = result.WhereLike("cq_user.airborne","%" + this.airborne.ToString() + "%");
			}
			if(this.emoney2 != null)
			{
				result = result.WhereLike("cq_user.emoney2","%" + this.emoney2.ToString() + "%");
			}
			if(this.Emoney3 != null)
			{
				result = result.WhereLike("cq_user.Emoney3","%" + this.Emoney3.ToString() + "%");
			}
			if(this.Emoney3_chk != null)
			{
				result = result.WhereLike("cq_user.Emoney3_chk","%" + this.Emoney3_chk.ToString() + "%");
			}
			if(this.donation != null)
			{
				result = result.WhereLike("cq_user.donation","%" + this.donation.ToString() + "%");
			}
			if(this.login_time != null)
			{
				result = result.WhereLike("cq_user.login_time","%" + this.login_time.ToString() + "%");
			}
			if(this.ip != null)
			{
				result = result.WhereLike("cq_user.ip","%" + this.ip.ToString() + "%");
			}
			if(this.brother_team_id != null)
			{
				result = result.WhereLike("cq_user.brother_team_id","%" + this.brother_team_id.ToString() + "%");
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