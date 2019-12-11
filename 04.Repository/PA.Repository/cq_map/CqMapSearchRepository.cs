using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMapSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public string describe_text { get; set; }
		public int? mapdoc { get; set; }
		public long? type { get; set; }
		public int? owner_id { get; set; }
		public int? mapgroup { get; set; }
		public int? idxserver { get; set; }
		public int? weather { get; set; }
		public int? bgmusic { get; set; }
		public int? bgmusic_show { get; set; }
		public int? portal0_x { get; set; }
		public int? portal0_y { get; set; }
		public int? reborn_mapid { get; set; }
		public int? reborn_portal { get; set; }
		public int? res_lev { get; set; }
		public int? owner_type { get; set; }
		public int? link_map { get; set; }
		public int? link_x { get; set; }
		public int? link_y { get; set; }
		public int? del_flag { get; set; }
		public int? req_maxlv { get; set; }
		public int? req_minlv { get; set; }
		public int? room1 { get; set; }
		public int? room2 { get; set; }
		public int? room3 { get; set; }
		public int? room4 { get; set; }
		public int? room5 { get; set; }
		public int? room6 { get; set; }
		public int? Province_id { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_map")
				.Select(
					"cq_map.id",
					"cq_map.name",
					"cq_map.describe_text",
					"cq_map.mapdoc",
					"cq_map.type",
					"cq_map.owner_id",
					"cq_map.mapgroup",
					"cq_map.idxserver",
					"cq_map.weather",
					"cq_map.bgmusic",
					"cq_map.bgmusic_show",
					"cq_map.portal0_x",
					"cq_map.portal0_y",
					"cq_map.reborn_mapid",
					"cq_map.reborn_portal",
					"cq_map.res_lev",
					"cq_map.owner_type",
					"cq_map.link_map",
					"cq_map.link_x",
					"cq_map.link_y",
					"cq_map.del_flag",
					"cq_map.req_maxlv",
					"cq_map.req_minlv",
					"cq_map.room1",
					"cq_map.room2",
					"cq_map.room3",
					"cq_map.room4",
					"cq_map.room5",
					"cq_map.room6",
					"cq_map.Province_id"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_map")
                        .Select("cq_map.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_map.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_map.name","%" + this.name.ToString() + "%");
			}
			if(this.describe_text != null)
			{
				result = result.WhereLike("cq_map.describe_text","%" + this.describe_text.ToString() + "%");
			}
			if(this.mapdoc != null)
			{
				result = result.WhereLike("cq_map.mapdoc","%" + this.mapdoc.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_map.type","%" + this.type.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_map.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.mapgroup != null)
			{
				result = result.WhereLike("cq_map.mapgroup","%" + this.mapgroup.ToString() + "%");
			}
			if(this.idxserver != null)
			{
				result = result.WhereLike("cq_map.idxserver","%" + this.idxserver.ToString() + "%");
			}
			if(this.weather != null)
			{
				result = result.WhereLike("cq_map.weather","%" + this.weather.ToString() + "%");
			}
			if(this.bgmusic != null)
			{
				result = result.WhereLike("cq_map.bgmusic","%" + this.bgmusic.ToString() + "%");
			}
			if(this.bgmusic_show != null)
			{
				result = result.WhereLike("cq_map.bgmusic_show","%" + this.bgmusic_show.ToString() + "%");
			}
			if(this.portal0_x != null)
			{
				result = result.WhereLike("cq_map.portal0_x","%" + this.portal0_x.ToString() + "%");
			}
			if(this.portal0_y != null)
			{
				result = result.WhereLike("cq_map.portal0_y","%" + this.portal0_y.ToString() + "%");
			}
			if(this.reborn_mapid != null)
			{
				result = result.WhereLike("cq_map.reborn_mapid","%" + this.reborn_mapid.ToString() + "%");
			}
			if(this.reborn_portal != null)
			{
				result = result.WhereLike("cq_map.reborn_portal","%" + this.reborn_portal.ToString() + "%");
			}
			if(this.res_lev != null)
			{
				result = result.WhereLike("cq_map.res_lev","%" + this.res_lev.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_map.owner_type","%" + this.owner_type.ToString() + "%");
			}
			if(this.link_map != null)
			{
				result = result.WhereLike("cq_map.link_map","%" + this.link_map.ToString() + "%");
			}
			if(this.link_x != null)
			{
				result = result.WhereLike("cq_map.link_x","%" + this.link_x.ToString() + "%");
			}
			if(this.link_y != null)
			{
				result = result.WhereLike("cq_map.link_y","%" + this.link_y.ToString() + "%");
			}
			if(this.del_flag != null)
			{
				result = result.WhereLike("cq_map.del_flag","%" + this.del_flag.ToString() + "%");
			}
			if(this.req_maxlv != null)
			{
				result = result.WhereLike("cq_map.req_maxlv","%" + this.req_maxlv.ToString() + "%");
			}
			if(this.req_minlv != null)
			{
				result = result.WhereLike("cq_map.req_minlv","%" + this.req_minlv.ToString() + "%");
			}
			if(this.room1 != null)
			{
				result = result.WhereLike("cq_map.room1","%" + this.room1.ToString() + "%");
			}
			if(this.room2 != null)
			{
				result = result.WhereLike("cq_map.room2","%" + this.room2.ToString() + "%");
			}
			if(this.room3 != null)
			{
				result = result.WhereLike("cq_map.room3","%" + this.room3.ToString() + "%");
			}
			if(this.room4 != null)
			{
				result = result.WhereLike("cq_map.room4","%" + this.room4.ToString() + "%");
			}
			if(this.room5 != null)
			{
				result = result.WhereLike("cq_map.room5","%" + this.room5.ToString() + "%");
			}
			if(this.room6 != null)
			{
				result = result.WhereLike("cq_map.room6","%" + this.room6.ToString() + "%");
			}
			if(this.Province_id != null)
			{
				result = result.WhereLike("cq_map.Province_id","%" + this.Province_id.ToString() + "%");
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