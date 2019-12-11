using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponImproveSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? itemtypeid { get; set; }
		public int? Uplev1 { get; set; }
		public int? Uplev2 { get; set; }
		public int? Uplev3 { get; set; }
		public int? Uplev4 { get; set; }
		public int? Money_uplev { get; set; }
		public int? Upquality1 { get; set; }
		public int? Upquality2 { get; set; }
		public int? Upquality3 { get; set; }
		public int? Upquality4 { get; set; }
		public int? Gem { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_weapon_improve")
				.Select(
					"cq_weapon_improve.id",
					"cq_weapon_improve.itemtypeid",
					"cq_weapon_improve.Uplev1",
					"cq_weapon_improve.Uplev2",
					"cq_weapon_improve.Uplev3",
					"cq_weapon_improve.Uplev4",
					"cq_weapon_improve.Money_uplev",
					"cq_weapon_improve.Upquality1",
					"cq_weapon_improve.Upquality2",
					"cq_weapon_improve.Upquality3",
					"cq_weapon_improve.Upquality4",
					"cq_weapon_improve.Gem"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_weapon_improve")
                        .Select("cq_weapon_improve.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_weapon_improve.id","%" + this.id.ToString() + "%");
			}
			if(this.itemtypeid != null)
			{
				result = result.WhereLike("cq_weapon_improve.itemtypeid","%" + this.itemtypeid.ToString() + "%");
			}
			if(this.Uplev1 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Uplev1","%" + this.Uplev1.ToString() + "%");
			}
			if(this.Uplev2 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Uplev2","%" + this.Uplev2.ToString() + "%");
			}
			if(this.Uplev3 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Uplev3","%" + this.Uplev3.ToString() + "%");
			}
			if(this.Uplev4 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Uplev4","%" + this.Uplev4.ToString() + "%");
			}
			if(this.Money_uplev != null)
			{
				result = result.WhereLike("cq_weapon_improve.Money_uplev","%" + this.Money_uplev.ToString() + "%");
			}
			if(this.Upquality1 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Upquality1","%" + this.Upquality1.ToString() + "%");
			}
			if(this.Upquality2 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Upquality2","%" + this.Upquality2.ToString() + "%");
			}
			if(this.Upquality3 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Upquality3","%" + this.Upquality3.ToString() + "%");
			}
			if(this.Upquality4 != null)
			{
				result = result.WhereLike("cq_weapon_improve.Upquality4","%" + this.Upquality4.ToString() + "%");
			}
			if(this.Gem != null)
			{
				result = result.WhereLike("cq_weapon_improve.Gem","%" + this.Gem.ToString() + "%");
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