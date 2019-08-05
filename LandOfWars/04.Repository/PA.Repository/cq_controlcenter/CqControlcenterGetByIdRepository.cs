using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqControlcenterGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_controlcenter")
                .Where("cq_controlcenter.id",this.id)
				.Select(
					"cq_controlcenter.id",
					"cq_controlcenter.player_id",
					"cq_controlcenter.type",
					"cq_controlcenter.Item_ID",
					"cq_controlcenter.Data0",
					"cq_controlcenter.Data1",
					"cq_controlcenter.Data2",
					"cq_controlcenter.Data3",
					"cq_controlcenter.Data4"
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