using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqTitletypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_titletype")
                .Where("cq_titletype.id",this.id)
				.Select(
					"cq_titletype.id",
					"cq_titletype.name"
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