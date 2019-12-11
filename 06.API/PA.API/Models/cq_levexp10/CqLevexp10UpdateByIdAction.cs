using Entities;
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
    public class CqLevexp10UpdateByIdAction : CommandBase
    {
        public cq_levexp10 data { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.data == null)
            {
                throw new BusinessException("Dữ liệu không thể null", System.Net.HttpStatusCode.BadRequest);
            }
            if(this.data.Level == null)
            {
                throw new BusinessException("Level không được null", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result UpdateData(ObjectContext context)
        {
            using(var cmd = new CqLevexp10UpdateByIdRepository())
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