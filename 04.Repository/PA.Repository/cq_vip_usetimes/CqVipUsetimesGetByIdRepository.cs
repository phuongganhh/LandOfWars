using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqVipUsetimesGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_vip_usetimes")
                .Where("cq_vip_usetimes.id",this.id)
				.Select(
					"cq_vip_usetimes.id",
					"cq_vip_usetimes.account_id",
					"cq_vip_usetimes.vip_lev",
					"cq_vip_usetimes.type",
					"cq_vip_usetimes.data1",
					"cq_vip_usetimes.active_date"
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