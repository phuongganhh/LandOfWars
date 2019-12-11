using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMonsterAttributeTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_monster_attribute_type")
                .Where("cq_monster_attribute_type.id",this.id)
				.Select(
					"cq_monster_attribute_type.id",
					"cq_monster_attribute_type.def_strafe",
					"cq_monster_attribute_type.def_fire",
					"cq_monster_attribute_type.def_shake",
					"cq_monster_attribute_type.def_ice",
					"cq_monster_attribute_type.def_snipe",
					"cq_monster_attribute_type.weakness",
					"cq_monster_attribute_type.Def_C",
					"cq_monster_attribute_type.Def_hot",
					"cq_monster_attribute_type.def_MGun",
					"cq_monster_attribute_type.def_shakegun",
					"cq_monster_attribute_type.max_wrath",
					"cq_monster_attribute_type.def_beat",
					"cq_monster_attribute_type.Def_musket"
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