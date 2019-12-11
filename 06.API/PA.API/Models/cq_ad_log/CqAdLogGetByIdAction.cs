using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqAdLog
{
    public class CqAdLogGetByIdAction : CommandBase<dynamic>
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.id == null)
            {
                throw new BusinessException("id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqAdLogGetByIdRepository<dynamic>())
			{
				cmd.id = this.id;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}