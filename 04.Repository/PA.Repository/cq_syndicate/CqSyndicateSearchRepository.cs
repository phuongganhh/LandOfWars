using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSyndicateSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public string announce { get; set; }
		public string tenet { get; set; }
		public int? member_title { get; set; }
		public int? leader_id { get; set; }
		public string leader_name { get; set; }
		public long? money { get; set; }
		public int? del_flag { get; set; }
		public int? amount { get; set; }
		public int? enemy0 { get; set; }
		public int? enemy1 { get; set; }
		public int? enemy2 { get; set; }
		public int? enemy3 { get; set; }
		public int? enemy4 { get; set; }
		public int? ally0 { get; set; }
		public int? ally1 { get; set; }
		public int? ally2 { get; set; }
		public int? ally3 { get; set; }
		public int? ally4 { get; set; }
		public int? rank { get; set; }
		public int? icon { get; set; }
		public int? createdate { get; set; }
		public int? coach_user0 { get; set; }
		public int? coach_user1 { get; set; }
		public int? coach_user2 { get; set; }
		public int? coach_user3 { get; set; }
		public int? coach_user4 { get; set; }
		public int? coach_user5 { get; set; }
		public int? coach_user6 { get; set; }
		public int? coach_user7 { get; set; }
		public int? coach_user8 { get; set; }
		public int? coach_user9 { get; set; }
		public long? Totem_pole { get; set; }
		public int? member_title_cnt { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_syndicate")
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
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_syndicate")
                        .Select("cq_syndicate.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_syndicate.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_syndicate.name","%" + this.name.ToString() + "%");
			}
			if(this.announce != null)
			{
				result = result.WhereLike("cq_syndicate.announce","%" + this.announce.ToString() + "%");
			}
			if(this.tenet != null)
			{
				result = result.WhereLike("cq_syndicate.tenet","%" + this.tenet.ToString() + "%");
			}
			if(this.member_title != null)
			{
				result = result.WhereLike("cq_syndicate.member_title","%" + this.member_title.ToString() + "%");
			}
			if(this.leader_id != null)
			{
				result = result.WhereLike("cq_syndicate.leader_id","%" + this.leader_id.ToString() + "%");
			}
			if(this.leader_name != null)
			{
				result = result.WhereLike("cq_syndicate.leader_name","%" + this.leader_name.ToString() + "%");
			}
			if(this.money != null)
			{
				result = result.WhereLike("cq_syndicate.money","%" + this.money.ToString() + "%");
			}
			if(this.del_flag != null)
			{
				result = result.WhereLike("cq_syndicate.del_flag","%" + this.del_flag.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_syndicate.amount","%" + this.amount.ToString() + "%");
			}
			if(this.enemy0 != null)
			{
				result = result.WhereLike("cq_syndicate.enemy0","%" + this.enemy0.ToString() + "%");
			}
			if(this.enemy1 != null)
			{
				result = result.WhereLike("cq_syndicate.enemy1","%" + this.enemy1.ToString() + "%");
			}
			if(this.enemy2 != null)
			{
				result = result.WhereLike("cq_syndicate.enemy2","%" + this.enemy2.ToString() + "%");
			}
			if(this.enemy3 != null)
			{
				result = result.WhereLike("cq_syndicate.enemy3","%" + this.enemy3.ToString() + "%");
			}
			if(this.enemy4 != null)
			{
				result = result.WhereLike("cq_syndicate.enemy4","%" + this.enemy4.ToString() + "%");
			}
			if(this.ally0 != null)
			{
				result = result.WhereLike("cq_syndicate.ally0","%" + this.ally0.ToString() + "%");
			}
			if(this.ally1 != null)
			{
				result = result.WhereLike("cq_syndicate.ally1","%" + this.ally1.ToString() + "%");
			}
			if(this.ally2 != null)
			{
				result = result.WhereLike("cq_syndicate.ally2","%" + this.ally2.ToString() + "%");
			}
			if(this.ally3 != null)
			{
				result = result.WhereLike("cq_syndicate.ally3","%" + this.ally3.ToString() + "%");
			}
			if(this.ally4 != null)
			{
				result = result.WhereLike("cq_syndicate.ally4","%" + this.ally4.ToString() + "%");
			}
			if(this.rank != null)
			{
				result = result.WhereLike("cq_syndicate.rank","%" + this.rank.ToString() + "%");
			}
			if(this.icon != null)
			{
				result = result.WhereLike("cq_syndicate.icon","%" + this.icon.ToString() + "%");
			}
			if(this.createdate != null)
			{
				result = result.WhereLike("cq_syndicate.createdate","%" + this.createdate.ToString() + "%");
			}
			if(this.coach_user0 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user0","%" + this.coach_user0.ToString() + "%");
			}
			if(this.coach_user1 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user1","%" + this.coach_user1.ToString() + "%");
			}
			if(this.coach_user2 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user2","%" + this.coach_user2.ToString() + "%");
			}
			if(this.coach_user3 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user3","%" + this.coach_user3.ToString() + "%");
			}
			if(this.coach_user4 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user4","%" + this.coach_user4.ToString() + "%");
			}
			if(this.coach_user5 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user5","%" + this.coach_user5.ToString() + "%");
			}
			if(this.coach_user6 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user6","%" + this.coach_user6.ToString() + "%");
			}
			if(this.coach_user7 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user7","%" + this.coach_user7.ToString() + "%");
			}
			if(this.coach_user8 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user8","%" + this.coach_user8.ToString() + "%");
			}
			if(this.coach_user9 != null)
			{
				result = result.WhereLike("cq_syndicate.coach_user9","%" + this.coach_user9.ToString() + "%");
			}
			if(this.Totem_pole != null)
			{
				result = result.WhereLike("cq_syndicate.Totem_pole","%" + this.Totem_pole.ToString() + "%");
			}
			if(this.member_title_cnt != null)
			{
				result = result.WhereLike("cq_syndicate.member_title_cnt","%" + this.member_title_cnt.ToString() + "%");
			}

            this.paging.data = result.Result<T>();
            return this.paging;
        }
		protected override void ValidateCore(ObjectContext context)
        {
            this.current_page = this.current_page ?? 1;
            this.page_size = this.page_size ?? context.GetPageSize();
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            if (this.paging == null)
                this.paging = new Paging<T>();
            this.paging.current_page = this.current_page;
            this.paging.page_size = this.page_size;
            this.paging.is_success = true;
            this.paging.msg = "success";
            this.paging.error_code = 0;
        }
        protected override Result<Paging<T>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}