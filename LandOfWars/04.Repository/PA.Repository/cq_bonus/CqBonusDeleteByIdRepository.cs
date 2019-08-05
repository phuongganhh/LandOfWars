using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqBonusDeleteByIdRepository : CommandBase
    {
        public int? action { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.action == null)
                throw new BusinessException("action không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_bonus").Where("cq_bonus.action",this.action).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}