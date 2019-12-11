using Entities;
using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository;

namespace PA.API.Models.CqDupName
{
    public class CqDupNameInsertAction : CommandBase
    {
        public cq_dup_name data { get; set; }
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
                throw new BusinessException("Dữ liệu không thể null", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private Result InsertData(ObjectContext context)
        {
            using(var cmd = new CqDupNameInsertRepository())
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