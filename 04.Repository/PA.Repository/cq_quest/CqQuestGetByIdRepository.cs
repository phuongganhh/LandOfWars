using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqQuestGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_quest")
                .Where("cq_quest.id",this.id)
				.Select(
					"cq_quest.id",
					"cq_quest.iduser",
					"cq_quest.quest_id",
					"cq_quest.flag",
					"cq_quest.data1",
					"cq_quest.data2",
					"cq_quest.data3",
					"cq_quest.data4",
					"cq_quest.data5",
					"cq_quest.data6"
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