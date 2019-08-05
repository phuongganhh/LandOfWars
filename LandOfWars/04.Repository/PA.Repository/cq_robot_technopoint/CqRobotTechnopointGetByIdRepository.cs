using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRobotTechnopointGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_robot_technopoint")
                .Where("cq_robot_technopoint.id",this.id)
				.Select(
					"cq_robot_technopoint.id",
					"cq_robot_technopoint.Robot_Type",
					"cq_robot_technopoint.TYPE",
					"cq_robot_technopoint.NAME",
					"cq_robot_technopoint.Robot_Model_level",
					"cq_robot_technopoint.Precondition0",
					"cq_robot_technopoint.Precondition1",
					"cq_robot_technopoint.Precondition2",
					"cq_robot_technopoint.Precondition3",
					"cq_robot_technopoint.Precondition4",
					"cq_robot_technopoint.UsagePoint",
					"cq_robot_technopoint.Conflict0",
					"cq_robot_technopoint.Conflict1",
					"cq_robot_technopoint.Conflict2",
					"cq_robot_technopoint.point",
					"cq_robot_technopoint.UsageIndex",
					"cq_robot_technopoint.Action0",
					"cq_robot_technopoint.Action1"
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