using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqAuctionSystemItemSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? TYPE { get; set; }
		public int? auction_id { get; set; }
		public int? amount { get; set; }
		public int? amount_limit { get; set; }
		public int? ident { get; set; }
		public int? gem1 { get; set; }
		public int? gem2 { get; set; }
		public int? magic1 { get; set; }
		public int? magic2 { get; set; }
		public int? magic3 { get; set; }
		public int? DATA { get; set; }
		public int? warghostexp { get; set; }
		public int? gemtype { get; set; }
		public int? avilabletime { get; set; }
		public int? date_type { get; set; }
		public string date_param { get; set; }
		public int? value { get; set; }
		public int? eudemon_attack1 { get; set; }
		public int? eudemon_attack2 { get; set; }
		public int? eudemon_attack3 { get; set; }
		public int? eudemon_attack4 { get; set; }
		public int? special_effect { get; set; }
		public string forgename { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_auction_system_item")
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
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_auction_system_item")
                        .Select("cq_auction_system_item.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_auction_system_item.id","%" + this.id.ToString() + "%");
			}
			if(this.TYPE != null)
			{
				result = result.WhereLike("cq_auction_system_item.TYPE","%" + this.TYPE.ToString() + "%");
			}
			if(this.auction_id != null)
			{
				result = result.WhereLike("cq_auction_system_item.auction_id","%" + this.auction_id.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_auction_system_item.amount","%" + this.amount.ToString() + "%");
			}
			if(this.amount_limit != null)
			{
				result = result.WhereLike("cq_auction_system_item.amount_limit","%" + this.amount_limit.ToString() + "%");
			}
			if(this.ident != null)
			{
				result = result.WhereLike("cq_auction_system_item.ident","%" + this.ident.ToString() + "%");
			}
			if(this.gem1 != null)
			{
				result = result.WhereLike("cq_auction_system_item.gem1","%" + this.gem1.ToString() + "%");
			}
			if(this.gem2 != null)
			{
				result = result.WhereLike("cq_auction_system_item.gem2","%" + this.gem2.ToString() + "%");
			}
			if(this.magic1 != null)
			{
				result = result.WhereLike("cq_auction_system_item.magic1","%" + this.magic1.ToString() + "%");
			}
			if(this.magic2 != null)
			{
				result = result.WhereLike("cq_auction_system_item.magic2","%" + this.magic2.ToString() + "%");
			}
			if(this.magic3 != null)
			{
				result = result.WhereLike("cq_auction_system_item.magic3","%" + this.magic3.ToString() + "%");
			}
			if(this.DATA != null)
			{
				result = result.WhereLike("cq_auction_system_item.DATA","%" + this.DATA.ToString() + "%");
			}
			if(this.warghostexp != null)
			{
				result = result.WhereLike("cq_auction_system_item.warghostexp","%" + this.warghostexp.ToString() + "%");
			}
			if(this.gemtype != null)
			{
				result = result.WhereLike("cq_auction_system_item.gemtype","%" + this.gemtype.ToString() + "%");
			}
			if(this.avilabletime != null)
			{
				result = result.WhereLike("cq_auction_system_item.avilabletime","%" + this.avilabletime.ToString() + "%");
			}
			if(this.date_type != null)
			{
				result = result.WhereLike("cq_auction_system_item.date_type","%" + this.date_type.ToString() + "%");
			}
			if(this.date_param != null)
			{
				result = result.WhereLike("cq_auction_system_item.date_param","%" + this.date_param.ToString() + "%");
			}
			if(this.value != null)
			{
				result = result.WhereLike("cq_auction_system_item.value","%" + this.value.ToString() + "%");
			}
			if(this.eudemon_attack1 != null)
			{
				result = result.WhereLike("cq_auction_system_item.eudemon_attack1","%" + this.eudemon_attack1.ToString() + "%");
			}
			if(this.eudemon_attack2 != null)
			{
				result = result.WhereLike("cq_auction_system_item.eudemon_attack2","%" + this.eudemon_attack2.ToString() + "%");
			}
			if(this.eudemon_attack3 != null)
			{
				result = result.WhereLike("cq_auction_system_item.eudemon_attack3","%" + this.eudemon_attack3.ToString() + "%");
			}
			if(this.eudemon_attack4 != null)
			{
				result = result.WhereLike("cq_auction_system_item.eudemon_attack4","%" + this.eudemon_attack4.ToString() + "%");
			}
			if(this.special_effect != null)
			{
				result = result.WhereLike("cq_auction_system_item.special_effect","%" + this.special_effect.ToString() + "%");
			}
			if(this.forgename != null)
			{
				result = result.WhereLike("cq_auction_system_item.forgename","%" + this.forgename.ToString() + "%");
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