using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqNpcSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
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


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_npc")
				.Select(
					"cq_npc.id",
					"cq_npc.ownerid",
					"cq_npc.ownertype",
					"cq_npc.name",
					"cq_npc.type",
					"cq_npc.lookface",
					"cq_npc.idxserver",
					"cq_npc.mapid",
					"cq_npc.cellx",
					"cq_npc.celly",
					"cq_npc.task0",
					"cq_npc.task1",
					"cq_npc.task2",
					"cq_npc.task3",
					"cq_npc.task4",
					"cq_npc.task5",
					"cq_npc.task6",
					"cq_npc.task7",
					"cq_npc.data0",
					"cq_npc.data1",
					"cq_npc.data2",
					"cq_npc.data3",
					"cq_npc.datastr",
					"cq_npc.linkid",
					"cq_npc.life",
					"cq_npc.maxlife",
					"cq_npc.sort",
					"cq_npc.itemid",
					"cq_npc.def_adj",
					"cq_npc.def_sub",
					"cq_npc.def_hot",
					"cq_npc.def_shake",
					"cq_npc.def_sting",
					"cq_npc.def_decay",
					"cq_npc.owner_name",
					"cq_npc.default_owner_name",
					"cq_npc.initial_price",
					"cq_npc.price",
					"cq_npc.deposit",
					"cq_npc.buy_ratio",
					"cq_npc.fee_type",
					"cq_npc.income_value",
					"cq_npc.preferential",
					"cq_npc.annex",
					"cq_npc.attribute_type",
					"cq_npc.User_atk_adjust",
					"cq_npc.user_atk_mode",
					"cq_npc.harvest_date"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_npc")
                        .Select("cq_npc.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_npc.id","%" + this.id.ToString() + "%");
			}
			if(this.ownerid != null)
			{
				result = result.WhereLike("cq_npc.ownerid","%" + this.ownerid.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_npc.ownertype","%" + this.ownertype.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_npc.name","%" + this.name.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_npc.type","%" + this.type.ToString() + "%");
			}
			if(this.lookface != null)
			{
				result = result.WhereLike("cq_npc.lookface","%" + this.lookface.ToString() + "%");
			}
			if(this.idxserver != null)
			{
				result = result.WhereLike("cq_npc.idxserver","%" + this.idxserver.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_npc.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.cellx != null)
			{
				result = result.WhereLike("cq_npc.cellx","%" + this.cellx.ToString() + "%");
			}
			if(this.celly != null)
			{
				result = result.WhereLike("cq_npc.celly","%" + this.celly.ToString() + "%");
			}
			if(this.task0 != null)
			{
				result = result.WhereLike("cq_npc.task0","%" + this.task0.ToString() + "%");
			}
			if(this.task1 != null)
			{
				result = result.WhereLike("cq_npc.task1","%" + this.task1.ToString() + "%");
			}
			if(this.task2 != null)
			{
				result = result.WhereLike("cq_npc.task2","%" + this.task2.ToString() + "%");
			}
			if(this.task3 != null)
			{
				result = result.WhereLike("cq_npc.task3","%" + this.task3.ToString() + "%");
			}
			if(this.task4 != null)
			{
				result = result.WhereLike("cq_npc.task4","%" + this.task4.ToString() + "%");
			}
			if(this.task5 != null)
			{
				result = result.WhereLike("cq_npc.task5","%" + this.task5.ToString() + "%");
			}
			if(this.task6 != null)
			{
				result = result.WhereLike("cq_npc.task6","%" + this.task6.ToString() + "%");
			}
			if(this.task7 != null)
			{
				result = result.WhereLike("cq_npc.task7","%" + this.task7.ToString() + "%");
			}
			if(this.data0 != null)
			{
				result = result.WhereLike("cq_npc.data0","%" + this.data0.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_npc.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_npc.data2","%" + this.data2.ToString() + "%");
			}
			if(this.data3 != null)
			{
				result = result.WhereLike("cq_npc.data3","%" + this.data3.ToString() + "%");
			}
			if(this.datastr != null)
			{
				result = result.WhereLike("cq_npc.datastr","%" + this.datastr.ToString() + "%");
			}
			if(this.linkid != null)
			{
				result = result.WhereLike("cq_npc.linkid","%" + this.linkid.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_npc.life","%" + this.life.ToString() + "%");
			}
			if(this.maxlife != null)
			{
				result = result.WhereLike("cq_npc.maxlife","%" + this.maxlife.ToString() + "%");
			}
			if(this.sort != null)
			{
				result = result.WhereLike("cq_npc.sort","%" + this.sort.ToString() + "%");
			}
			if(this.itemid != null)
			{
				result = result.WhereLike("cq_npc.itemid","%" + this.itemid.ToString() + "%");
			}
			if(this.def_adj != null)
			{
				result = result.WhereLike("cq_npc.def_adj","%" + this.def_adj.ToString() + "%");
			}
			if(this.def_sub != null)
			{
				result = result.WhereLike("cq_npc.def_sub","%" + this.def_sub.ToString() + "%");
			}
			if(this.def_hot != null)
			{
				result = result.WhereLike("cq_npc.def_hot","%" + this.def_hot.ToString() + "%");
			}
			if(this.def_shake != null)
			{
				result = result.WhereLike("cq_npc.def_shake","%" + this.def_shake.ToString() + "%");
			}
			if(this.def_sting != null)
			{
				result = result.WhereLike("cq_npc.def_sting","%" + this.def_sting.ToString() + "%");
			}
			if(this.def_decay != null)
			{
				result = result.WhereLike("cq_npc.def_decay","%" + this.def_decay.ToString() + "%");
			}
			if(this.owner_name != null)
			{
				result = result.WhereLike("cq_npc.owner_name","%" + this.owner_name.ToString() + "%");
			}
			if(this.default_owner_name != null)
			{
				result = result.WhereLike("cq_npc.default_owner_name","%" + this.default_owner_name.ToString() + "%");
			}
			if(this.initial_price != null)
			{
				result = result.WhereLike("cq_npc.initial_price","%" + this.initial_price.ToString() + "%");
			}
			if(this.price != null)
			{
				result = result.WhereLike("cq_npc.price","%" + this.price.ToString() + "%");
			}
			if(this.deposit != null)
			{
				result = result.WhereLike("cq_npc.deposit","%" + this.deposit.ToString() + "%");
			}
			if(this.buy_ratio != null)
			{
				result = result.WhereLike("cq_npc.buy_ratio","%" + this.buy_ratio.ToString() + "%");
			}
			if(this.fee_type != null)
			{
				result = result.WhereLike("cq_npc.fee_type","%" + this.fee_type.ToString() + "%");
			}
			if(this.income_value != null)
			{
				result = result.WhereLike("cq_npc.income_value","%" + this.income_value.ToString() + "%");
			}
			if(this.preferential != null)
			{
				result = result.WhereLike("cq_npc.preferential","%" + this.preferential.ToString() + "%");
			}
			if(this.annex != null)
			{
				result = result.WhereLike("cq_npc.annex","%" + this.annex.ToString() + "%");
			}
			if(this.attribute_type != null)
			{
				result = result.WhereLike("cq_npc.attribute_type","%" + this.attribute_type.ToString() + "%");
			}
			if(this.User_atk_adjust != null)
			{
				result = result.WhereLike("cq_npc.User_atk_adjust","%" + this.User_atk_adjust.ToString() + "%");
			}
			if(this.user_atk_mode != null)
			{
				result = result.WhereLike("cq_npc.user_atk_mode","%" + this.user_atk_mode.ToString() + "%");
			}
			if(this.harvest_date != null)
			{
				result = result.WhereLike("cq_npc.harvest_date","%" + this.harvest_date.ToString() + "%");
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