using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPetGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_pet")
                .Where("cq_pet.id",this.id)
				.Select(
					"cq_pet.id",
					"cq_pet.ownerid",
					"cq_pet.ownertype",
					"cq_pet.generatorid",
					"cq_pet.typeid",
					"cq_pet.name",
					"cq_pet.life",
					"cq_pet.mana",
					"cq_pet.recordmap_id",
					"cq_pet.recordx",
					"cq_pet.recordy",
					"cq_pet.data",
					"cq_pet.data1",
					"cq_pet.data2",
					"cq_pet.number"
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