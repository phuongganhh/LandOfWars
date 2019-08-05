using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqCrystalGuiSetupSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? player_id { get; set; }
		public int? gui0 { get; set; }
		public int? gui1 { get; set; }
		public int? gui2 { get; set; }
		public int? gui3 { get; set; }
		public int? gui4 { get; set; }
		public int? gui5 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_crystal_gui_setup")
				.Select(
					"cq_crystal_gui_setup.player_id",
					"cq_crystal_gui_setup.gui0",
					"cq_crystal_gui_setup.gui1",
					"cq_crystal_gui_setup.gui2",
					"cq_crystal_gui_setup.gui3",
					"cq_crystal_gui_setup.gui4",
					"cq_crystal_gui_setup.gui5"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_crystal_gui_setup")
                        .Select("cq_crystal_gui_setup.player_id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.player_id != null)
			{
				result = result.WhereLike("cq_crystal_gui_setup.player_id","%" + this.player_id.ToString() + "%");
			}
			if(this.gui0 != null)
			{
				result = result.WhereLike("cq_crystal_gui_setup.gui0","%" + this.gui0.ToString() + "%");
			}
			if(this.gui1 != null)
			{
				result = result.WhereLike("cq_crystal_gui_setup.gui1","%" + this.gui1.ToString() + "%");
			}
			if(this.gui2 != null)
			{
				result = result.WhereLike("cq_crystal_gui_setup.gui2","%" + this.gui2.ToString() + "%");
			}
			if(this.gui3 != null)
			{
				result = result.WhereLike("cq_crystal_gui_setup.gui3","%" + this.gui3.ToString() + "%");
			}
			if(this.gui4 != null)
			{
				result = result.WhereLike("cq_crystal_gui_setup.gui4","%" + this.gui4.ToString() + "%");
			}
			if(this.gui5 != null)
			{
				result = result.WhereLike("cq_crystal_gui_setup.gui5","%" + this.gui5.ToString() + "%");
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