using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShipmissionGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_shipmission")
                .Where("cq_shipmission.id",this.id)
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