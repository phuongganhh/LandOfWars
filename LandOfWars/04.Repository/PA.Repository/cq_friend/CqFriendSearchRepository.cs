using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqFriendSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? userid { get; set; }
		public int? friend { get; set; }
		public int? robottype { get; set; }
		public int? ranklevel { get; set; }
		public string friendname { get; set; }
		public int? relation { get; set; }
		public string robotname { get; set; }
		public string synname { get; set; }
		public int? fellowship { get; set; }
		public int? TransferUsage { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_friend")
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
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_friend")
                        .Select("cq_friend.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_friend.id","%" + this.id.ToString() + "%");
			}
			if(this.userid != null)
			{
				result = result.WhereLike("cq_friend.userid","%" + this.userid.ToString() + "%");
			}
			if(this.friend != null)
			{
				result = result.WhereLike("cq_friend.friend","%" + this.friend.ToString() + "%");
			}
			if(this.robottype != null)
			{
				result = result.WhereLike("cq_friend.robottype","%" + this.robottype.ToString() + "%");
			}
			if(this.ranklevel != null)
			{
				result = result.WhereLike("cq_friend.ranklevel","%" + this.ranklevel.ToString() + "%");
			}
			if(this.friendname != null)
			{
				result = result.WhereLike("cq_friend.friendname","%" + this.friendname.ToString() + "%");
			}
			if(this.relation != null)
			{
				result = result.WhereLike("cq_friend.relation","%" + this.relation.ToString() + "%");
			}
			if(this.robotname != null)
			{
				result = result.WhereLike("cq_friend.robotname","%" + this.robotname.ToString() + "%");
			}
			if(this.synname != null)
			{
				result = result.WhereLike("cq_friend.synname","%" + this.synname.ToString() + "%");
			}
			if(this.fellowship != null)
			{
				result = result.WhereLike("cq_friend.fellowship","%" + this.fellowship.ToString() + "%");
			}
			if(this.TransferUsage != null)
			{
				result = result.WhereLike("cq_friend.TransferUsage","%" + this.TransferUsage.ToString() + "%");
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