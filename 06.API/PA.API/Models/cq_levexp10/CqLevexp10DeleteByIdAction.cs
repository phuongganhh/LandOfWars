using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqLevexp10
{
    public class CqLevexp10DeleteByIdAction : CommandBase
    {
        public string Level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.Level == null)
                throw new BusinessException("Level không được null", System.Net.HttpStatusCode.BadRequest);
        }
        private Result DeleteData(ObjectContext context)
        {
            using(var cmd = new CqLevexp10DeleteByIdRepository())
			{
				cmd.Level = this.Level;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.DeleteData(context);
        }
    }
}