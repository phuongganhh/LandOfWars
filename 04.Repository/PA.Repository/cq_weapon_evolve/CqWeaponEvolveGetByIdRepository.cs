using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponEvolveGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_weapon_evolve")
                .Where("cq_weapon_evolve.id",this.id)
				.Select(
					"cq_weapon_evolve.id",
					"cq_weapon_evolve.evolve_weapon",
					"cq_weapon_evolve.req_lv",
					"cq_weapon_evolve.req_atk",
					"cq_weapon_evolve.req_hot_atk",
					"cq_weapon_evolve.req_shake_atk",
					"cq_weapon_evolve.req_sting_atk",
					"cq_weapon_evolve.req_decay_atk",
					"cq_weapon_evolve.req_fighter_atk",
					"cq_weapon_evolve.req_gunner_atk",
					"cq_weapon_evolve.req_energy_atk",
					"cq_weapon_evolve.req_type",
					"cq_weapon_evolve.req_data",
					"cq_weapon_evolve.add_atk",
					"cq_weapon_evolve.add_hot_atk",
					"cq_weapon_evolve.add_shake_atk",
					"cq_weapon_evolve.add_sting_atk",
					"cq_weapon_evolve.add_decay_atk",
					"cq_weapon_evolve.add_fighter_atk",
					"cq_weapon_evolve.add_gunner_atk",
					"cq_weapon_evolve.add_energy_atk",
					"cq_weapon_evolve.add_point",
					"cq_weapon_evolve.add_fittings"
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