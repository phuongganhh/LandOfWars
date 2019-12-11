using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShiprecordGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_shiprecord")
                .Where("cq_shiprecord.id",this.id)
				.Select(
					"cq_shiprecord.id",
					"cq_shiprecord.mission",
					"cq_shiprecord.type",
					"cq_shiprecord.record",
					"cq_shiprecord.time",
					"cq_shiprecord.player1",
					"cq_shiprecord.player2",
					"cq_shiprecord.player3",
					"cq_shiprecord.player4",
					"cq_shiprecord.player5",
					"cq_shiprecord.player6",
					"cq_shiprecord.player7",
					"cq_shiprecord.player8",
					"cq_shiprecord.player9",
					"cq_shiprecord.player10",
					"cq_shiprecord.player11",
					"cq_shiprecord.player12",
					"cq_shiprecord.player13",
					"cq_shiprecord.player14",
					"cq_shiprecord.player15",
					"cq_shiprecord.player16",
					"cq_shiprecord.player17",
					"cq_shiprecord.player18",
					"cq_shiprecord.player19",
					"cq_shiprecord.player20"
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