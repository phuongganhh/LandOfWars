using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobot2SearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
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


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_robot2")
				.Select(
					"cq_robot2.id",
					"cq_robot2.name",
					"cq_robot2.owner_type",
					"cq_robot2.owner_id",
					"cq_robot2.player_id",
					"cq_robot2.type",
					"cq_robot2.exp",
					"cq_robot2.level",
					"cq_robot2.life",
					"cq_robot2.position",
					"cq_robot2.color",
					"cq_robot2.reborn_cnt",
					"cq_robot2.number",
					"cq_robot2.hot_def",
					"cq_robot2.shake_def",
					"cq_robot2.cold_def",
					"cq_robot2.light_def",
					"cq_robot2.ExpBallUsage",
					"cq_robot2.EN_state",
					"cq_robot2.weapon_select",
					"cq_robot2.eatheruplev_date",
					"cq_robot2.TechnoPoint",
					"cq_robot2.TechnoUsage0",
					"cq_robot2.TechnoUsage1",
					"cq_robot2.TechnoUsage2",
					"cq_robot2.TechnoUsage3",
					"cq_robot2.TechnoUsage4",
					"cq_robot2.Model_lev",
					"cq_robot2.Mete_lev",
					"cq_robot2.Mete_RobotType",
					"cq_robot2.research1",
					"cq_robot2.research2",
					"cq_robot2.research3",
					"cq_robot2.research4",
					"cq_robot2.research5",
					"cq_robot2.research6",
					"cq_robot2.research7",
					"cq_robot2.research8",
					"cq_robot2.chk_sum",
					"cq_robot2.qi",
					"cq_robot2.qiusage"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_robot2")
                        .Select("cq_robot2.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_robot2.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_robot2.name","%" + this.name.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_robot2.owner_type","%" + this.owner_type.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_robot2.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_robot2.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_robot2.type","%" + this.type.ToString() + "%");
			}
			if(this.exp != null)
			{
				result = result.WhereLike("cq_robot2.exp","%" + this.exp.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_robot2.level","%" + this.level.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_robot2.life","%" + this.life.ToString() + "%");
			}
			if(this.position != null)
			{
				result = result.WhereLike("cq_robot2.position","%" + this.position.ToString() + "%");
			}
			if(this.color != null)
			{
				result = result.WhereLike("cq_robot2.color","%" + this.color.ToString() + "%");
			}
			if(this.reborn_cnt != null)
			{
				result = result.WhereLike("cq_robot2.reborn_cnt","%" + this.reborn_cnt.ToString() + "%");
			}
			if(this.number != null)
			{
				result = result.WhereLike("cq_robot2.number","%" + this.number.ToString() + "%");
			}
			if(this.hot_def != null)
			{
				result = result.WhereLike("cq_robot2.hot_def","%" + this.hot_def.ToString() + "%");
			}
			if(this.shake_def != null)
			{
				result = result.WhereLike("cq_robot2.shake_def","%" + this.shake_def.ToString() + "%");
			}
			if(this.cold_def != null)
			{
				result = result.WhereLike("cq_robot2.cold_def","%" + this.cold_def.ToString() + "%");
			}
			if(this.light_def != null)
			{
				result = result.WhereLike("cq_robot2.light_def","%" + this.light_def.ToString() + "%");
			}
			if(this.ExpBallUsage != null)
			{
				result = result.WhereLike("cq_robot2.ExpBallUsage","%" + this.ExpBallUsage.ToString() + "%");
			}
			if(this.EN_state != null)
			{
				result = result.WhereLike("cq_robot2.EN_state","%" + this.EN_state.ToString() + "%");
			}
			if(this.weapon_select != null)
			{
				result = result.WhereLike("cq_robot2.weapon_select","%" + this.weapon_select.ToString() + "%");
			}
			if(this.eatheruplev_date != null)
			{
				result = result.WhereLike("cq_robot2.eatheruplev_date","%" + this.eatheruplev_date.ToString() + "%");
			}
			if(this.TechnoPoint != null)
			{
				result = result.WhereLike("cq_robot2.TechnoPoint","%" + this.TechnoPoint.ToString() + "%");
			}
			if(this.TechnoUsage0 != null)
			{
				result = result.WhereLike("cq_robot2.TechnoUsage0","%" + this.TechnoUsage0.ToString() + "%");
			}
			if(this.TechnoUsage1 != null)
			{
				result = result.WhereLike("cq_robot2.TechnoUsage1","%" + this.TechnoUsage1.ToString() + "%");
			}
			if(this.TechnoUsage2 != null)
			{
				result = result.WhereLike("cq_robot2.TechnoUsage2","%" + this.TechnoUsage2.ToString() + "%");
			}
			if(this.TechnoUsage3 != null)
			{
				result = result.WhereLike("cq_robot2.TechnoUsage3","%" + this.TechnoUsage3.ToString() + "%");
			}
			if(this.TechnoUsage4 != null)
			{
				result = result.WhereLike("cq_robot2.TechnoUsage4","%" + this.TechnoUsage4.ToString() + "%");
			}
			if(this.Model_lev != null)
			{
				result = result.WhereLike("cq_robot2.Model_lev","%" + this.Model_lev.ToString() + "%");
			}
			if(this.Mete_lev != null)
			{
				result = result.WhereLike("cq_robot2.Mete_lev","%" + this.Mete_lev.ToString() + "%");
			}
			if(this.Mete_RobotType != null)
			{
				result = result.WhereLike("cq_robot2.Mete_RobotType","%" + this.Mete_RobotType.ToString() + "%");
			}
			if(this.research1 != null)
			{
				result = result.WhereLike("cq_robot2.research1","%" + this.research1.ToString() + "%");
			}
			if(this.research2 != null)
			{
				result = result.WhereLike("cq_robot2.research2","%" + this.research2.ToString() + "%");
			}
			if(this.research3 != null)
			{
				result = result.WhereLike("cq_robot2.research3","%" + this.research3.ToString() + "%");
			}
			if(this.research4 != null)
			{
				result = result.WhereLike("cq_robot2.research4","%" + this.research4.ToString() + "%");
			}
			if(this.research5 != null)
			{
				result = result.WhereLike("cq_robot2.research5","%" + this.research5.ToString() + "%");
			}
			if(this.research6 != null)
			{
				result = result.WhereLike("cq_robot2.research6","%" + this.research6.ToString() + "%");
			}
			if(this.research7 != null)
			{
				result = result.WhereLike("cq_robot2.research7","%" + this.research7.ToString() + "%");
			}
			if(this.research8 != null)
			{
				result = result.WhereLike("cq_robot2.research8","%" + this.research8.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_robot2.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.qi != null)
			{
				result = result.WhereLike("cq_robot2.qi","%" + this.qi.ToString() + "%");
			}
			if(this.qiusage != null)
			{
				result = result.WhereLike("cq_robot2.qiusage","%" + this.qiusage.ToString() + "%");
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