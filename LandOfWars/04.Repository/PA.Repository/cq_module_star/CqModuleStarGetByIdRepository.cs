using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqModuleStarGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_module_star")
                .Where("cq_module_star.Id",this.Id)
				.Select(
					"cq_module_star.Id",
					"cq_module_star.type",
					"cq_module_star.Star_lev",
					"cq_module_star.Req_lev",
					"cq_module_star.Req_artifact",
					"cq_module_star.Req_crystal0",
					"cq_module_star.Req_crystal1",
					"cq_module_star.Req_crystal2",
					"cq_module_star.Req_meteor"
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