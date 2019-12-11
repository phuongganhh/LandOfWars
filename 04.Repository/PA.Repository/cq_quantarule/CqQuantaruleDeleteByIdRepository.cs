using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqQuantaruleDeleteByIdRepository : CommandBase
    {
        public int? LEVEL { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.LEVEL == null)
                throw new BusinessException("LEVEL không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_quantarule").Where("cq_quantarule.LEVEL",this.LEVEL).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}