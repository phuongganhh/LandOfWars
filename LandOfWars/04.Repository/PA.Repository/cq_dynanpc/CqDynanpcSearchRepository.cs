using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDynanpcSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? ownerid { get; set; }
		public int? ownertype { get; set; }
		public string name { get; set; }
		public int? type { get; set; }
		public int? lookface { get; set; }
		public int? idxserver { get; set; }
		public int? mapid { get; set; }
		public int? cellx { get; set; }
		public int? celly { get; set; }
		public int? task0 { get; set; }
		public int? task1 { get; set; }
		public int? task2 { get; set; }
		public int? task3 { get; set; }
		public int? task4 { get; set; }
		public int? task5 { get; set; }
		public int? task6 { get; set; }
		public int? task7 { get; set; }
		public int? data0 { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? data3 { get; set; }
		public string datastr { get; set; }
		public int? linkid { get; set; }
		public int? life { get; set; }
		public int? maxlife { get; set; }
		public int? sort { get; set; }
		public int? itemid { get; set; }
		public int? def_adj { get; set; }
		public int? def_sub { get; set; }
		public int? def_hot { get; set; }
		public int? def_shake { get; set; }
		public int? def_sting { get; set; }
		public int? def_decay { get; set; }
		public string owner_name { get; set; }
		public string default_owner_name { get; set; }
		public int? initial_price { get; set; }
		public long? price { get; set; }
		public long? deposit { get; set; }
		public int? buy_ratio { get; set; }
		public int? fee_type { get; set; }
		public int? income_value { get; set; }
		public int? preferential { get; set; }
		public int? annex { get; set; }
		public int? attribute_type { get; set; }
		public int? User_atk_adjust { get; set; }
		public int? user_atk_mode { get; set; }
		public int? harvest_date { get; set; }
		public int? number { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_dynanpc")
				.Select(
					"cq_dynanpc.id",
					"cq_dynanpc.ownerid",
					"cq_dynanpc.ownertype",
					"cq_dynanpc.name",
					"cq_dynanpc.type",
					"cq_dynanpc.lookface",
					"cq_dynanpc.idxserver",
					"cq_dynanpc.mapid",
					"cq_dynanpc.cellx",
					"cq_dynanpc.celly",
					"cq_dynanpc.task0",
					"cq_dynanpc.task1",
					"cq_dynanpc.task2",
					"cq_dynanpc.task3",
					"cq_dynanpc.task4",
					"cq_dynanpc.task5",
					"cq_dynanpc.task6",
					"cq_dynanpc.task7",
					"cq_dynanpc.data0",
					"cq_dynanpc.data1",
					"cq_dynanpc.data2",
					"cq_dynanpc.data3",
					"cq_dynanpc.datastr",
					"cq_dynanpc.linkid",
					"cq_dynanpc.life",
					"cq_dynanpc.maxlife",
					"cq_dynanpc.sort",
					"cq_dynanpc.itemid",
					"cq_dynanpc.def_adj",
					"cq_dynanpc.def_sub",
					"cq_dynanpc.def_hot",
					"cq_dynanpc.def_shake",
					"cq_dynanpc.def_sting",
					"cq_dynanpc.def_decay",
					"cq_dynanpc.owner_name",
					"cq_dynanpc.default_owner_name",
					"cq_dynanpc.initial_price",
					"cq_dynanpc.price",
					"cq_dynanpc.deposit",
					"cq_dynanpc.buy_ratio",
					"cq_dynanpc.fee_type",
					"cq_dynanpc.income_value",
					"cq_dynanpc.preferential",
					"cq_dynanpc.annex",
					"cq_dynanpc.attribute_type",
					"cq_dynanpc.User_atk_adjust",
					"cq_dynanpc.user_atk_mode",
					"cq_dynanpc.harvest_date",
					"cq_dynanpc.number"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_dynanpc")
                        .Select("cq_dynanpc.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_dynanpc.id","%" + this.id.ToString() + "%");
			}
			if(this.ownerid != null)
			{
				result = result.WhereLike("cq_dynanpc.ownerid","%" + this.ownerid.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_dynanpc.ownertype","%" + this.ownertype.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_dynanpc.name","%" + this.name.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_dynanpc.type","%" + this.type.ToString() + "%");
			}
			if(this.lookface != null)
			{
				result = result.WhereLike("cq_dynanpc.lookface","%" + this.lookface.ToString() + "%");
			}
			if(this.idxserver != null)
			{
				result = result.WhereLike("cq_dynanpc.idxserver","%" + this.idxserver.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_dynanpc.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.cellx != null)
			{
				result = result.WhereLike("cq_dynanpc.cellx","%" + this.cellx.ToString() + "%");
			}
			if(this.celly != null)
			{
				result = result.WhereLike("cq_dynanpc.celly","%" + this.celly.ToString() + "%");
			}
			if(this.task0 != null)
			{
				result = result.WhereLike("cq_dynanpc.task0","%" + this.task0.ToString() + "%");
			}
			if(this.task1 != null)
			{
				result = result.WhereLike("cq_dynanpc.task1","%" + this.task1.ToString() + "%");
			}
			if(this.task2 != null)
			{
				result = result.WhereLike("cq_dynanpc.task2","%" + this.task2.ToString() + "%");
			}
			if(this.task3 != null)
			{
				result = result.WhereLike("cq_dynanpc.task3","%" + this.task3.ToString() + "%");
			}
			if(this.task4 != null)
			{
				result = result.WhereLike("cq_dynanpc.task4","%" + this.task4.ToString() + "%");
			}
			if(this.task5 != null)
			{
				result = result.WhereLike("cq_dynanpc.task5","%" + this.task5.ToString() + "%");
			}
			if(this.task6 != null)
			{
				result = result.WhereLike("cq_dynanpc.task6","%" + this.task6.ToString() + "%");
			}
			if(this.task7 != null)
			{
				result = result.WhereLike("cq_dynanpc.task7","%" + this.task7.ToString() + "%");
			}
			if(this.data0 != null)
			{
				result = result.WhereLike("cq_dynanpc.data0","%" + this.data0.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_dynanpc.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_dynanpc.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_dynanpc.data3","%" + this.data3.ToString() + "%");
			}
			if(this.datastr != null)
			{
				result = result.WhereLike("cq_dynanpc.datastr","%" + this.datastr.ToString() + "%");
			}
			if(this.linkid != null)
			{
				result = result.WhereLike("cq_dynanpc.linkid","%" + this.linkid.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_dynanpc.life","%" + this.life.ToString() + "%");
			}
			if(this.maxlife != null)
			{
				result = result.WhereLike("cq_dynanpc.maxlife","%" + this.maxlife.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_dynanpc.sort","%" + this.sort.ToString() + "%");
			}
			if(this.itemid != null)
			{
				result = result.WhereLike("cq_dynanpc.itemid","%" + this.itemid.ToString() + "%");
			}
			if(this.def_adj != null)
			{
				result = result.WhereLike("cq_dynanpc.def_adj","%" + this.def_adj.ToString() + "%");
			}
			if(this.def_sub != null)
			{
				result = result.WhereLike("cq_dynanpc.def_sub","%" + this.def_sub.ToString() + "%");
			}
			if(this.def_hot != null)
			{
				result = result.WhereLike("cq_dynanpc.def_hot","%" + this.def_hot.ToString() + "%");
			}
			if(this.def_shake != null)
			{
				result = result.WhereLike("cq_dynanpc.def_shake","%" + this.def_shake.ToString() + "%");
			}
			if(this.def_sting != null)
			{
				result = result.WhereLike("cq_dynanpc.def_sting","%" + this.def_sting.ToString() + "%");
			}
			if(this.def_decay != null)
			{
				result = result.WhereLike("cq_dynanpc.def_decay","%" + this.def_decay.ToString() + "%");
			}
			if(this.owner_name != null)
			{
				result = result.WhereLike("cq_dynanpc.owner_name","%" + this.owner_name.ToString() + "%");
			}
			if(this.default_owner_name != null)
			{
				result = result.WhereLike("cq_dynanpc.default_owner_name","%" + this.default_owner_name.ToString() + "%");
			}
			if(this.initial_price != null)
			{
				result = result.WhereLike("cq_dynanpc.initial_price","%" + this.initial_price.ToString() + "%");
			}
			if(this.price != null)
			{
				result = result.WhereLike("cq_dynanpc.price","%" + this.price.ToString() + "%");
			}
			if(this.deposit != null)
			{
				result = result.WhereLike("cq_dynanpc.deposit","%" + this.deposit.ToString() + "%");
			}
			if(this.buy_ratio != null)
			{
				result = result.WhereLike("cq_dynanpc.buy_ratio","%" + this.buy_ratio.ToString() + "%");
			}
			if(this.fee_type != null)
			{
				result = result.WhereLike("cq_dynanpc.fee_type","%" + this.fee_type.ToString() + "%");
			}
			if(this.income_value != null)
			{
				result = result.WhereLike("cq_dynanpc.income_value","%" + this.income_value.ToString() + "%");
			}
			if(this.preferential != null)
			{
				result = result.WhereLike("cq_dynanpc.preferential","%" + this.preferential.ToString() + "%");
			}
			if(this.annex != null)
			{
				result = result.WhereLike("cq_dynanpc.annex","%" + this.annex.ToString() + "%");
			}
			if(this.attribute_type != null)
			{
				result = result.WhereLike("cq_dynanpc.attribute_type","%" + this.attribute_type.ToString() + "%");
			}
			if(this.User_atk_adjust != null)
			{
				result = result.WhereLike("cq_dynanpc.User_atk_adjust","%" + this.User_atk_adjust.ToString() + "%");
			}
			if(this.user_atk_mode != null)
			{
				result = result.WhereLike("cq_dynanpc.user_atk_mode","%" + this.user_atk_mode.ToString() + "%");
			}
			if(this.harvest_date != null)
			{
				result = result.WhereLike("cq_dynanpc.harvest_date","%" + this.harvest_date.ToString() + "%");
			}
			if(this.number != null)
			{
				result = result.WhereLike("cq_dynanpc.number","%" + this.number.ToString() + "%");
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