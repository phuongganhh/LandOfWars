using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class AccountSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public string name { get; set; }
		public int? sex { get; set; }
		public int? age { get; set; }
		public string phone { get; set; }
		public string email { get; set; }
		public string address { get; set; }
		public string idnumber { get; set; }
		public string password { get; set; }
		public int? type { get; set; }
		public int? point { get; set; }
		public int? pointtime { get; set; }
		public int? online { get; set; }
		public int? licence { get; set; }
		public string netbar_ip { get; set; }
		public string ip_mask { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("account")
				.Select(
					"account.id",
					"account.name",
					"account.sex",
					"account.age",
					"account.phone",
					"account.email",
					"account.address",
					"account.idnumber",
					"account.password",
					"account.type",
					"account.point",
					"account.pointtime",
					"account.online",
					"account.licence",
					"account.netbar_ip",
					"account.ip_mask"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("account")
                        .Select("account.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("account.id","%" + this.id.ToString() + "%");
			}
			if(this.name != null)
			{
				result = result.WhereLike("account.name","%" + this.name.ToString() + "%");
			}
			if(this.sex != null)
			{
				result = result.WhereLike("account.sex","%" + this.sex.ToString() + "%");
			}
			if(this.age != null)
			{
				result = result.WhereLike("account.age","%" + this.age.ToString() + "%");
			}
			if(this.phone != null)
			{
				result = result.WhereLike("account.phone","%" + this.phone.ToString() + "%");
			}
			if(this.email != null)
			{
				result = result.WhereLike("account.email","%" + this.email.ToString() + "%");
			}
			if(this.address != null)
			{
				result = result.WhereLike("account.address","%" + this.address.ToString() + "%");
			}
			if(this.idnumber != null)
			{
				result = result.WhereLike("account.idnumber","%" + this.idnumber.ToString() + "%");
			}
			if(this.password != null)
			{
				result = result.WhereLike("account.password","%" + this.password.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("account.type","%" + this.type.ToString() + "%");
			}
			if(this.point != null)
			{
				result = result.WhereLike("account.point","%" + this.point.ToString() + "%");
			}
			if(this.pointtime != null)
			{
				result = result.WhereLike("account.pointtime","%" + this.pointtime.ToString() + "%");
			}
			if(this.online != null)
			{
				result = result.WhereLike("account.online","%" + this.online.ToString() + "%");
			}
			if(this.licence != null)
			{
				result = result.WhereLike("account.licence","%" + this.licence.ToString() + "%");
			}
			if(this.netbar_ip != null)
			{
				result = result.WhereLike("account.netbar_ip","%" + this.netbar_ip.ToString() + "%");
			}
			if(this.ip_mask != null)
			{
				result = result.WhereLike("account.ip_mask","%" + this.ip_mask.ToString() + "%");
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