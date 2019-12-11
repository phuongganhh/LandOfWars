using Entities;
using PA;
using PA.Extensions;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserXInsertRepository : CommandBase
    {
        public cq_user_x data { get; set; }
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
            context.db.From("cq_user_x").Insert(this.data).ExecuteNotResult();
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.InsertData(context);
        }
    }
}