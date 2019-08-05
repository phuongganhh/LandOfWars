using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAmmoSkilltypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_ammo_skilltype")
                .Where("cq_ammo_skilltype.id",this.id)
				.Select(
					"cq_ammo_skilltype.id",
					"cq_ammo_skilltype.type",
					"cq_ammo_skilltype.lev",
					"cq_ammo_skilltype.exp",
					"cq_ammo_skilltype.compound_amount"
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