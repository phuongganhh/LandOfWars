using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPetSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? ownerid { get; set; }
		public int? ownertype { get; set; }
		public int? generatorid { get; set; }
		public int? typeid { get; set; }
		public string name { get; set; }
		public int? life { get; set; }
		public int? mana { get; set; }
		public int? recordmap_id { get; set; }
		public int? recordx { get; set; }
		public int? recordy { get; set; }
		public int? data { get; set; }
		public int? data1 { get; set; }
		public int? data2 { get; set; }
		public int? number { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_pet")
				.Select(
					"cq_pet.id",
					"cq_pet.ownerid",
					"cq_pet.ownertype",
					"cq_pet.generatorid",
					"cq_pet.typeid",
					"cq_pet.name",
					"cq_pet.life",
					"cq_pet.mana",
					"cq_pet.recordmap_id",
					"cq_pet.recordx",
					"cq_pet.recordy",
					"cq_pet.data",
					"cq_pet.data1",
					"cq_pet.data2",
					"cq_pet.number"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_pet")
                        .Select("cq_pet.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_pet.id","%" + this.id.ToString() + "%");
			}
			if(this.ownerid != null)
			{
				result = result.WhereLike("cq_pet.ownerid","%" + this.ownerid.ToString() + "%");
			}
			if(this.ownertype != null)
			{
				result = result.WhereLike("cq_pet.ownertype","%" + this.ownertype.ToString() + "%");
			}
			if(this.generatorid != null)
			{
				result = result.WhereLike("cq_pet.generatorid","%" + this.generatorid.ToString() + "%");
			}
			if(this.typeid != null)
			{
				result = result.WhereLike("cq_pet.typeid","%" + this.typeid.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("cq_pet.name","%" + this.name.ToString() + "%");
			}
			if(this.life != null)
			{
				result = result.WhereLike("cq_pet.life","%" + this.life.ToString() + "%");
			}
			if(this.mana != null)
			{
				result = result.WhereLike("cq_pet.mana","%" + this.mana.ToString() + "%");
			}
			if(this.recordmap_id != null)
			{
				result = result.WhereLike("cq_pet.recordmap_id","%" + this.recordmap_id.ToString() + "%");
			}
			if(this.recordx != null)
			{
				result = result.WhereLike("cq_pet.recordx","%" + this.recordx.ToString() + "%");
			}
			if(this.recordy != null)
			{
				result = result.WhereLike("cq_pet.recordy","%" + this.recordy.ToString() + "%");
			}
			if(this.data != null)
			{
				result = result.WhereLike("cq_pet.data","%" + this.data.ToString() + "%");
			}
			if(this.data1 != null)
			{
				result = result.WhereLike("cq_pet.data1","%" + this.data1.ToString() + "%");
			}
			if(this.data2 != null)
			{
				result = result.WhereLike("cq_pet.data2","%" + this.data2.ToString() + "%");
			}
			if(this.number != null)
			{
				result = result.WhereLike("cq_pet.number","%" + this.number.ToString() + "%");
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