using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqItemexSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
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
		public int? addlevel_exp { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_itemex")
				.Select(
					"cq_itemex.id",
					"cq_itemex.type",
					"cq_itemex.ownertype",
					"cq_itemex.owner_id",
					"cq_itemex.player_id",
					"cq_itemex.position",
					"cq_itemex.amount",
					"cq_itemex.ident",
					"cq_itemex.data",
					"cq_itemex.plunder",
					"cq_itemex.sale_time",
					"cq_itemex.max_hp",
					"cq_itemex.weight",
					"cq_itemex.data1",
					"cq_itemex.data2",
					"cq_itemex.data3",
					"cq_itemex.data4",
					"cq_itemex.shape",
					"cq_itemex.addlevel",
					"cq_itemex.hot_atk",
					"cq_itemex.shake_atk",
					"cq_itemex.sting_atk",
					"cq_itemex.decay_atk",
					"cq_itemex.chk_sum",
					"cq_itemex.Forgename",
					"cq_itemex.specialflag",
					"cq_itemex.data5",
					"cq_itemex.data6",
					"cq_itemex.weight3",
					"cq_itemex.weight4",
					"cq_itemex.Exp",
					"cq_itemex.addlevel_exp"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_itemex")
                        .Select("cq_itemex.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_itemex.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_itemex.type","%" + this.type.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_itemex.ownertype","%" + this.ownertype.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_itemex.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_itemex.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.position != null)
			{
				result = result.WhereLike("cq_itemex.position","%" + this.position.ToString() + "%");
			}
			if(this.amount != null)
			{
				result = result.WhereLike("cq_itemex.amount","%" + this.amount.ToString() + "%");
			}
			if(this.ident != null)
			{
				result = result.WhereLike("cq_itemex.ident","%" + this.ident.ToString() + "%");
			}
			if(this.data != null)
			{
				result = result.WhereLike("cq_itemex.data","%" + this.data.ToString() + "%");
			}
			if(this.plunder != null)
			{
				result = result.WhereLike("cq_itemex.plunder","%" + this.plunder.ToString() + "%");
			}
			if(this.sale_time != null)
			{
				result = result.WhereLike("cq_itemex.sale_time","%" + this.sale_time.ToString() + "%");
			}
			if(this.max_hp != null)
			{
				result = result.WhereLike("cq_itemex.max_hp","%" + this.max_hp.ToString() + "%");
			}
			if(this.weight != null)
			{
				result = result.WhereLike("cq_itemex.weight","%" + this.weight.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_itemex.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_itemex.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_itemex.data3","%" + this.data3.ToString() + "%");
			}
			if(this.data4 != null)
			{
				result = result.WhereLike("cq_itemex.data4","%" + this.data4.ToString() + "%");
			}
			if(this.shape != null)
			{
				result = result.WhereLike("cq_itemex.shape","%" + this.shape.ToString() + "%");
			}
			if(this.addlevel != null)
			{
				result = result.WhereLike("cq_itemex.addlevel","%" + this.addlevel.ToString() + "%");
			}
			if(this.hot_atk != null)
			{
				result = result.WhereLike("cq_itemex.hot_atk","%" + this.hot_atk.ToString() + "%");
			}
			if(this.shake_atk != null)
			{
				result = result.WhereLike("cq_itemex.shake_atk","%" + this.shake_atk.ToString() + "%");
			}
			if(this.sting_atk != null)
			{
				result = result.WhereLike("cq_itemex.sting_atk","%" + this.sting_atk.ToString() + "%");
			}
			if(this.decay_atk != null)
			{
				result = result.WhereLike("cq_itemex.decay_atk","%" + this.decay_atk.ToString() + "%");
			}
			if(this.chk_sum != null)
			{
				result = result.WhereLike("cq_itemex.chk_sum","%" + this.chk_sum.ToString() + "%");
			}
			if(this.Forgename != null)
			{
				result = result.WhereLike("cq_itemex.Forgename","%" + this.Forgename.ToString() + "%");
			}
			if(this.specialflag != null)
			{
				result = result.WhereLike("cq_itemex.specialflag","%" + this.specialflag.ToString() + "%");
			}
			if(this.data5 != null)
			{
				result = result.WhereLike("cq_itemex.data5","%" + this.data5.ToString() + "%");
			}
			if(this.data6 != null)
			{
				result = result.WhereLike("cq_itemex.data6","%" + this.data6.ToString() + "%");
			}
			if(this.weight3 != null)
			{
				result = result.WhereLike("cq_itemex.weight3","%" + this.weight3.ToString() + "%");
			}
			if(this.weight4 != null)
			{
				result = result.WhereLike("cq_itemex.weight4","%" + this.weight4.ToString() + "%");
			}
			if(this.Exp != null)
			{
				result = result.WhereLike("cq_itemex.Exp","%" + this.Exp.ToString() + "%");
			}
			if(this.addlevel_exp != null)
			{
				result = result.WhereLike("cq_itemex.addlevel_exp","%" + this.addlevel_exp.ToString() + "%");
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