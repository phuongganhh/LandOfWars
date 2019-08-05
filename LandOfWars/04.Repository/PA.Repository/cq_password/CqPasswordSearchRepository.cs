using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqPasswordSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? ID { get; set; }
		public int? A { get; set; }
		public int? B { get; set; }
		public int? C { get; set; }
		public int? D { get; set; }
		public int? E { get; set; }
		public int? F { get; set; }
		public int? G { get; set; }
		public int? H { get; set; }
		public int? I { get; set; }
		public int? J { get; set; }
		public int? K { get; set; }
		public int? L { get; set; }
		public int? M { get; set; }
		public int? N { get; set; }
		public int? O { get; set; }
		public int? P { get; set; }
		public int? Q { get; set; }
		public int? R { get; set; }
		public int? S { get; set; }
		public int? U { get; set; }
		public int? V { get; set; }
		public int? W { get; set; }
		public int? X { get; set; }
		public int? Y { get; set; }
		public int? Z { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_password")
				.Select(
					"cq_password.ID",
					"cq_password.A",
					"cq_password.B",
					"cq_password.C",
					"cq_password.D",
					"cq_password.E",
					"cq_password.F",
					"cq_password.G",
					"cq_password.H",
					"cq_password.I",
					"cq_password.J",
					"cq_password.K",
					"cq_password.L",
					"cq_password.M",
					"cq_password.N",
					"cq_password.O",
					"cq_password.P",
					"cq_password.Q",
					"cq_password.R",
					"cq_password.S",
					"cq_password.U",
					"cq_password.V",
					"cq_password.W",
					"cq_password.X",
					"cq_password.Y",
					"cq_password.Z"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_password")
                        .Select("cq_password.ID")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.ID != null)
			{
				result = result.WhereLike("cq_password.ID","%" + this.ID.ToString() + "%");
			}
			if(this.A != null)
			{
				result = result.WhereLike("cq_password.A","%" + this.A.ToString() + "%");
			}
			if(this.B != null)
			{
				result = result.WhereLike("cq_password.B","%" + this.B.ToString() + "%");
			}
			if(this.C != null)
			{
				result = result.WhereLike("cq_password.C","%" + this.C.ToString() + "%");
			}
			if(this.D != null)
			{
				result = result.WhereLike("cq_password.D","%" + this.D.ToString() + "%");
			}
			if(this.E != null)
			{
				result = result.WhereLike("cq_password.E","%" + this.E.ToString() + "%");
			}
			if(this.F != null)
			{
				result = result.WhereLike("cq_password.F","%" + this.F.ToString() + "%");
			}
			if(this.G != null)
			{
				result = result.WhereLike("cq_password.G","%" + this.G.ToString() + "%");
			}
			if(this.H != null)
			{
				result = result.WhereLike("cq_password.H","%" + this.H.ToString() + "%");
			}
			if(this.I != null)
			{
				result = result.WhereLike("cq_password.I","%" + this.I.ToString() + "%");
			}
			if(this.J != null)
			{
				result = result.WhereLike("cq_password.J","%" + this.J.ToString() + "%");
			}
			if(this.K != null)
			{
				result = result.WhereLike("cq_password.K","%" + this.K.ToString() + "%");
			}
			if(this.L != null)
			{
				result = result.WhereLike("cq_password.L","%" + this.L.ToString() + "%");
			}
			if(this.M != null)
			{
				result = result.WhereLike("cq_password.M","%" + this.M.ToString() + "%");
			}
			if(this.N != null)
			{
				result = result.WhereLike("cq_password.N","%" + this.N.ToString() + "%");
			}
			if(this.O != null)
			{
				result = result.WhereLike("cq_password.O","%" + this.O.ToString() + "%");
			}
			if(this.P != null)
			{
				result = result.WhereLike("cq_password.P","%" + this.P.ToString() + "%");
			}
			if(this.Q != null)
			{
				result = result.WhereLike("cq_password.Q","%" + this.Q.ToString() + "%");
			}
			if(this.R != null)
			{
				result = result.WhereLike("cq_password.R","%" + this.R.ToString() + "%");
			}
			if(this.S != null)
			{
				result = result.WhereLike("cq_password.S","%" + this.S.ToString() + "%");
			}
			if(this.U != null)
			{
				result = result.WhereLike("cq_password.U","%" + this.U.ToString() + "%");
			}
			if(this.V != null)
			{
				result = result.WhereLike("cq_password.V","%" + this.V.ToString() + "%");
			}
			if(this.W != null)
			{
				result = result.WhereLike("cq_password.W","%" + this.W.ToString() + "%");
			}
			if(this.X != null)
			{
				result = result.WhereLike("cq_password.X","%" + this.X.ToString() + "%");
			}
			if(this.Y != null)
			{
				result = result.WhereLike("cq_password.Y","%" + this.Y.ToString() + "%");
			}
			if(this.Z != null)
			{
				result = result.WhereLike("cq_password.Z","%" + this.Z.ToString() + "%");
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