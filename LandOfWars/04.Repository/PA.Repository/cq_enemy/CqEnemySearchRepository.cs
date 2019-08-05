using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqEnemySearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? userid { get; set; }
		public int? enemy { get; set; }
		public string enemyname { get; set; }
		public int? time { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_enemy")
				.Select(
					"cq_enemy.id",
					"cq_enemy.userid",
					"cq_enemy.enemy",
					"cq_enemy.enemyname",
					"cq_enemy.time"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_enemy")
                        .Select("cq_enemy.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_enemy.id","%" + this.id.ToString() + "%");
			}
			if(this.userid != null)
			{
				result = result.WhereLike("cq_enemy.userid","%" + this.userid.ToString() + "%");
			}
			if(this.enemy != null)
			{
				result = result.WhereLike("cq_enemy.enemy","%" + this.enemy.ToString() + "%");
			}
			if(this.enemyname != null)
			{
				result = result.WhereLike("cq_enemy.enemyname","%" + this.enemyname.ToString() + "%");
			}
			if(this.time != null)
			{
				result = result.WhereLike("cq_enemy.time","%" + this.time.ToString() + "%");
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