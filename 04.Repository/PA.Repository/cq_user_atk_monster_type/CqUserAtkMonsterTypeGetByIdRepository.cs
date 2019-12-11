using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserAtkMonsterTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_user_atk_monster_type")
                .Where("cq_user_atk_monster_type.id",this.id)
				.Select(
					"cq_user_atk_monster_type.id",
					"cq_user_atk_monster_type.Delta_lev",
					"cq_user_atk_monster_type.Atk_grade",
					"cq_user_atk_monster_type.Atk_times",
					"cq_user_atk_monster_type.Type"
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