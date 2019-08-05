using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqFamilySearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string family_name { get; set; }
		public int? rank { get; set; }
		public string lead_name { get; set; }
		public int? lead_id { get; set; }
		public string announce { get; set; }
		public int? money { get; set; }
		public int? repute { get; set; }
		public int? amount { get; set; }
		public int? enemy_family0_id { get; set; }
		public int? enemy_family1_id { get; set; }
		public int? enemy_family2_id { get; set; }
		public int? enemy_family3_id { get; set; }
		public int? enemy_family4_id { get; set; }
		public int? ally_family0_id { get; set; }
		public int? ally_family1_id { get; set; }
		public int? ally_family2_id { get; set; }
		public int? ally_family3_id { get; set; }
		public int? ally_family4_id { get; set; }
		public int? create_date { get; set; }
		public string create_name { get; set; }
		public int? Star_tower { get; set; }
		public int? family_mapid { get; set; }
		public int? del_flag { get; set; }
		public int? challenge { get; set; }
		public int? occupy { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_family")
				.Select(
					"cq_family.id",
					"cq_family.family_name",
					"cq_family.rank",
					"cq_family.lead_name",
					"cq_family.lead_id",
					"cq_family.announce",
					"cq_family.money",
					"cq_family.repute",
					"cq_family.amount",
					"cq_family.enemy_family0_id",
					"cq_family.enemy_family1_id",
					"cq_family.enemy_family2_id",
					"cq_family.enemy_family3_id",
					"cq_family.enemy_family4_id",
					"cq_family.ally_family0_id",
					"cq_family.ally_family1_id",
					"cq_family.ally_family2_id",
					"cq_family.ally_family3_id",
					"cq_family.ally_family4_id",
					"cq_family.create_date",
					"cq_family.create_name",
					"cq_family.Star_tower",
					"cq_family.family_mapid",
					"cq_family.del_flag",
					"cq_family.challenge",
					"cq_family.occupy"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_family")
                        .Select("cq_family.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_family.id","%" + this.id.ToString() + "%");
			}
			if(this.family_name != null)
			{
				result = result.WhereLike("cq_family.family_name","%" + this.family_name.ToString() + "%");
			}
			if(this.rank != null)
			{
				result = result.WhereLike("cq_family.rank","%" + this.rank.ToString() + "%");
			}
			if(this.lead_name != null)
			{
				result = result.WhereLike("cq_family.lead_name","%" + this.lead_name.ToString() + "%");
			}
			if(this.lead_id != null)
			{
				result = result.WhereLike("cq_family.lead_id","%" + this.lead_id.ToString() + "%");
			}
			if(this.announce != null)
			{
				result = result.WhereLike("cq_family.announce","%" + this.announce.ToString() + "%");
			}
			if(this.money != null)
			{
				result = result.WhereLike("cq_family.money","%" + this.money.ToString() + "%");
			}
			if(this.repute != null)
			{
				result = result.WhereLike("cq_family.repute","%" + this.repute.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_family.amount","%" + this.amount.ToString() + "%");
			}
			if(this.enemy_family0_id != null)
			{
				result = result.WhereLike("cq_family.enemy_family0_id","%" + this.enemy_family0_id.ToString() + "%");
			}
			if(this.enemy_family1_id != null)
			{
				result = result.WhereLike("cq_family.enemy_family1_id","%" + this.enemy_family1_id.ToString() + "%");
			}
			if(this.enemy_family2_id != null)
			{
				result = result.WhereLike("cq_family.enemy_family2_id","%" + this.enemy_family2_id.ToString() + "%");
			}
			if(this.enemy_family3_id != null)
			{
				result = result.WhereLike("cq_family.enemy_family3_id","%" + this.enemy_family3_id.ToString() + "%");
			}
			if(this.enemy_family4_id != null)
			{
				result = result.WhereLike("cq_family.enemy_family4_id","%" + this.enemy_family4_id.ToString() + "%");
			}
			if(this.ally_family0_id != null)
			{
				result = result.WhereLike("cq_family.ally_family0_id","%" + this.ally_family0_id.ToString() + "%");
			}
			if(this.ally_family1_id != null)
			{
				result = result.WhereLike("cq_family.ally_family1_id","%" + this.ally_family1_id.ToString() + "%");
			}
			if(this.ally_family2_id != null)
			{
				result = result.WhereLike("cq_family.ally_family2_id","%" + this.ally_family2_id.ToString() + "%");
			}
			if(this.ally_family3_id != null)
			{
				result = result.WhereLike("cq_family.ally_family3_id","%" + this.ally_family3_id.ToString() + "%");
			}
			if(this.ally_family4_id != null)
			{
				result = result.WhereLike("cq_family.ally_family4_id","%" + this.ally_family4_id.ToString() + "%");
			}
			if(this.create_date != null)
			{
				result = result.WhereLike("cq_family.create_date","%" + this.create_date.ToString() + "%");
			}
			if(this.create_name != null)
			{
				result = result.WhereLike("cq_family.create_name","%" + this.create_name.ToString() + "%");
			}
			if(this.Star_tower != null)
			{
				result = result.WhereLike("cq_family.Star_tower","%" + this.Star_tower.ToString() + "%");
			}
			if(this.family_mapid != null)
			{
				result = result.WhereLike("cq_family.family_mapid","%" + this.family_mapid.ToString() + "%");
			}
			if(this.del_flag != null)
			{
				result = result.WhereLike("cq_family.del_flag","%" + this.del_flag.ToString() + "%");
			}
			if(this.challenge != null)
			{
				result = result.WhereLike("cq_family.challenge","%" + this.challenge.ToString() + "%");
			}
			if(this.occupy != null)
			{
				result = result.WhereLike("cq_family.occupy","%" + this.occupy.ToString() + "%");
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