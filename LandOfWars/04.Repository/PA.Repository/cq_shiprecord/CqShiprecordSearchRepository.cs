using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqShiprecordSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? mission { get; set; }
		public int? type { get; set; }
		public int? record { get; set; }
		public int? time { get; set; }
		public string player1 { get; set; }
		public string player2 { get; set; }
		public string player3 { get; set; }
		public string player4 { get; set; }
		public string player5 { get; set; }
		public string player6 { get; set; }
		public string player7 { get; set; }
		public string player8 { get; set; }
		public string player9 { get; set; }
		public string player10 { get; set; }
		public string player11 { get; set; }
		public string player12 { get; set; }
		public string player13 { get; set; }
		public string player14 { get; set; }
		public string player15 { get; set; }
		public string player16 { get; set; }
		public string player17 { get; set; }
		public string player18 { get; set; }
		public string player19 { get; set; }
		public string player20 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_shiprecord")
				.Select(
					"cq_shiprecord.id",
					"cq_shiprecord.mission",
					"cq_shiprecord.type",
					"cq_shiprecord.record",
					"cq_shiprecord.time",
					"cq_shiprecord.player1",
					"cq_shiprecord.player2",
					"cq_shiprecord.player3",
					"cq_shiprecord.player4",
					"cq_shiprecord.player5",
					"cq_shiprecord.player6",
					"cq_shiprecord.player7",
					"cq_shiprecord.player8",
					"cq_shiprecord.player9",
					"cq_shiprecord.player10",
					"cq_shiprecord.player11",
					"cq_shiprecord.player12",
					"cq_shiprecord.player13",
					"cq_shiprecord.player14",
					"cq_shiprecord.player15",
					"cq_shiprecord.player16",
					"cq_shiprecord.player17",
					"cq_shiprecord.player18",
					"cq_shiprecord.player19",
					"cq_shiprecord.player20"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_shiprecord")
                        .Select("cq_shiprecord.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_shiprecord.id","%" + this.id.ToString() + "%");
			}
			if(this.mission != null)
			{
				result = result.WhereLike("cq_shiprecord.mission","%" + this.mission.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_shiprecord.type","%" + this.type.ToString() + "%");
			}
			if(this.record != null)
			{
				result = result.WhereLike("cq_shiprecord.record","%" + this.record.ToString() + "%");
			}
			if(this.time != null)
			{
				result = result.WhereLike("cq_shiprecord.time","%" + this.time.ToString() + "%");
			}
			if(this.player1 != null)
			{
				result = result.WhereLike("cq_shiprecord.player1","%" + this.player1.ToString() + "%");
			}
			if(this.player2 != null)
			{
				result = result.WhereLike("cq_shiprecord.player2","%" + this.player2.ToString() + "%");
			}
			if(this.player3 != null)
			{
				result = result.WhereLike("cq_shiprecord.player3","%" + this.player3.ToString() + "%");
			}
			if(this.player4 != null)
			{
				result = result.WhereLike("cq_shiprecord.player4","%" + this.player4.ToString() + "%");
			}
			if(this.player5 != null)
			{
				result = result.WhereLike("cq_shiprecord.player5","%" + this.player5.ToString() + "%");
			}
			if(this.player6 != null)
			{
				result = result.WhereLike("cq_shiprecord.player6","%" + this.player6.ToString() + "%");
			}
			if(this.player7 != null)
			{
				result = result.WhereLike("cq_shiprecord.player7","%" + this.player7.ToString() + "%");
			}
			if(this.player8 != null)
			{
				result = result.WhereLike("cq_shiprecord.player8","%" + this.player8.ToString() + "%");
			}
			if(this.player9 != null)
			{
				result = result.WhereLike("cq_shiprecord.player9","%" + this.player9.ToString() + "%");
			}
			if(this.player10 != null)
			{
				result = result.WhereLike("cq_shiprecord.player10","%" + this.player10.ToString() + "%");
			}
			if(this.player11 != null)
			{
				result = result.WhereLike("cq_shiprecord.player11","%" + this.player11.ToString() + "%");
			}
			if(this.player12 != null)
			{
				result = result.WhereLike("cq_shiprecord.player12","%" + this.player12.ToString() + "%");
			}
			if(this.player13 != null)
			{
				result = result.WhereLike("cq_shiprecord.player13","%" + this.player13.ToString() + "%");
			}
			if(this.player14 != null)
			{
				result = result.WhereLike("cq_shiprecord.player14","%" + this.player14.ToString() + "%");
			}
			if(this.player15 != null)
			{
				result = result.WhereLike("cq_shiprecord.player15","%" + this.player15.ToString() + "%");
			}
			if(this.player16 != null)
			{
				result = result.WhereLike("cq_shiprecord.player16","%" + this.player16.ToString() + "%");
			}
			if(this.player17 != null)
			{
				result = result.WhereLike("cq_shiprecord.player17","%" + this.player17.ToString() + "%");
			}
			if(this.player18 != null)
			{
				result = result.WhereLike("cq_shiprecord.player18","%" + this.player18.ToString() + "%");
			}
			if(this.player19 != null)
			{
				result = result.WhereLike("cq_shiprecord.player19","%" + this.player19.ToString() + "%");
			}
			if(this.player20 != null)
			{
				result = result.WhereLike("cq_shiprecord.player20","%" + this.player20.ToString() + "%");
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