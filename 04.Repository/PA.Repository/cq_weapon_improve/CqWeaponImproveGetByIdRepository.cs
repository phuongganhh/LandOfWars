using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponImproveGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_weapon_improve")
                .Where("cq_weapon_improve.id",this.id)
				.Select(
					"cq_weapon_improve.id",
					"cq_weapon_improve.itemtypeid",
					"cq_weapon_improve.Uplev1",
					"cq_weapon_improve.Uplev2",
					"cq_weapon_improve.Uplev3",
					"cq_weapon_improve.Uplev4",
					"cq_weapon_improve.Money_uplev",
					"cq_weapon_improve.Upquality1",
					"cq_weapon_improve.Upquality2",
					"cq_weapon_improve.Upquality3",
					"cq_weapon_improve.Upquality4",
					"cq_weapon_improve.Gem"
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