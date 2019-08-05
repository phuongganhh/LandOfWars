using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqTutorContributions
{
    public class CqTutorContributionsDeleteByIdAction : CommandBase
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.id == null)
                throw new BusinessException("id không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqTutorContributionsDeleteByIdRepository())
			{
				cmd.id = this.id;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}