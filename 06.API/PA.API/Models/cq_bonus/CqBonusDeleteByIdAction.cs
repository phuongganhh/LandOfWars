using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository; using System.Net;

namespace PA.API.Models.CqBonus
{
    public class CqBonusDeleteByIdAction : CommandBase
    {
        public int? action { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.action == null)
                throw new BusinessException("action không được null", HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqBonusDeleteByIdRepository())
			{
				cmd.action = this.action;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}