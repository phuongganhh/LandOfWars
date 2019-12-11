using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDupNameGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? Id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.Id == null)
            {
                throw new BusinessException("Id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_dup_name")
                .Where("cq_dup_name.Id",this.Id)
				.Select(
					"cq_dup_name.Id",
					"cq_dup_name.Complete",
					"cq_dup_name.Type",
					"cq_dup_name.object_id",
					"cq_dup_name.Old_name",
					"cq_dup_name.Name",
					"cq_dup_name.New_name",
					"cq_dup_name.serverflag"
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