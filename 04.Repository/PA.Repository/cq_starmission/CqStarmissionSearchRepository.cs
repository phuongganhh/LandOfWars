using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqStarmissionSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? missionlv0 { get; set; }
		public int? missionlv1 { get; set; }
		public int? missionlv2 { get; set; }
		public int? bonus_map { get; set; }
		public int? cellx { get; set; }
		public int? celly { get; set; }
		public int? base_time { get; set; }
		public int? first_time_bonus { get; set; }
		public int? first_prize0 { get; set; }
		public int? first_prize1 { get; set; }
		public int? battlelev { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_starmission")
				.Select(
					"cq_starmission.id",
					"cq_starmission.name",
					"cq_starmission.missionlv0",
					"cq_starmission.missionlv1",
					"cq_starmission.missionlv2",
					"cq_starmission.bonus_map",
					"cq_starmission.cellx",
					"cq_starmission.celly",
					"cq_starmission.base_time",
					"cq_starmission.first_time_bonus",
					"cq_starmission.first_prize0",
					"cq_starmission.first_prize1",
					"cq_starmission.battlelev"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_starmission")
                        .Select("cq_starmission.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_starmission.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_starmission.name","%" + this.name.ToString() + "%");
			}
			if(this.missionlv0 != null)
			{
				result = result.WhereLike("cq_starmission.missionlv0","%" + this.missionlv0.ToString() + "%");
			}
			if(this.missionlv1 != null)
			{
				result = result.WhereLike("cq_starmission.missionlv1","%" + this.missionlv1.ToString() + "%");
			}
			if(this.missionlv2 != null)
			{
				result = result.WhereLike("cq_starmission.missionlv2","%" + this.missionlv2.ToString() + "%");
			}
			if(this.bonus_map != null)
			{
				result = result.WhereLike("cq_starmission.bonus_map","%" + this.bonus_map.ToString() + "%");
			}
			if(this.cellx != null)
			{
				result = result.WhereLike("cq_starmission.cellx","%" + this.cellx.ToString() + "%");
			}
			if(this.celly != null)
			{
				result = result.WhereLike("cq_starmission.celly","%" + this.celly.ToString() + "%");
			}
			if(this.base_time != null)
			{
				result = result.WhereLike("cq_starmission.base_time","%" + this.base_time.ToString() + "%");
			}
			if(this.first_time_bonus != null)
			{
				result = result.WhereLike("cq_starmission.first_time_bonus","%" + this.first_time_bonus.ToString() + "%");
			}
			if(this.first_prize0 != null)
			{
				result = result.WhereLike("cq_starmission.first_prize0","%" + this.first_prize0.ToString() + "%");
			}
			if(this.first_prize1 != null)
			{
				result = result.WhereLike("cq_starmission.first_prize1","%" + this.first_prize1.ToString() + "%");
			}
			if(this.battlelev != null)
			{
				result = result.WhereLike("cq_starmission.battlelev","%" + this.battlelev.ToString() + "%");
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