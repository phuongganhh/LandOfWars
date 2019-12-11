using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLevexpDeleteByIdRepository : CommandBase
    {
        public int? Level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.Level == null)
                throw new BusinessException("Level không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_levexp").Where("cq_levexp.Level",this.Level).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}