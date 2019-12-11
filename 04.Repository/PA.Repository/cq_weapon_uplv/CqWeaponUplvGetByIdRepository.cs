using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponUplvGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_weapon_uplv")
                .Where("cq_weapon_uplv.id",this.id)
				.Select(
					"cq_weapon_uplv.id",
					"cq_weapon_uplv.exp1",
					"cq_weapon_uplv.point1",
					"cq_weapon_uplv.atk1",
					"cq_weapon_uplv.hot1",
					"cq_weapon_uplv.shake1",
					"cq_weapon_uplv.sting1",
					"cq_weapon_uplv.decay1",
					"cq_weapon_uplv.fighter1",
					"cq_weapon_uplv.gunner1",
					"cq_weapon_uplv.energy1",
					"cq_weapon_uplv.exp2",
					"cq_weapon_uplv.point2",
					"cq_weapon_uplv.atk2",
					"cq_weapon_uplv.hot2",
					"cq_weapon_uplv.shake2",
					"cq_weapon_uplv.sting2",
					"cq_weapon_uplv.decay2",
					"cq_weapon_uplv.fighter2",
					"cq_weapon_uplv.gunner2",
					"cq_weapon_uplv.energy2",
					"cq_weapon_uplv.exp3",
					"cq_weapon_uplv.point3",
					"cq_weapon_uplv.atk3",
					"cq_weapon_uplv.hot3",
					"cq_weapon_uplv.shake3",
					"cq_weapon_uplv.sting3",
					"cq_weapon_uplv.decay3",
					"cq_weapon_uplv.fighter3",
					"cq_weapon_uplv.gunner3",
					"cq_weapon_uplv.energy3",
					"cq_weapon_uplv.exp4",
					"cq_weapon_uplv.point4",
					"cq_weapon_uplv.atk4",
					"cq_weapon_uplv.hot4",
					"cq_weapon_uplv.shake4",
					"cq_weapon_uplv.sting4",
					"cq_weapon_uplv.decay4",
					"cq_weapon_uplv.fighter4",
					"cq_weapon_uplv.gunner4",
					"cq_weapon_uplv.energy4",
					"cq_weapon_uplv.exp5",
					"cq_weapon_uplv.point5",
					"cq_weapon_uplv.atk5",
					"cq_weapon_uplv.hot5",
					"cq_weapon_uplv.shake5",
					"cq_weapon_uplv.sting5",
					"cq_weapon_uplv.decay5",
					"cq_weapon_uplv.fighter5",
					"cq_weapon_uplv.gunner5",
					"cq_weapon_uplv.energy5"
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