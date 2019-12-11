using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAuctionSystemItemGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_auction_system_item")
                .Where("cq_auction_system_item.id",this.id)
				.Select(
					"cq_auction_system_item.id",
					"cq_auction_system_item.TYPE",
					"cq_auction_system_item.auction_id",
					"cq_auction_system_item.amount",
					"cq_auction_system_item.amount_limit",
					"cq_auction_system_item.ident",
					"cq_auction_system_item.gem1",
					"cq_auction_system_item.gem2",
					"cq_auction_system_item.magic1",
					"cq_auction_system_item.magic2",
					"cq_auction_system_item.magic3",
					"cq_auction_system_item.DATA",
					"cq_auction_system_item.warghostexp",
					"cq_auction_system_item.gemtype",
					"cq_auction_system_item.avilabletime",
					"cq_auction_system_item.date_type",
					"cq_auction_system_item.date_param",
					"cq_auction_system_item.value",
					"cq_auction_system_item.eudemon_attack1",
					"cq_auction_system_item.eudemon_attack2",
					"cq_auction_system_item.eudemon_attack3",
					"cq_auction_system_item.eudemon_attack4",
					"cq_auction_system_item.special_effect",
					"cq_auction_system_item.forgename"
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