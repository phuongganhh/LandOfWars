using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemadditionGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_itemaddition")
                .Where("cq_itemaddition.id",this.id)
				.Select(
					"cq_itemaddition.id",
					"cq_itemaddition.typeid",
					"cq_itemaddition.level",
					"cq_itemaddition.life",
					"cq_itemaddition.attack_max",
					"cq_itemaddition.attack_min",
					"cq_itemaddition.defence",
					"cq_itemaddition.defence_max",
					"cq_itemaddition.defence_percent",
					"cq_itemaddition.max_en",
					"cq_itemaddition.charge_en",
					"cq_itemaddition.max_power",
					"cq_itemaddition.charge_power",
					"cq_itemaddition.max_range",
					"cq_itemaddition.nicety",
					"cq_itemaddition.dodge",
					"cq_itemaddition.pack_size"
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