using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDeluserGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.id == null)
            {
                throw new BusinessException("id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_deluser")
                .Where("cq_deluser.id",this.id)
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
                .Result<T>()
                .FirstOrDefault()
                ;
        }
        protected override Result<T> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}