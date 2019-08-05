using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqRelationTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_relation_type")
                .Where("cq_relation_type.id",this.id)
				.Select(
					"cq_relation_type.id",
					"cq_relation_type.relation_lev",
					"cq_relation_type.relation_need",
					"cq_relation_type.brother_lev_name",
					"cq_relation_type.pk_relation_reduce",
					"cq_relation_type.talk_add"
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