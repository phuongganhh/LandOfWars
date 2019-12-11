using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqGlobalvariableGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_globalvariable")
                .Where("cq_globalvariable.id",this.id)
				.Select(
					"cq_globalvariable.id",
					"cq_globalvariable.type",
					"cq_globalvariable.Data1",
					"cq_globalvariable.Data2",
					"cq_globalvariable.Data3",
					"cq_globalvariable.Data4",
					"cq_globalvariable.Data5",
					"cq_globalvariable.Description"
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