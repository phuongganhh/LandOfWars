using Entities;
using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqVipUsetimesUpdateByIdRepository : CommandBase
    {
        public cq_vip_usetimes data { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.data == null)
            {
                throw new BusinessException("Dữ liệu không thể null", System.Net.HttpStatusCode.BadRequest);
            }
            if(this.data.id == null)
            {
                throw new BusinessException("id không được null", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result UpdateData(ObjectContext context)
        {
            context.db
                .From("cq_vip_usetimes")
                .Where("cq_vip_usetimes.id",this.data.id)
                .Update(data)
                .ExecuteNotResult()
                ;
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.UpdateData(context);
        }
    }
}