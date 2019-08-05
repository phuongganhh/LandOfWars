using Entities;
using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;
namespace PA.API.Models.CqUserlev
{
    public class CqUserlevUpdateByIdAction : CommandBase
    {
        public cq_userlev data { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.data == null)
            {
                throw new BusinessException("Dữ liệu không thể null", System.Net.HttpStatusCode.BadRequest);
            }
            if(this.data.level == null)
            {
                throw new BusinessException("level không được null", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result UpdateData(ObjectContext context)
        {
            using(var cmd = new CqUserlevUpdateByIdRepository())
			{
				cmd.data = this.data;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.UpdateData(context);
        }
    }
}