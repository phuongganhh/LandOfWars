using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqWeaponUplvSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? exp1 { get; set; }
		public int? point1 { get; set; }
		public int? atk1 { get; set; }
		public int? hot1 { get; set; }
		public int? shake1 { get; set; }
		public int? sting1 { get; set; }
		public int? decay1 { get; set; }
		public int? fighter1 { get; set; }
		public int? gunner1 { get; set; }
		public int? energy1 { get; set; }
		public int? exp2 { get; set; }
		public int? point2 { get; set; }
		public int? atk2 { get; set; }
		public int? hot2 { get; set; }
		public int? shake2 { get; set; }
		public int? sting2 { get; set; }
		public int? decay2 { get; set; }
		public int? fighter2 { get; set; }
		public int? gunner2 { get; set; }
		public int? energy2 { get; set; }
		public int? exp3 { get; set; }
		public int? point3 { get; set; }
		public int? atk3 { get; set; }
		public int? hot3 { get; set; }
		public int? shake3 { get; set; }
		public int? sting3 { get; set; }
		public int? decay3 { get; set; }
		public int? fighter3 { get; set; }
		public int? gunner3 { get; set; }
		public int? energy3 { get; set; }
		public int? exp4 { get; set; }
		public int? point4 { get; set; }
		public int? atk4 { get; set; }
		public int? hot4 { get; set; }
		public int? shake4 { get; set; }
		public int? sting4 { get; set; }
		public int? decay4 { get; set; }
		public int? fighter4 { get; set; }
		public int? gunner4 { get; set; }
		public int? energy4 { get; set; }
		public int? exp5 { get; set; }
		public int? point5 { get; set; }
		public int? atk5 { get; set; }
		public int? hot5 { get; set; }
		public int? shake5 { get; set; }
		public int? sting5 { get; set; }
		public int? decay5 { get; set; }
		public int? fighter5 { get; set; }
		public int? gunner5 { get; set; }
		public int? energy5 { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_weapon_uplv")
				.Select(
					"cq_weapon_uplv.id",
					"cq_weapon_uplv.exp1",
					"cq_weapon_uplv.point1",
					"cq_weapon_uplv.atk1",
					"cq_weapon_uplv.hot1",
					"cq_weapon_uplv.shake1",
					"cq_weapon_uplv.sting1",
					"cq_weapon_uplv.decay1",
					"cq_weapon_uplv.fighter1",
					"cq_weapon_uplv.gunner1",
					"cq_weapon_uplv.energy1",
					"cq_weapon_uplv.exp2",
					"cq_weapon_uplv.point2",
					"cq_weapon_uplv.atk2",
					"cq_weapon_uplv.hot2",
					"cq_weapon_uplv.shake2",
					"cq_weapon_uplv.sting2",
					"cq_weapon_uplv.decay2",
					"cq_weapon_uplv.fighter2",
					"cq_weapon_uplv.gunner2",
					"cq_weapon_uplv.energy2",
					"cq_weapon_uplv.exp3",
					"cq_weapon_uplv.point3",
					"cq_weapon_uplv.atk3",
					"cq_weapon_uplv.hot3",
					"cq_weapon_uplv.shake3",
					"cq_weapon_uplv.sting3",
					"cq_weapon_uplv.decay3",
					"cq_weapon_uplv.fighter3",
					"cq_weapon_uplv.gunner3",
					"cq_weapon_uplv.energy3",
					"cq_weapon_uplv.exp4",
					"cq_weapon_uplv.point4",
					"cq_weapon_uplv.atk4",
					"cq_weapon_uplv.hot4",
					"cq_weapon_uplv.shake4",
					"cq_weapon_uplv.sting4",
					"cq_weapon_uplv.decay4",
					"cq_weapon_uplv.fighter4",
					"cq_weapon_uplv.gunner4",
					"cq_weapon_uplv.energy4",
					"cq_weapon_uplv.exp5",
					"cq_weapon_uplv.point5",
					"cq_weapon_uplv.atk5",
					"cq_weapon_uplv.hot5",
					"cq_weapon_uplv.shake5",
					"cq_weapon_uplv.sting5",
					"cq_weapon_uplv.decay5",
					"cq_weapon_uplv.fighter5",
					"cq_weapon_uplv.gunner5",
					"cq_weapon_uplv.energy5"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_weapon_uplv")
                        .Select("cq_weapon_uplv.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_weapon_uplv.id","%" + this.id.ToString() + "%");
			}
			if(this.exp1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.exp1","%" + this.exp1.ToString() + "%");
			}
			if(this.point1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.point1","%" + this.point1.ToString() + "%");
			}
			if(this.atk1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.atk1","%" + this.atk1.ToString() + "%");
			}
			if(this.hot1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.hot1","%" + this.hot1.ToString() + "%");
			}
			if(this.shake1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.shake1","%" + this.shake1.ToString() + "%");
			}
			if(this.sting1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.sting1","%" + this.sting1.ToString() + "%");
			}
			if(this.decay1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.decay1","%" + this.decay1.ToString() + "%");
			}
			if(this.fighter1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.fighter1","%" + this.fighter1.ToString() + "%");
			}
			if(this.gunner1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.gunner1","%" + this.gunner1.ToString() + "%");
			}
			if(this.energy1 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.energy1","%" + this.energy1.ToString() + "%");
			}
			if(this.exp2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.exp2","%" + this.exp2.ToString() + "%");
			}
			if(this.point2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.point2","%" + this.point2.ToString() + "%");
			}
			if(this.atk2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.atk2","%" + this.atk2.ToString() + "%");
			}
			if(this.hot2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.hot2","%" + this.hot2.ToString() + "%");
			}
			if(this.shake2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.shake2","%" + this.shake2.ToString() + "%");
			}
			if(this.sting2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.sting2","%" + this.sting2.ToString() + "%");
			}
			if(this.decay2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.decay2","%" + this.decay2.ToString() + "%");
			}
			if(this.fighter2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.fighter2","%" + this.fighter2.ToString() + "%");
			}
			if(this.gunner2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.gunner2","%" + this.gunner2.ToString() + "%");
			}
			if(this.energy2 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.energy2","%" + this.energy2.ToString() + "%");
			}
			if(this.exp3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.exp3","%" + this.exp3.ToString() + "%");
			}
			if(this.point3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.point3","%" + this.point3.ToString() + "%");
			}
			if(this.atk3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.atk3","%" + this.atk3.ToString() + "%");
			}
			if(this.hot3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.hot3","%" + this.hot3.ToString() + "%");
			}
			if(this.shake3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.shake3","%" + this.shake3.ToString() + "%");
			}
			if(this.sting3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.sting3","%" + this.sting3.ToString() + "%");
			}
			if(this.decay3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.decay3","%" + this.decay3.ToString() + "%");
			}
			if(this.fighter3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.fighter3","%" + this.fighter3.ToString() + "%");
			}
			if(this.gunner3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.gunner3","%" + this.gunner3.ToString() + "%");
			}
			if(this.energy3 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.energy3","%" + this.energy3.ToString() + "%");
			}
			if(this.exp4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.exp4","%" + this.exp4.ToString() + "%");
			}
			if(this.point4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.point4","%" + this.point4.ToString() + "%");
			}
			if(this.atk4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.atk4","%" + this.atk4.ToString() + "%");
			}
			if(this.hot4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.hot4","%" + this.hot4.ToString() + "%");
			}
			if(this.shake4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.shake4","%" + this.shake4.ToString() + "%");
			}
			if(this.sting4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.sting4","%" + this.sting4.ToString() + "%");
			}
			if(this.decay4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.decay4","%" + this.decay4.ToString() + "%");
			}
			if(this.fighter4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.fighter4","%" + this.fighter4.ToString() + "%");
			}
			if(this.gunner4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.gunner4","%" + this.gunner4.ToString() + "%");
			}
			if(this.energy4 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.energy4","%" + this.energy4.ToString() + "%");
			}
			if(this.exp5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.exp5","%" + this.exp5.ToString() + "%");
			}
			if(this.point5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.point5","%" + this.point5.ToString() + "%");
			}
			if(this.atk5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.atk5","%" + this.atk5.ToString() + "%");
			}
			if(this.hot5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.hot5","%" + this.hot5.ToString() + "%");
			}
			if(this.shake5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.shake5","%" + this.shake5.ToString() + "%");
			}
			if(this.sting5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.sting5","%" + this.sting5.ToString() + "%");
			}
			if(this.decay5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.decay5","%" + this.decay5.ToString() + "%");
			}
			if(this.fighter5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.fighter5","%" + this.fighter5.ToString() + "%");
			}
			if(this.gunner5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.gunner5","%" + this.gunner5.ToString() + "%");
			}
			if(this.energy5 != null)
			{
				result = result.WhereLike("cq_weapon_uplv.energy5","%" + this.energy5.ToString() + "%");
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