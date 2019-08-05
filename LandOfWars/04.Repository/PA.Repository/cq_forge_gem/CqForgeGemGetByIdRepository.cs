using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqForgeGemGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_forge_gem")
                .Where("cq_forge_gem.id",this.id)
				.Select(
					"cq_forge_gem.id",
					"cq_forge_gem.gem_type",
					"cq_forge_gem.forge_type",
					"cq_forge_gem.quality_luck",
					"cq_forge_gem.chance",
					"cq_forge_gem.append_chance"
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