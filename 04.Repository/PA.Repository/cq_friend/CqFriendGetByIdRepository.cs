using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqFriendGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_friend")
                .Where("cq_friend.id",this.id)
				.Select(
					"cq_friend.id",
					"cq_friend.userid",
					"cq_friend.friend",
					"cq_friend.robottype",
					"cq_friend.ranklevel",
					"cq_friend.friendname",
					"cq_friend.relation",
					"cq_friend.robotname",
					"cq_friend.synname",
					"cq_friend.fellowship",
					"cq_friend.TransferUsage"
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