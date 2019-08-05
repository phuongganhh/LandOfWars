using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqUserXSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? big_badluck { get; set; }
		public int? small_badluck { get; set; }
		public int? lottery_times { get; set; }
		public int? big_goodluck { get; set; }
		public int? small_goodluck { get; set; }
		public int? lastlottery { get; set; }
		public long? Stone0 { get; set; }
		public int? Stone1 { get; set; }
		public int? Stone2 { get; set; }
		public int? chk_sum { get; set; }
		public int? ExpBallRobot { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_user_x")
				.Select(
					"cq_user_x.id",
					"cq_user_x.name",
					"cq_user_x.big_badluck",
					"cq_user_x.small_badluck",
					"cq_user_x.lottery_times",
					"cq_user_x.big_goodluck",
					"cq_user_x.small_goodluck",
					"cq_user_x.lastlottery",
					"cq_user_x.Stone0",
					"cq_user_x.Stone1",
					"cq_user_x.Stone2",
					"cq_user_x.chk_sum",
					"cq_user_x.ExpBallRobot"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_user_x")
                        .Select("cq_user_x.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_user_x.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_user_x.name","%" + this.name.ToString() + "%");
			}
			if(this.big_badluck != null)
			{
				result = result.WhereLike("cq_user_x.big_badluck","%" + this.big_badluck.ToString() + "%");
			}
			if(this.small_badluck != null)
			{
				result = result.WhereLike("cq_user_x.small_badluck","%" + this.small_badluck.ToString() + "%");
			}
			if(this.lottery_times != null)
			{
				result = result.WhereLike("cq_user_x.lottery_times","%" + this.lottery_times.ToString() + "%");
			}
			if(this.big_goodluck != null)
			{
				result = result.WhereLike("cq_user_x.big_goodluck","%" + this.big_goodluck.ToString() + "%");
			}
			if(this.small_goodluck != null)
			{
				result = result.WhereLike("cq_user_x.small_goodluck","%" + this.small_goodluck.ToString() + "%");
			}
			if(this.lastlottery != null)
			{
				result = result.WhereLike("cq_user_x.lastlottery","%" + this.lastlottery.ToString() + "%");
			}
			if(this.Stone0 != null)
			{
				result = result.WhereLike("cq_user_x.Stone0","%" + this.Stone0.ToString() + "%");
			}
			if(this.Stone1 != null)
			{
				result = result.WhereLike("cq_user_x.Stone1","%" + this.Stone1.ToString() + "%");
			}
			if(this.Stone2 != null)
			{
				result = result.WhereLike("cq_user_x.Stone2","%" + this.Stone2.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_user_x.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.ExpBallRobot != null)
			{
				result = result.WhereLike("cq_user_x.ExpBallRobot","%" + this.ExpBallRobot.ToString() + "%");
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