using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqGeneratorSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? mapid { get; set; }
		public int? bound_x { get; set; }
		public int? bound_y { get; set; }
		public int? bound_cx { get; set; }
		public int? bound_cy { get; set; }
		public int? grid { get; set; }
		public int? rest_secs { get; set; }
		public int? max_per_gen { get; set; }
		public int? npctype { get; set; }
		public int? timer_begin { get; set; }
		public int? timer_end { get; set; }
		public int? born_x { get; set; }
		public int? born_y { get; set; }
		public int? pathset_id { get; set; }
		public int? path_returnmode { get; set; }
		public int? deadtoborn { get; set; }
		public int? patrol_secs { get; set; }
		public int? dir { get; set; }
		public int? shipmission_delay { get; set; }
		public int? control_mask { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_generator")
				.Select(
					"cq_generator.id",
					"cq_generator.mapid",
					"cq_generator.bound_x",
					"cq_generator.bound_y",
					"cq_generator.bound_cx",
					"cq_generator.bound_cy",
					"cq_generator.grid",
					"cq_generator.rest_secs",
					"cq_generator.max_per_gen",
					"cq_generator.npctype",
					"cq_generator.timer_begin",
					"cq_generator.timer_end",
					"cq_generator.born_x",
					"cq_generator.born_y",
					"cq_generator.pathset_id",
					"cq_generator.path_returnmode",
					"cq_generator.deadtoborn",
					"cq_generator.patrol_secs",
					"cq_generator.dir",
					"cq_generator.shipmission_delay",
					"cq_generator.control_mask"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_generator")
                        .Select("cq_generator.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_generator.id","%" + this.id.ToString() + "%");
			}
			if(this.mapid != null)
			{
				result = result.WhereLike("cq_generator.mapid","%" + this.mapid.ToString() + "%");
			}
			if(this.bound_x != null)
			{
				result = result.WhereLike("cq_generator.bound_x","%" + this.bound_x.ToString() + "%");
			}
			if(this.bound_y != null)
			{
				result = result.WhereLike("cq_generator.bound_y","%" + this.bound_y.ToString() + "%");
			}
			if(this.bound_cx != null)
			{
				result = result.WhereLike("cq_generator.bound_cx","%" + this.bound_cx.ToString() + "%");
			}
			if(this.bound_cy != null)
			{
				result = result.WhereLike("cq_generator.bound_cy","%" + this.bound_cy.ToString() + "%");
			}
			if(this.grid != null)
			{
				result = result.WhereLike("cq_generator.grid","%" + this.grid.ToString() + "%");
			}
			if(this.rest_secs != null)
			{
				result = result.WhereLike("cq_generator.rest_secs","%" + this.rest_secs.ToString() + "%");
			}
			if(this.max_per_gen != null)
			{
				result = result.WhereLike("cq_generator.max_per_gen","%" + this.max_per_gen.ToString() + "%");
			}
			if(this.npctype != null)
			{
				result = result.WhereLike("cq_generator.npctype","%" + this.npctype.ToString() + "%");
			}
			if(this.timer_begin != null)
			{
				result = result.WhereLike("cq_generator.timer_begin","%" + this.timer_begin.ToString() + "%");
			}
			if(this.timer_end != null)
			{
				result = result.WhereLike("cq_generator.timer_end","%" + this.timer_end.ToString() + "%");
			}
			if(this.born_x != null)
			{
				result = result.WhereLike("cq_generator.born_x","%" + this.born_x.ToString() + "%");
			}
			if(this.born_y != null)
			{
				result = result.WhereLike("cq_generator.born_y","%" + this.born_y.ToString() + "%");
			}
			if(this.pathset_id != null)
			{
				result = result.WhereLike("cq_generator.pathset_id","%" + this.pathset_id.ToString() + "%");
			}
			if(this.path_returnmode != null)
			{
				result = result.WhereLike("cq_generator.path_returnmode","%" + this.path_returnmode.ToString() + "%");
			}
			if(this.deadtoborn != null)
			{
				result = result.WhereLike("cq_generator.deadtoborn","%" + this.deadtoborn.ToString() + "%");
			}
			if(this.patrol_secs != null)
			{
				result = result.WhereLike("cq_generator.patrol_secs","%" + this.patrol_secs.ToString() + "%");
			}
			if(this.dir != null)
			{
				result = result.WhereLike("cq_generator.dir","%" + this.dir.ToString() + "%");
			}
			if(this.shipmission_delay != null)
			{
				result = result.WhereLike("cq_generator.shipmission_delay","%" + this.shipmission_delay.ToString() + "%");
			}
			if(this.control_mask != null)
			{
				result = result.WhereLike("cq_generator.control_mask","%" + this.control_mask.ToString() + "%");
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