using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMapDeleteByIdRepository : CommandBase
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.id == null)
                throw new BusinessException("id không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_map").Where("cq_map.id",this.id).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}