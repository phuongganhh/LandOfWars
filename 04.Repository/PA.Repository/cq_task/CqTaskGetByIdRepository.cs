using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTaskGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_task")
                .Where("cq_task.id",this.id)
				.Select(
					"cq_task.id",
					"cq_task.id_next",
					"cq_task.id_nextfail",
					"cq_task.itemname1",
					"cq_task.itemname2",
					"cq_task.money",
					"cq_task.profession",
					"cq_task.sex",
					"cq_task.min_pk",
					"cq_task.max_pk",
					"cq_task.team",
					"cq_task.metempsychosis",
					"cq_task.query",
					"cq_task.marriage",
					"cq_task.client_active"
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