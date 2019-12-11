using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPasswordDeleteByIdRepository : CommandBase
    {
        public int? ID { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.ID == null)
                throw new BusinessException("ID không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            context.db.From("cq_password").Where("cq_password.ID",this.ID).Delete().ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}