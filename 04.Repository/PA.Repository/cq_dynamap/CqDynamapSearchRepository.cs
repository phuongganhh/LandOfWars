using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDynamapSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public string describe_text { get; set; }
		public int? mapdoc { get; set; }
		public int? type { get; set; }
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


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_dynamap")
				.Select(
					"cq_dynamap.id",
					"cq_dynamap.name",
					"cq_dynamap.describe_text",
					"cq_dynamap.mapdoc",
					"cq_dynamap.type",
					"cq_dynamap.owner_id",
					"cq_dynamap.mapgroup",
					"cq_dynamap.idxserver",
					"cq_dynamap.weather",
					"cq_dynamap.bgmusic",
					"cq_dynamap.bgmusic_show",
					"cq_dynamap.portal0_x",
					"cq_dynamap.portal0_y",
					"cq_dynamap.reborn_mapid",
					"cq_dynamap.reborn_portal",
					"cq_dynamap.res_lev",
					"cq_dynamap.owner_type",
					"cq_dynamap.link_map",
					"cq_dynamap.link_x",
					"cq_dynamap.link_y",
					"cq_dynamap.del_flag",
					"cq_dynamap.req_maxlv",
					"cq_dynamap.req_minlv",
					"cq_dynamap.room1",
					"cq_dynamap.room2",
					"cq_dynamap.room3",
					"cq_dynamap.room4",
					"cq_dynamap.room5",
					"cq_dynamap.room6"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_dynamap")
                        .Select("cq_dynamap.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_dynamap.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_dynamap.name","%" + this.name.ToString() + "%");
			}
			if(this.describe_text != null)
			{
				result = result.WhereLike("cq_dynamap.describe_text","%" + this.describe_text.ToString() + "%");
			}
			if(this.mapdoc != null)
			{
				result = result.WhereLike("cq_dynamap.mapdoc","%" + this.mapdoc.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_dynamap.type","%" + this.type.ToString() + "%");
			}
			if(this.owner_id != null)
			{
				result = result.WhereLike("cq_dynamap.owner_id","%" + this.owner_id.ToString() + "%");
			}
			if(this.mapgroup != null)
			{
				result = result.WhereLike("cq_dynamap.mapgroup","%" + this.mapgroup.ToString() + "%");
			}
			if(this.idxserver != null)
			{
				result = result.WhereLike("cq_dynamap.idxserver","%" + this.idxserver.ToString() + "%");
			}
			if(this.weather != null)
			{
				result = result.WhereLike("cq_dynamap.weather","%" + this.weather.ToString() + "%");
			}
			if(this.bgmusic != null)
			{
				result = result.WhereLike("cq_dynamap.bgmusic","%" + this.bgmusic.ToString() + "%");
			}
			if(this.bgmusic_show != null)
			{
				result = result.WhereLike("cq_dynamap.bgmusic_show","%" + this.bgmusic_show.ToString() + "%");
			}
			if(this.portal0_x != null)
			{
				result = result.WhereLike("cq_dynamap.portal0_x","%" + this.portal0_x.ToString() + "%");
			}
			if(this.portal0_y != null)
			{
				result = result.WhereLike("cq_dynamap.portal0_y","%" + this.portal0_y.ToString() + "%");
			}
			if(this.reborn_mapid != null)
			{
				result = result.WhereLike("cq_dynamap.reborn_mapid","%" + this.reborn_mapid.ToString() + "%");
			}
			if(this.reborn_portal != null)
			{
				result = result.WhereLike("cq_dynamap.reborn_portal","%" + this.reborn_portal.ToString() + "%");
			}
			if(this.res_lev != null)
			{
				result = result.WhereLike("cq_dynamap.res_lev","%" + this.res_lev.ToString() + "%");
			}
			if(this.owner_type != null)
			{
				result = result.WhereLike("cq_dynamap.owner_type","%" + this.owner_type.ToString() + "%");
			}
			if(this.link_map != null)
			{
				result = result.WhereLike("cq_dynamap.link_map","%" + this.link_map.ToString() + "%");
			}
			if(this.link_x != null)
			{
				result = result.WhereLike("cq_dynamap.link_x","%" + this.link_x.ToString() + "%");
			}
			if(this.link_y != null)
			{
				result = result.WhereLike("cq_dynamap.link_y","%" + this.link_y.ToString() + "%");
			}
			if(this.del_flag != null)
			{
				result = result.WhereLike("cq_dynamap.del_flag","%" + this.del_flag.ToString() + "%");
			}
			if(this.req_maxlv != null)
			{
				result = result.WhereLike("cq_dynamap.req_maxlv","%" + this.req_maxlv.ToString() + "%");
			}
			if(this.req_minlv != null)
			{
				result = result.WhereLike("cq_dynamap.req_minlv","%" + this.req_minlv.ToString() + "%");
			}
			if(this.room1 != null)
			{
				result = result.WhereLike("cq_dynamap.room1","%" + this.room1.ToString() + "%");
			}
			if(this.room2 != null)
			{
				result = result.WhereLike("cq_dynamap.room2","%" + this.room2.ToString() + "%");
			}
			if(this.room3 != null)
			{
				result = result.WhereLike("cq_dynamap.room3","%" + this.room3.ToString() + "%");
			}
			if(this.room4 != null)
			{
				result = result.WhereLike("cq_dynamap.room4","%" + this.room4.ToString() + "%");
			}
			if(this.room5 != null)
			{
				result = result.WhereLike("cq_dynamap.room5","%" + this.room5.ToString() + "%");
			}
			if(this.room6 != null)
			{
				result = result.WhereLike("cq_dynamap.room6","%" + this.room6.ToString() + "%");
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