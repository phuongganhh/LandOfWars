using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDupNameDeleteByIdRepository : CommandBase
    {
        public int? Id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.Id == null)
                throw new BusinessException("Id không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_dup_name").Where("cq_dup_name.Id",this.Id).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}