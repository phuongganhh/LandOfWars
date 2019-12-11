using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShipmissionSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? sort { get; set; }
		public int? type { get; set; }
		public int? monster1 { get; set; }
		public int? num1 { get; set; }
		public int? monster2 { get; set; }
		public int? num2 { get; set; }
		public int? monster3 { get; set; }
		public int? num3 { get; set; }
		public int? monster4 { get; set; }
		public int? num4 { get; set; }
		public int? targetmapdoc { get; set; }
		public int? shipid { get; set; }
		public string path { get; set; }
		public int? maxplayers { get; set; }
		public int? req_minlev { get; set; }
		public int? req_maxlev { get; set; }
		public int? req_robottype { get; set; }
		public int? req_sex { get; set; }
		public int? req_item { get; set; }
		public int? limit_time { get; set; }
		public string introduce { get; set; }
		public int? action { get; set; }
		public int? task { get; set; }
		public int? req_maxreborn { get; set; }
		public int? mission_num { get; set; }
		public int? death_punish { get; set; }
		public int? finish_bonus { get; set; }
		public int? survive_bonus { get; set; }
		public int? speed_finish { get; set; }
		public int? speed_finish_time { get; set; }
		public int? speed_perfect { get; set; }
		public int? speed_perfect_time { get; set; }
		public int? destroy_num { get; set; }
		public int? secret_num { get; set; }
		public int? main_score { get; set; }
		public int? monster1_score { get; set; }
		public int? monster2_score { get; set; }
		public int? monster3_score { get; set; }
		public int? monster4_score { get; set; }
		public int? destroy_item_score { get; set; }
		public int? secret_score { get; set; }
		public int? total_score { get; set; }
		public int? req_battlelev { get; set; }
		public int? need_score { get; set; }
		public int? prize_item { get; set; }
		public int? prize_money { get; set; }
		public int? prize_stone { get; set; }
		public int? action_begin { get; set; }
		public int? action_finish { get; set; }
		public int? levexp_129 { get; set; }
		public int? levexp_130_139 { get; set; }
		public int? levexp_140_149 { get; set; }
		public int? levexp_150_159 { get; set; }
		public int? levexp_160_169 { get; set; }
		public int? levexp_170 { get; set; }
		public int? rankexp_12 { get; set; }
		public int? rankexp_13 { get; set; }
		public int? rankexp_14 { get; set; }
		public int? rankexp_15 { get; set; }
		public int? rankexp_16 { get; set; }
		public int? rankexp_17 { get; set; }
		public int? Stat_monster1 { get; set; }
		public int? Stat_monster2 { get; set; }
		public int? Stat_monster3 { get; set; }
		public int? Stat_monster4 { get; set; }
		public int? Record_benchmark { get; set; }
		public int? Perfect_benchmark { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shipmission")
				.Select(
					"cq_shipmission.id",
					"cq_shipmission.name",
					"cq_shipmission.sort",
					"cq_shipmission.type",
					"cq_shipmission.monster1",
					"cq_shipmission.num1",
					"cq_shipmission.monster2",
					"cq_shipmission.num2",
					"cq_shipmission.monster3",
					"cq_shipmission.num3",
					"cq_shipmission.monster4",
					"cq_shipmission.num4",
					"cq_shipmission.targetmapdoc",
					"cq_shipmission.shipid",
					"cq_shipmission.path",
					"cq_shipmission.maxplayers",
					"cq_shipmission.req_minlev",
					"cq_shipmission.req_maxlev",
					"cq_shipmission.req_robottype",
					"cq_shipmission.req_sex",
					"cq_shipmission.req_item",
					"cq_shipmission.limit_time",
					"cq_shipmission.introduce",
					"cq_shipmission.action",
					"cq_shipmission.task",
					"cq_shipmission.req_maxreborn",
					"cq_shipmission.mission_num",
					"cq_shipmission.death_punish",
					"cq_shipmission.finish_bonus",
					"cq_shipmission.survive_bonus",
					"cq_shipmission.speed_finish",
					"cq_shipmission.speed_finish_time",
					"cq_shipmission.speed_perfect",
					"cq_shipmission.speed_perfect_time",
					"cq_shipmission.destroy_num",
					"cq_shipmission.secret_num",
					"cq_shipmission.main_score",
					"cq_shipmission.monster1_score",
					"cq_shipmission.monster2_score",
					"cq_shipmission.monster3_score",
					"cq_shipmission.monster4_score",
					"cq_shipmission.destroy_item_score",
					"cq_shipmission.secret_score",
					"cq_shipmission.total_score",
					"cq_shipmission.req_battlelev",
					"cq_shipmission.need_score",
					"cq_shipmission.prize_item",
					"cq_shipmission.prize_money",
					"cq_shipmission.prize_stone",
					"cq_shipmission.action_begin",
					"cq_shipmission.action_finish",
					"cq_shipmission.levexp_129",
					"cq_shipmission.levexp_130_139",
					"cq_shipmission.levexp_140_149",
					"cq_shipmission.levexp_150_159",
					"cq_shipmission.levexp_160_169",
					"cq_shipmission.levexp_170",
					"cq_shipmission.rankexp_12",
					"cq_shipmission.rankexp_13",
					"cq_shipmission.rankexp_14",
					"cq_shipmission.rankexp_15",
					"cq_shipmission.rankexp_16",
					"cq_shipmission.rankexp_17",
					"cq_shipmission.Stat_monster1",
					"cq_shipmission.Stat_monster2",
					"cq_shipmission.Stat_monster3",
					"cq_shipmission.Stat_monster4",
					"cq_shipmission.Record_benchmark",
					"cq_shipmission.Perfect_benchmark"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shipmission")
                        .Select("cq_shipmission.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shipmission.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_shipmission.name","%" + this.name.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_shipmission.sort","%" + this.sort.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_shipmission.type","%" + this.type.ToString() + "%");
			}
			if(this.monster1 != null)
			{
				result = result.WhereLike("cq_shipmission.monster1","%" + this.monster1.ToString() + "%");
			}
			if(this.num1 != null)
			{
				result = result.WhereLike("cq_shipmission.num1","%" + this.num1.ToString() + "%");
			}
			if(this.monster2 != null)
			{
				result = result.WhereLike("cq_shipmission.monster2","%" + this.monster2.ToString() + "%");
			}
			if(this.num2 != null)
			{
				result = result.WhereLike("cq_shipmission.num2","%" + this.num2.ToString() + "%");
			}
			if(this.monster3 != null)
			{
				result = result.WhereLike("cq_shipmission.monster3","%" + this.monster3.ToString() + "%");
			}
			if(this.num3 != null)
			{
				result = result.WhereLike("cq_shipmission.num3","%" + this.num3.ToString() + "%");
			}
			if(this.monster4 != null)
			{
				result = result.WhereLike("cq_shipmission.monster4","%" + this.monster4.ToString() + "%");
			}
			if(this.num4 != null)
			{
				result = result.WhereLike("cq_shipmission.num4","%" + this.num4.ToString() + "%");
			}
			if(this.targetmapdoc != null)
			{
				result = result.WhereLike("cq_shipmission.targetmapdoc","%" + this.targetmapdoc.ToString() + "%");
			}
			if(this.shipid != null)
			{
				result = result.WhereLike("cq_shipmission.shipid","%" + this.shipid.ToString() + "%");
			}
			if(this.path != null)
			{
				result = result.WhereLike("cq_shipmission.path","%" + this.path.ToString() + "%");
			}
			if(this.maxplayers != null)
			{
				result = result.WhereLike("cq_shipmission.maxplayers","%" + this.maxplayers.ToString() + "%");
			}
			if(this.req_minlev != null)
			{
				result = result.WhereLike("cq_shipmission.req_minlev","%" + this.req_minlev.ToString() + "%");
			}
			if(this.req_maxlev != null)
			{
				result = result.WhereLike("cq_shipmission.req_maxlev","%" + this.req_maxlev.ToString() + "%");
			}
			if(this.req_robottype != null)
			{
				result = result.WhereLike("cq_shipmission.req_robottype","%" + this.req_robottype.ToString() + "%");
			}
			if(this.req_sex != null)
			{
				result = result.WhereLike("cq_shipmission.req_sex","%" + this.req_sex.ToString() + "%");
			}
			if(this.req_item != null)
			{
				result = result.WhereLike("cq_shipmission.req_item","%" + this.req_item.ToString() + "%");
			}
			if(this.limit_time != null)
			{
				result = result.WhereLike("cq_shipmission.limit_time","%" + this.limit_time.ToString() + "%");
			}
			if(this.introduce != null)
			{
				result = result.WhereLike("cq_shipmission.introduce","%" + this.introduce.ToString() + "%");
			}
			if(this.action != null)
			{
				result = result.WhereLike("cq_shipmission.action","%" + this.action.ToString() + "%");
			}
			if(this.task != null)
			{
				result = result.WhereLike("cq_shipmission.task","%" + this.task.ToString() + "%");
			}
			if(this.req_maxreborn != null)
			{
				result = result.WhereLike("cq_shipmission.req_maxreborn","%" + this.req_maxreborn.ToString() + "%");
			}
			if(this.mission_num != null)
			{
				result = result.WhereLike("cq_shipmission.mission_num","%" + this.mission_num.ToString() + "%");
			}
			if(this.death_punish != null)
			{
				result = result.WhereLike("cq_shipmission.death_punish","%" + this.death_punish.ToString() + "%");
			}
			if(this.finish_bonus != null)
			{
				result = result.WhereLike("cq_shipmission.finish_bonus","%" + this.finish_bonus.ToString() + "%");
			}
			if(this.survive_bonus != null)
			{
				result = result.WhereLike("cq_shipmission.survive_bonus","%" + this.survive_bonus.ToString() + "%");
			}
			if(this.speed_finish != null)
			{
				result = result.WhereLike("cq_shipmission.speed_finish","%" + this.speed_finish.ToString() + "%");
			}
			if(this.speed_finish_time != null)
			{
				result = result.WhereLike("cq_shipmission.speed_finish_time","%" + this.speed_finish_time.ToString() + "%");
			}
			if(this.speed_perfect != null)
			{
				result = result.WhereLike("cq_shipmission.speed_perfect","%" + this.speed_perfect.ToString() + "%");
			}
			if(this.speed_perfect_time != null)
			{
				result = result.WhereLike("cq_shipmission.speed_perfect_time","%" + this.speed_perfect_time.ToString() + "%");
			}
			if(this.destroy_num != null)
			{
				result = result.WhereLike("cq_shipmission.destroy_num","%" + this.destroy_num.ToString() + "%");
			}
			if(this.secret_num != null)
			{
				result = result.WhereLike("cq_shipmission.secret_num","%" + this.secret_num.ToString() + "%");
			}
			if(this.main_score != null)
			{
				result = result.WhereLike("cq_shipmission.main_score","%" + this.main_score.ToString() + "%");
			}
			if(this.monster1_score != null)
			{
				result = result.WhereLike("cq_shipmission.monster1_score","%" + this.monster1_score.ToString() + "%");
			}
			if(this.monster2_score != null)
			{
				result = result.WhereLike("cq_shipmission.monster2_score","%" + this.monster2_score.ToString() + "%");
			}
			if(this.monster3_score != null)
			{
				result = result.WhereLike("cq_shipmission.monster3_score","%" + this.monster3_score.ToString() + "%");
			}
			if(this.monster4_score != null)
			{
				result = result.WhereLike("cq_shipmission.monster4_score","%" + this.monster4_score.ToString() + "%");
			}
			if(this.destroy_item_score != null)
			{
				result = result.WhereLike("cq_shipmission.destroy_item_score","%" + this.destroy_item_score.ToString() + "%");
			}
			if(this.secret_score != null)
			{
				result = result.WhereLike("cq_shipmission.secret_score","%" + this.secret_score.ToString() + "%");
			}
			if(this.total_score != null)
			{
				result = result.WhereLike("cq_shipmission.total_score","%" + this.total_score.ToString() + "%");
			}
			if(this.req_battlelev != null)
			{
				result = result.WhereLike("cq_shipmission.req_battlelev","%" + this.req_battlelev.ToString() + "%");
			}
			if(this.need_score != null)
			{
				result = result.WhereLike("cq_shipmission.need_score","%" + this.need_score.ToString() + "%");
			}
			if(this.prize_item != null)
			{
				result = result.WhereLike("cq_shipmission.prize_item","%" + this.prize_item.ToString() + "%");
			}
			if(this.prize_money != null)
			{
				result = result.WhereLike("cq_shipmission.prize_money","%" + this.prize_money.ToString() + "%");
			}
			if(this.prize_stone != null)
			{
				result = result.WhereLike("cq_shipmission.prize_stone","%" + this.prize_stone.ToString() + "%");
			}
			if(this.action_begin != null)
			{
				result = result.WhereLike("cq_shipmission.action_begin","%" + this.action_begin.ToString() + "%");
			}
			if(this.action_finish != null)
			{
				result = result.WhereLike("cq_shipmission.action_finish","%" + this.action_finish.ToString() + "%");
			}
			if(this.levexp_129 != null)
			{
				result = result.WhereLike("cq_shipmission.levexp_129","%" + this.levexp_129.ToString() + "%");
			}
			if(this.levexp_130_139 != null)
			{
				result = result.WhereLike("cq_shipmission.levexp_130_139","%" + this.levexp_130_139.ToString() + "%");
			}
			if(this.levexp_140_149 != null)
			{
				result = result.WhereLike("cq_shipmission.levexp_140_149","%" + this.levexp_140_149.ToString() + "%");
			}
			if(this.levexp_150_159 != null)
			{
				result = result.WhereLike("cq_shipmission.levexp_150_159","%" + this.levexp_150_159.ToString() + "%");
			}
			if(this.levexp_160_169 != null)
			{
				result = result.WhereLike("cq_shipmission.levexp_160_169","%" + this.levexp_160_169.ToString() + "%");
			}
			if(this.levexp_170 != null)
			{
				result = result.WhereLike("cq_shipmission.levexp_170","%" + this.levexp_170.ToString() + "%");
			}
			if(this.rankexp_12 != null)
			{
				result = result.WhereLike("cq_shipmission.rankexp_12","%" + this.rankexp_12.ToString() + "%");
			}
			if(this.rankexp_13 != null)
			{
				result = result.WhereLike("cq_shipmission.rankexp_13","%" + this.rankexp_13.ToString() + "%");
			}
			if(this.rankexp_14 != null)
			{
				result = result.WhereLike("cq_shipmission.rankexp_14","%" + this.rankexp_14.ToString() + "%");
			}
			if(this.rankexp_15 != null)
			{
				result = result.WhereLike("cq_shipmission.rankexp_15","%" + this.rankexp_15.ToString() + "%");
			}
			if(this.rankexp_16 != null)
			{
				result = result.WhereLike("cq_shipmission.rankexp_16","%" + this.rankexp_16.ToString() + "%");
			}
			if(this.rankexp_17 != null)
			{
				result = result.WhereLike("cq_shipmission.rankexp_17","%" + this.rankexp_17.ToString() + "%");
			}
			if(this.Stat_monster1 != null)
			{
				result = result.WhereLike("cq_shipmission.Stat_monster1","%" + this.Stat_monster1.ToString() + "%");
			}
			if(this.Stat_monster2 != null)
			{
				result = result.WhereLike("cq_shipmission.Stat_monster2","%" + this.Stat_monster2.ToString() + "%");
			}
			if(this.Stat_monster3 != null)
			{
				result = result.WhereLike("cq_shipmission.Stat_monster3","%" + this.Stat_monster3.ToString() + "%");
			}
			if(this.Stat_monster4 != null)
			{
				result = result.WhereLike("cq_shipmission.Stat_monster4","%" + this.Stat_monster4.ToString() + "%");
			}
			if(this.Record_benchmark != null)
			{
				result = result.WhereLike("cq_shipmission.Record_benchmark","%" + this.Record_benchmark.ToString() + "%");
			}
			if(this.Perfect_benchmark != null)
			{
				result = result.WhereLike("cq_shipmission.Perfect_benchmark","%" + this.Perfect_benchmark.ToString() + "%");
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