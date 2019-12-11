using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemexBakSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? ownertype { get; set; }
		public int? owner_id { get; set; }
		public int? player_id { get; set; }
		public int? position { get; set; }
		public int? amount { get; set; }
		public int? ident { get; set; }
		public int? data { get; set; }
		public int? plunder { get; set; }
		public int? sale_time { get; set; }
		public int? max_hp { get; set; }
		public int? weight { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? data3 { get; set; }
		public int? data4 { get; set; }
		public int? shape { get; set; }
		public int? addlevel { get; set; }
		public int? hot_atk { get; set; }
		public int? shake_atk { get; set; }
		public int? sting_atk { get; set; }
		public int? decay_atk { get; set; }
		public int? chk_sum { get; set; }
		public string Forgename { get; set; }
		public int? specialflag { get; set; }
		public int? data5 { get; set; }
		public int? data6 { get; set; }
		public int? weight3 { get; set; }
		public int? weight4 { get; set; }
		public long? Exp { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_itemex_bak")
				.Select(
					"cq_itemex_bak.id",
					"cq_itemex_bak.type",
					"cq_itemex_bak.ownertype",
					"cq_itemex_bak.owner_id",
					"cq_itemex_bak.player_id",
					"cq_itemex_bak.position",
					"cq_itemex_bak.amount",
					"cq_itemex_bak.ident",
					"cq_itemex_bak.data",
					"cq_itemex_bak.plunder",
					"cq_itemex_bak.sale_time",
					"cq_itemex_bak.max_hp",
					"cq_itemex_bak.weight",
					"cq_itemex_bak.data1",
					"cq_itemex_bak.data2",
					"cq_itemex_bak.data3",
					"cq_itemex_bak.data4",
					"cq_itemex_bak.shape",
					"cq_itemex_bak.addlevel",
					"cq_itemex_bak.hot_atk",
					"cq_itemex_bak.shake_atk",
					"cq_itemex_bak.sting_atk",
					"cq_itemex_bak.decay_atk",
					"cq_itemex_bak.chk_sum",
					"cq_itemex_bak.Forgename",
					"cq_itemex_bak.specialflag",
					"cq_itemex_bak.data5",
					"cq_itemex_bak.data6",
					"cq_itemex_bak.weight3",
					"cq_itemex_bak.weight4",
					"cq_itemex_bak.Exp"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_itemex_bak")
                        .Select("cq_itemex_bak.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_itemex_bak.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_itemex_bak.type","%" + this.type.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_itemex_bak.ownertype","%" + this.ownertype.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_itemex_bak.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_itemex_bak.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.position != null)
			{
				result = result.WhereLike("cq_itemex_bak.position","%" + this.position.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_itemex_bak.amount","%" + this.amount.ToString() + "%");
			}
			if(this.ident != null)
			{
				result = result.WhereLike("cq_itemex_bak.ident","%" + this.ident.ToString() + "%");
			}
			if(this.data != null)
			{
				result = result.WhereLike("cq_itemex_bak.data","%" + this.data.ToString() + "%");
			}
			if(this.plunder != null)
			{
				result = result.WhereLike("cq_itemex_bak.plunder","%" + this.plunder.ToString() + "%");
			}
			if(this.sale_time != null)
			{
				result = result.WhereLike("cq_itemex_bak.sale_time","%" + this.sale_time.ToString() + "%");
			}
			if(this.max_hp != null)
			{
				result = result.WhereLike("cq_itemex_bak.max_hp","%" + this.max_hp.ToString() + "%");
			}
			if(this.weight != null)
			{
				result = result.WhereLike("cq_itemex_bak.weight","%" + this.weight.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_itemex_bak.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_itemex_bak.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_itemex_bak.data3","%" + this.data3.ToString() + "%");
			}
			if(this.data4 != null)
			{
				result = result.WhereLike("cq_itemex_bak.data4","%" + this.data4.ToString() + "%");
			}
			if(this.shape != null)
			{
				result = result.WhereLike("cq_itemex_bak.shape","%" + this.shape.ToString() + "%");
			}
			if(this.addlevel != null)
			{
				result = result.WhereLike("cq_itemex_bak.addlevel","%" + this.addlevel.ToString() + "%");
			}
			if(this.hot_atk != null)
			{
				result = result.WhereLike("cq_itemex_bak.hot_atk","%" + this.hot_atk.ToString() + "%");
			}
			if(this.shake_atk != null)
			{
				result = result.WhereLike("cq_itemex_bak.shake_atk","%" + this.shake_atk.ToString() + "%");
			}
			if(this.sting_atk != null)
			{
				result = result.WhereLike("cq_itemex_bak.sting_atk","%" + this.sting_atk.ToString() + "%");
			}
			if(this.decay_atk != null)
			{
				result = result.WhereLike("cq_itemex_bak.decay_atk","%" + this.decay_atk.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_itemex_bak.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.Forgename != null)
			{
				result = result.WhereLike("cq_itemex_bak.Forgename","%" + this.Forgename.ToString() + "%");
			}
			if(this.specialflag != null)
			{
				result = result.WhereLike("cq_itemex_bak.specialflag","%" + this.specialflag.ToString() + "%");
			}
			if(this.data5 != null)
			{
				result = result.WhereLike("cq_itemex_bak.data5","%" + this.data5.ToString() + "%");
			}
			if(this.data6 != null)
			{
				result = result.WhereLike("cq_itemex_bak.data6","%" + this.data6.ToString() + "%");
			}
			if(this.weight3 != null)
			{
				result = result.WhereLike("cq_itemex_bak.weight3","%" + this.weight3.ToString() + "%");
			}
			if(this.weight4 != null)
			{
				result = result.WhereLike("cq_itemex_bak.weight4","%" + this.weight4.ToString() + "%");
			}
			if(this.Exp != null)
			{
				result = result.WhereLike("cq_itemex_bak.Exp","%" + this.Exp.ToString() + "%");
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