using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqLotterySearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? rank { get; set; }
		public int? chance { get; set; }
		public string prize_name { get; set; }
		public int? prize_type { get; set; }
		public int? prize_item { get; set; }
		public int? color { get; set; }
		public int? hole_num { get; set; }
		public int? addition_lev { get; set; }
		public int? hot_atk { get; set; }
		public int? shake_atk { get; set; }
		public int? sting_atk { get; set; }
		public int? decay_atk { get; set; }
		public int? hot_def { get; set; }
		public int? shake_def { get; set; }
		public int? sting_def { get; set; }
		public int? decay_def { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_lottery")
				.Select(
					"cq_lottery.id",
					"cq_lottery.type",
					"cq_lottery.rank",
					"cq_lottery.chance",
					"cq_lottery.prize_name",
					"cq_lottery.prize_type",
					"cq_lottery.prize_item",
					"cq_lottery.color",
					"cq_lottery.hole_num",
					"cq_lottery.addition_lev",
					"cq_lottery.hot_atk",
					"cq_lottery.shake_atk",
					"cq_lottery.sting_atk",
					"cq_lottery.decay_atk",
					"cq_lottery.hot_def",
					"cq_lottery.shake_def",
					"cq_lottery.sting_def",
					"cq_lottery.decay_def"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_lottery")
                        .Select("cq_lottery.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_lottery.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_lottery.type","%" + this.type.ToString() + "%");
			}
			if(this.rank != null)
			{
				result = result.WhereLike("cq_lottery.rank","%" + this.rank.ToString() + "%");
			}
			if(this.chance != null)
			{
				result = result.WhereLike("cq_lottery.chance","%" + this.chance.ToString() + "%");
			}
			if(this.prize_name != null)
			{
				result = result.WhereLike("cq_lottery.prize_name","%" + this.prize_name.ToString() + "%");
			}
			if(this.prize_type != null)
			{
				result = result.WhereLike("cq_lottery.prize_type","%" + this.prize_type.ToString() + "%");
			}
			if(this.prize_item != null)
			{
				result = result.WhereLike("cq_lottery.prize_item","%" + this.prize_item.ToString() + "%");
			}
			if(this.color != null)
			{
				result = result.WhereLike("cq_lottery.color","%" + this.color.ToString() + "%");
			}
			if(this.hole_num != null)
			{
				result = result.WhereLike("cq_lottery.hole_num","%" + this.hole_num.ToString() + "%");
			}
			if(this.addition_lev != null)
			{
				result = result.WhereLike("cq_lottery.addition_lev","%" + this.addition_lev.ToString() + "%");
			}
			if(this.hot_atk != null)
			{
				result = result.WhereLike("cq_lottery.hot_atk","%" + this.hot_atk.ToString() + "%");
			}
			if(this.shake_atk != null)
			{
				result = result.WhereLike("cq_lottery.shake_atk","%" + this.shake_atk.ToString() + "%");
			}
			if(this.sting_atk != null)
			{
				result = result.WhereLike("cq_lottery.sting_atk","%" + this.sting_atk.ToString() + "%");
			}
			if(this.decay_atk != null)
			{
				result = result.WhereLike("cq_lottery.decay_atk","%" + this.decay_atk.ToString() + "%");
			}
			if(this.hot_def != null)
			{
				result = result.WhereLike("cq_lottery.hot_def","%" + this.hot_def.ToString() + "%");
			}
			if(this.shake_def != null)
			{
				result = result.WhereLike("cq_lottery.shake_def","%" + this.shake_def.ToString() + "%");
			}
			if(this.sting_def != null)
			{
				result = result.WhereLike("cq_lottery.sting_def","%" + this.sting_def.ToString() + "%");
			}
			if(this.decay_def != null)
			{
				result = result.WhereLike("cq_lottery.decay_def","%" + this.decay_def.ToString() + "%");
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