using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobottypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_robottype")
                .Where("cq_robottype.id",this.id)
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