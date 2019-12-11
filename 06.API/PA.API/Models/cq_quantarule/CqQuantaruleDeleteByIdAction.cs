using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqQuantarule
{
    public class CqQuantaruleDeleteByIdAction : CommandBase
    {
        public int? LEVEL { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.LEVEL == null)
                throw new BusinessException("LEVEL không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqQuantaruleDeleteByIdRepository())
			{
				cmd.LEVEL = this.LEVEL;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}