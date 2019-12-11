using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqLifeskilltype
{
    public class CqLifeskilltypeGetByIdAction : CommandBase<dynamic>
    {
        public int? Id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.Id == null)
            {
                throw new BusinessException("Id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqLifeskilltypeGetByIdRepository<dynamic>())
			{
				cmd.Id = this.Id;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}