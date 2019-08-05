using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqUnlawful
{
    public class CqUnlawfulGetByIdAction : CommandBase<dynamic>
    {
        public int? ID { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.ID == null)
            {
                throw new BusinessException("ID is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqUnlawfulGetByIdRepository<dynamic>())
			{
				cmd.ID = this.ID;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}