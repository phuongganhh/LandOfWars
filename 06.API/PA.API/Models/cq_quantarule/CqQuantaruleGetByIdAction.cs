using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqQuantarule
{
    public class CqQuantaruleGetByIdAction : CommandBase<dynamic>
    {
        public int? LEVEL { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.LEVEL == null)
            {
                throw new BusinessException("LEVEL is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqQuantaruleGetByIdRepository<dynamic>())
			{
				cmd.LEVEL = this.LEVEL;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}