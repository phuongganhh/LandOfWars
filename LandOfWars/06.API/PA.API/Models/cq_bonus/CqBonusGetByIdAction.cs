using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository; using System.Net;

namespace PA.API.Models.CqBonus
{
    public class CqBonusGetByIdAction : CommandBase<dynamic>
    {
        public int? action { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.action == null)
            {
                throw new BusinessException("action is not nullable", HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqBonusGetByIdRepository<dynamic>())
			{
				cmd.action = this.action;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}