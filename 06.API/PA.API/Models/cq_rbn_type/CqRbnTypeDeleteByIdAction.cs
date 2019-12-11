using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqRbnType
{
    public class CqRbnTypeDeleteByIdAction : CommandBase
    {
        public int? Id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.Id == null)
                throw new BusinessException("Id không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqRbnTypeDeleteByIdRepository())
			{
				cmd.Id = this.Id;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}