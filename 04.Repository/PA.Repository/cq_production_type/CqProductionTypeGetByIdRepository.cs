using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqProductionTypeGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_production_type")
                .Where("cq_production_type.id",this.id)
				.Select(
					"cq_production_type.id",
					"cq_production_type.item",
					"cq_production_type.production_sort",
					"cq_production_type.req_production",
					"cq_production_type.research_type",
					"cq_production_type.research_lv",
					"cq_production_type.lvup_stone",
					"cq_production_type.evolve1",
					"cq_production_type.evolve2",
					"cq_production_type.evolve3",
					"cq_production_type.evolv_stone",
					"cq_production_type.material_lv",
					"cq_production_type.req_amount",
					"cq_production_type.compound_amount",
					"cq_production_type.activation",
					"cq_production_type.name"
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