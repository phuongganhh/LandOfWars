using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqUserlev
{
    public class CqUserlevDeleteByIdAction : CommandBase
    {
        public int? level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.level == null)
                throw new BusinessException("level không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqUserlevDeleteByIdRepository())
			{
				cmd.level = this.level;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}