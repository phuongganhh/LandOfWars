using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSyndicateGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_syndicate")
                .Where("cq_syndicate.id",this.id)
				.Select(
					"cq_syndicate.id",
					"cq_syndicate.name",
					"cq_syndicate.announce",
					"cq_syndicate.tenet",
					"cq_syndicate.member_title",
					"cq_syndicate.leader_id",
					"cq_syndicate.leader_name",
					"cq_syndicate.money",
					"cq_syndicate.del_flag",
					"cq_syndicate.amount",
					"cq_syndicate.enemy0",
					"cq_syndicate.enemy1",
					"cq_syndicate.enemy2",
					"cq_syndicate.enemy3",
					"cq_syndicate.enemy4",
					"cq_syndicate.ally0",
					"cq_syndicate.ally1",
					"cq_syndicate.ally2",
					"cq_syndicate.ally3",
					"cq_syndicate.ally4",
					"cq_syndicate.rank",
					"cq_syndicate.icon",
					"cq_syndicate.createdate",
					"cq_syndicate.coach_user0",
					"cq_syndicate.coach_user1",
					"cq_syndicate.coach_user2",
					"cq_syndicate.coach_user3",
					"cq_syndicate.coach_user4",
					"cq_syndicate.coach_user5",
					"cq_syndicate.coach_user6",
					"cq_syndicate.coach_user7",
					"cq_syndicate.coach_user8",
					"cq_syndicate.coach_user9",
					"cq_syndicate.Totem_pole",
					"cq_syndicate.member_title_cnt"
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