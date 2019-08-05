using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserlevDeleteByIdRepository : CommandBase
    {
        public int? level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.level == null)
                throw new BusinessException("level không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_userlev").Where("cq_userlev.level",this.level).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}