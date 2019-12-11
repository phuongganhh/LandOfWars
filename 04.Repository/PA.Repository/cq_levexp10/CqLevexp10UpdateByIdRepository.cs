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
    public class CqLevexp10UpdateByIdRepository : CommandBase
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
            context.db
                .From("cq_levexp10")
                .Where("cq_levexp10.Level",this.data.Level)
                .Update(data)
                .ExecuteNotResult()
                ;
            return Success();
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            return this.UpdateData(context);
        }
    }
}