using Entities;
using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository; using System.Net;

namespace PA.API.Models.CqItemex
{
    public class CqItemexInsertAction : CommandBase
    {
        public cq_itemex data { get; set; }
        protected override void OnExecutingCore(ObjectContext context)
        {
            //this.data.create_time = DateTime.Now;
            //this.data.update_time = DateTime.Now;
			//this.data.id = Guid.NewGuid().ToString().Replace("-", "");
        }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.data == null)
            {
                throw new BusinessException("Dữ liệu không thể null", HttpStatusCode.BadRequest);
            }
        }
        private Result InsertData(ObjectContext context)
        {
            using(var cmd = new CqItemexInsertRepository())
			{
				cmd.data = this.data;
				return cmd.Execute(context);
			}
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.InsertData(context);
        }
    }
}