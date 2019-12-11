using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqUserStatistic
{
    public class CqUserStatisticDeleteByIdAction : CommandBase
    {
        public int? userid { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.userid == null)
                throw new BusinessException("userid không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqUserStatisticDeleteByIdRepository())
			{
				cmd.userid = this.userid;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}