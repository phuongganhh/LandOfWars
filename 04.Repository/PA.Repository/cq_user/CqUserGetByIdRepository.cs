using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_user")
                .Where("cq_user.id",this.id)
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