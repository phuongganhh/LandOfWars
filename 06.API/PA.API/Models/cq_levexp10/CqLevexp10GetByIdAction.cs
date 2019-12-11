using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqLevexp10
{
    public class CqLevexp10GetByIdAction : CommandBase<dynamic>
    {
        public string Level { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.Level == null)
            {
                throw new BusinessException("Level is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqLevexp10GetByIdRepository<dynamic>())
			{
				cmd.Level = this.Level;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}