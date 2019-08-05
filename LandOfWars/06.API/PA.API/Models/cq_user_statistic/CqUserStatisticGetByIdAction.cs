using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqUserStatistic
{
    public class CqUserStatisticGetByIdAction : CommandBase<dynamic>
    {
        public int? userid { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.userid == null)
            {
                throw new BusinessException("userid is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result<dynamic> GetData(ObjectContext context)
        {
            using(var cmd = new CqUserStatisticGetByIdRepository<dynamic>())
			{
				cmd.userid = this.userid;
				return cmd.Execute(context);
			}
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}