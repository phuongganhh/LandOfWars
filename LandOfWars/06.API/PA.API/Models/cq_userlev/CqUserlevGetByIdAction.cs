using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqUserlev
{
    public class CqUserlevGetByIdAction : CommandBase<dynamic>
    {
        public int? level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.level == null)
            {
                throw new BusinessException("level is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqUserlevGetByIdRepository<dynamic>())
			{
				cmd.level = this.level;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}