using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserStatisticDeleteByIdRepository : CommandBase
    {
        public int? userid { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.userid == null)
                throw new BusinessException("userid không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_user_statistic").Where("cq_user_statistic.userid",this.userid).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}