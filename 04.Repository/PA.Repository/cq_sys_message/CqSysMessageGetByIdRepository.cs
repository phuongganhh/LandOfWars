using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSysMessageGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_sys_message")
                .Where("cq_sys_message.id",this.id)
				.Select(
					"cq_sys_message.id",
					"cq_sys_message.priority",
					"cq_sys_message.time_validity",
					"cq_sys_message.level",
					"cq_sys_message.robot_level",
					"cq_sys_message.god_status",
					"cq_sys_message.user_emoney",
					"cq_sys_message.account_vip",
					"cq_sys_message.mes_type",
					"cq_sys_message.message"
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