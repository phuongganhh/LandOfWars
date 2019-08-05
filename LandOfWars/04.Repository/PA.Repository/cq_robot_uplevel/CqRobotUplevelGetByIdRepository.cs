using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobotUplevelGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_robot_uplevel")
                .Where("cq_robot_uplevel.id",this.id)
				.Select(
					"cq_robot_uplevel.id",
					"cq_robot_uplevel.origin_type",
					"cq_robot_uplevel.req1",
					"cq_robot_uplevel.req2",
					"cq_robot_uplevel.req3",
					"cq_robot_uplevel.req4",
					"cq_robot_uplevel.req5",
					"cq_robot_uplevel.req6",
					"cq_robot_uplevel.add1",
					"cq_robot_uplevel.add2",
					"cq_robot_uplevel.add3",
					"cq_robot_uplevel.add4",
					"cq_robot_uplevel.add5",
					"cq_robot_uplevel.add6",
					"cq_robot_uplevel.equip_pos",
					"cq_robot_uplevel.equip_itemtype",
					"cq_robot_uplevel.add_register",
					"cq_robot_uplevel.req_level"
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