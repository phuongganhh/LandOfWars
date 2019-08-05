using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqUnlawful
{
    public class CqUnlawfulDeleteByIdAction : CommandBase
    {
        public int? ID { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.ID == null)
                throw new BusinessException("ID không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqUnlawfulDeleteByIdRepository())
			{
				cmd.ID = this.ID;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}