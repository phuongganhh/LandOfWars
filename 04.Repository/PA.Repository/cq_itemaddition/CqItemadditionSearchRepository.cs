using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemadditionSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? typeid { get; set; }
		public int? level { get; set; }
		public int? life { get; set; }
		public int? attack_max { get; set; }
		public int? attack_min { get; set; }
		public int? defence { get; set; }
		public int? defence_max { get; set; }
		public int? defence_percent { get; set; }
		public int? max_en { get; set; }
		public int? charge_en { get; set; }
		public int? max_power { get; set; }
		public int? charge_power { get; set; }
		public int? max_range { get; set; }
		public int? nicety { get; set; }
		public int? dodge { get; set; }
		public int? pack_size { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_itemaddition")
				.Select(
					"cq_itemaddition.id",
					"cq_itemaddition.typeid",
					"cq_itemaddition.level",
					"cq_itemaddition.life",
					"cq_itemaddition.attack_max",
					"cq_itemaddition.attack_min",
					"cq_itemaddition.defence",
					"cq_itemaddition.defence_max",
					"cq_itemaddition.defence_percent",
					"cq_itemaddition.max_en",
					"cq_itemaddition.charge_en",
					"cq_itemaddition.max_power",
					"cq_itemaddition.charge_power",
					"cq_itemaddition.max_range",
					"cq_itemaddition.nicety",
					"cq_itemaddition.dodge",
					"cq_itemaddition.pack_size"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_itemaddition")
                        .Select("cq_itemaddition.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_itemaddition.id","%" + this.id.ToString() + "%");
			}
			if(this.typeid != null)
			{
				result = result.WhereLike("cq_itemaddition.typeid","%" + this.typeid.ToString() + "%");
			}
			if(this.level != null)
			{
				result = result.WhereLike("cq_itemaddition.level","%" + this.level.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_itemaddition.life","%" + this.life.ToString() + "%");
			}
			if(this.attack_max != null)
			{
				result = result.WhereLike("cq_itemaddition.attack_max","%" + this.attack_max.ToString() + "%");
			}
			if(this.attack_min != null)
			{
				result = result.WhereLike("cq_itemaddition.attack_min","%" + this.attack_min.ToString() + "%");
			}
			if(this.defence != null)
			{
				result = result.WhereLike("cq_itemaddition.defence","%" + this.defence.ToString() + "%");
			}
			if(this.defence_max != null)
			{
				result = result.WhereLike("cq_itemaddition.defence_max","%" + this.defence_max.ToString() + "%");
			}
			if(this.defence_percent != null)
			{
				result = result.WhereLike("cq_itemaddition.defence_percent","%" + this.defence_percent.ToString() + "%");
			}
			if(this.max_en != null)
			{
				result = result.WhereLike("cq_itemaddition.max_en","%" + this.max_en.ToString() + "%");
			}
			if(this.charge_en != null)
			{
				result = result.WhereLike("cq_itemaddition.charge_en","%" + this.charge_en.ToString() + "%");
			}
			if(this.max_power != null)
			{
				result = result.WhereLike("cq_itemaddition.max_power","%" + this.max_power.ToString() + "%");
			}
			if(this.charge_power != null)
			{
				result = result.WhereLike("cq_itemaddition.charge_power","%" + this.charge_power.ToString() + "%");
			}
			if(this.max_range != null)
			{
				result = result.WhereLike("cq_itemaddition.max_range","%" + this.max_range.ToString() + "%");
			}
			if(this.nicety != null)
			{
				result = result.WhereLike("cq_itemaddition.nicety","%" + this.nicety.ToString() + "%");
			}
			if(this.dodge != null)
			{
				result = result.WhereLike("cq_itemaddition.dodge","%" + this.dodge.ToString() + "%");
			}
			if(this.pack_size != null)
			{
				result = result.WhereLike("cq_itemaddition.pack_size","%" + this.pack_size.ToString() + "%");
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