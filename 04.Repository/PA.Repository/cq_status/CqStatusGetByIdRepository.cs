using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStatusGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.id == null)
            {
                throw new BusinessException("id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_status")
                .Where("cq_status.id",this.id)
				.Select(
					"cq_status.id",
					"cq_status.owner_id",
					"cq_status.robot_id",
					"cq_status.status",
					"cq_status.power",
					"cq_status.sort",
					"cq_status.leave_times",
					"cq_status.remain_time",
					"cq_status.end_time",
					"cq_status.nParam",
					"cq_status.nWParam"
				)
                .Result<T>()
                .FirstOrDefault()
                ;
        }
        protected override Result<T> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}