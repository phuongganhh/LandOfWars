using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobotSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? owner_type { get; set; }
		public int? owner_id { get; set; }
		public int? player_id { get; set; }
		public int? type { get; set; }
		public long? exp { get; set; }
		public int? level { get; set; }
		public int? life { get; set; }
		public int? position { get; set; }
		public int? color { get; set; }
		public int? reborn_cnt { get; set; }
		public int? number { get; set; }
		public int? hot_def { get; set; }
		public int? shake_def { get; set; }
		public int? cold_def { get; set; }
		public int? light_def { get; set; }
		public int? ExpBallUsage { get; set; }
		public int? EN_state { get; set; }
		public int? weapon_select { get; set; }
		public int? eatheruplev_date { get; set; }
		public int? TechnoPoint { get; set; }
		public int? TechnoUsage0 { get; set; }
		public int? TechnoUsage1 { get; set; }
		public int? TechnoUsage2 { get; set; }
		public int? TechnoUsage3 { get; set; }
		public int? TechnoUsage4 { get; set; }
		public int? Model_lev { get; set; }
		public int? Mete_lev { get; set; }
		public int? Mete_RobotType { get; set; }
		public int? research1 { get; set; }
		public int? research2 { get; set; }
		public int? research3 { get; set; }
		public int? research4 { get; set; }
		public int? research5 { get; set; }
		public int? research6 { get; set; }
		public int? research7 { get; set; }
		public int? research8 { get; set; }
		public int? chk_sum { get; set; }
		public int? qi { get; set; }
		public int? qiusage { get; set; }
		public int? syndicate { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_robot")
				.Select(
					"cq_robot.id",
					"cq_robot.name",
					"cq_robot.owner_type",
					"cq_robot.owner_id",
					"cq_robot.player_id",
					"cq_robot.type",
					"cq_robot.exp",
					"cq_robot.level",
					"cq_robot.life",
					"cq_robot.position",
					"cq_robot.color",
					"cq_robot.reborn_cnt",
					"cq_robot.number",
					"cq_robot.hot_def",
					"cq_robot.shake_def",
					"cq_robot.cold_def",
					"cq_robot.light_def",
					"cq_robot.ExpBallUsage",
					"cq_robot.EN_state",
					"cq_robot.weapon_select",
					"cq_robot.eatheruplev_date",
					"cq_robot.TechnoPoint",
					"cq_robot.TechnoUsage0",
					"cq_robot.TechnoUsage1",
					"cq_robot.TechnoUsage2",
					"cq_robot.TechnoUsage3",
					"cq_robot.TechnoUsage4",
					"cq_robot.Model_lev",
					"cq_robot.Mete_lev",
					"cq_robot.Mete_RobotType",
					"cq_robot.research1",
					"cq_robot.research2",
					"cq_robot.research3",
					"cq_robot.research4",
					"cq_robot.research5",
					"cq_robot.research6",
					"cq_robot.research7",
					"cq_robot.research8",
					"cq_robot.chk_sum",
					"cq_robot.qi",
					"cq_robot.qiusage",
					"cq_robot.syndicate"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_robot")
                        .Select("cq_robot.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_robot.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_robot.name","%" + this.name.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_robot.owner_type","%" + this.owner_type.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_robot.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_robot.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_robot.type","%" + this.type.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_robot.exp","%" + this.exp.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_robot.level","%" + this.level.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_robot.life","%" + this.life.ToString() + "%");
			}
			if(this.position != null)
			{
				result = result.WhereLike("cq_robot.position","%" + this.position.ToString() + "%");
			}
			if(this.color != null)
			{
				result = result.WhereLike("cq_robot.color","%" + this.color.ToString() + "%");
			}
			if(this.reborn_cnt != null)
			{
				result = result.WhereLike("cq_robot.reborn_cnt","%" + this.reborn_cnt.ToString() + "%");
			}
			if(this.number != null)
			{
				result = result.WhereLike("cq_robot.number","%" + this.number.ToString() + "%");
			}
			if(this.hot_def != null)
			{
				result = result.WhereLike("cq_robot.hot_def","%" + this.hot_def.ToString() + "%");
			}
			if(this.shake_def != null)
			{
				result = result.WhereLike("cq_robot.shake_def","%" + this.shake_def.ToString() + "%");
			}
			if(this.cold_def != null)
			{
				result = result.WhereLike("cq_robot.cold_def","%" + this.cold_def.ToString() + "%");
			}
			if(this.light_def != null)
			{
				result = result.WhereLike("cq_robot.light_def","%" + this.light_def.ToString() + "%");
			}
			if(this.ExpBallUsage != null)
			{
				result = result.WhereLike("cq_robot.ExpBallUsage","%" + this.ExpBallUsage.ToString() + "%");
			}
			if(this.EN_state != null)
			{
				result = result.WhereLike("cq_robot.EN_state","%" + this.EN_state.ToString() + "%");
			}
			if(this.weapon_select != null)
			{
				result = result.WhereLike("cq_robot.weapon_select","%" + this.weapon_select.ToString() + "%");
			}
			if(this.eatheruplev_date != null)
			{
				result = result.WhereLike("cq_robot.eatheruplev_date","%" + this.eatheruplev_date.ToString() + "%");
			}
			if(this.TechnoPoint != null)
			{
				result = result.WhereLike("cq_robot.TechnoPoint","%" + this.TechnoPoint.ToString() + "%");
			}
			if(this.TechnoUsage0 != null)
			{
				result = result.WhereLike("cq_robot.TechnoUsage0","%" + this.TechnoUsage0.ToString() + "%");
			}
			if(this.TechnoUsage1 != null)
			{
				result = result.WhereLike("cq_robot.TechnoUsage1","%" + this.TechnoUsage1.ToString() + "%");
			}
			if(this.TechnoUsage2 != null)
			{
				result = result.WhereLike("cq_robot.TechnoUsage2","%" + this.TechnoUsage2.ToString() + "%");
			}
			if(this.TechnoUsage3 != null)
			{
				result = result.WhereLike("cq_robot.TechnoUsage3","%" + this.TechnoUsage3.ToString() + "%");
			}
			if(this.TechnoUsage4 != null)
			{
				result = result.WhereLike("cq_robot.TechnoUsage4","%" + this.TechnoUsage4.ToString() + "%");
			}
			if(this.Model_lev != null)
			{
				result = result.WhereLike("cq_robot.Model_lev","%" + this.Model_lev.ToString() + "%");
			}
			if(this.Mete_lev != null)
			{
				result = result.WhereLike("cq_robot.Mete_lev","%" + this.Mete_lev.ToString() + "%");
			}
			if(this.Mete_RobotType != null)
			{
				result = result.WhereLike("cq_robot.Mete_RobotType","%" + this.Mete_RobotType.ToString() + "%");
			}
			if(this.research1 != null)
			{
				result = result.WhereLike("cq_robot.research1","%" + this.research1.ToString() + "%");
			}
			if(this.research2 != null)
			{
				result = result.WhereLike("cq_robot.research2","%" + this.research2.ToString() + "%");
			}
			if(this.research3 != null)
			{
				result = result.WhereLike("cq_robot.research3","%" + this.research3.ToString() + "%");
			}
			if(this.research4 != null)
			{
				result = result.WhereLike("cq_robot.research4","%" + this.research4.ToString() + "%");
			}
			if(this.research5 != null)
			{
				result = result.WhereLike("cq_robot.research5","%" + this.research5.ToString() + "%");
			}
			if(this.research6 != null)
			{
				result = result.WhereLike("cq_robot.research6","%" + this.research6.ToString() + "%");
			}
			if(this.research7 != null)
			{
				result = result.WhereLike("cq_robot.research7","%" + this.research7.ToString() + "%");
			}
			if(this.research8 != null)
			{
				result = result.WhereLike("cq_robot.research8","%" + this.research8.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_robot.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.qi != null)
			{
				result = result.WhereLike("cq_robot.qi","%" + this.qi.ToString() + "%");
			}
			if(this.qiusage != null)
			{
				result = result.WhereLike("cq_robot.qiusage","%" + this.qiusage.ToString() + "%");
			}
			if(this.syndicate != null)
			{
				result = result.WhereLike("cq_robot.syndicate","%" + this.syndicate.ToString() + "%");
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