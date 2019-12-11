using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDisdainSearchRepository<T> : CommandBase<Paging<T>> where T: class,new()
    {
		public int? id { get; set; }
		public int? type { get; set; }
		public int? Level_difference1 { get; set; }
		public int? userAtk_monter { get; set; }
		public int? userAtk_user { get; set; }
		public int? userAtk_usergod { get; set; }
		public int? usergodAtk_user { get; set; }
		public int? usergodAtk_usergod { get; set; }
		public int? monsterAtk_add { get; set; }
		public int? Atk_max_percent { get; set; }
		public int? xpatk_max_percent { get; set; }
		public int? Dexterity_factor { get; set; }
		public int? PKDexterity_factor { get; set; }
		public int? Exp_factor { get; set; }
		public int? xpExp_factor { get; set; }
		public int? usr_atk_usr_min { get; set; }
		public int? usr_atk_usr_max { get; set; }
		public int? usr_atk_usr_overadj { get; set; }
		public int? usr_atk_usrx_min { get; set; }
		public int? usr_atk_usrx_max { get; set; }
		public int? usr_atk_usrx_overadj { get; set; }
		public int? usrx_atk_usr_min { get; set; }
		public int? usrx_atk_usr_max { get; set; }
		public int? usrx_atk_usr_overadj { get; set; }
		public int? usrx_atk_usrx_min { get; set; }
		public int? usrx_atk_usrx_max { get; set; }
		public int? usrx_atk_usrx_overadj { get; set; }
		public int? Df_pk_expend_adj { get; set; }
		public int? df_pk_dmg_min_adj { get; set; }
		public int? df_pk_dmg_max_adj { get; set; }


		public int? page_size { get; set; }
		public int? current_page { get; set; }
        public Paging<T> paging { get; set; }
        private Paging<T> GetData(ObjectContext context)
        {
            var result =  context.db
                .From("cq_disdain")
				.Select(
					"cq_disdain.id",
					"cq_disdain.type",
					"cq_disdain.Level_difference1",
					"cq_disdain.userAtk_monter",
					"cq_disdain.userAtk_user",
					"cq_disdain.userAtk_usergod",
					"cq_disdain.usergodAtk_user",
					"cq_disdain.usergodAtk_usergod",
					"cq_disdain.monsterAtk_add",
					"cq_disdain.Atk_max_percent",
					"cq_disdain.xpatk_max_percent",
					"cq_disdain.Dexterity_factor",
					"cq_disdain.PKDexterity_factor",
					"cq_disdain.Exp_factor",
					"cq_disdain.xpExp_factor",
					"cq_disdain.usr_atk_usr_min",
					"cq_disdain.usr_atk_usr_max",
					"cq_disdain.usr_atk_usr_overadj",
					"cq_disdain.usr_atk_usrx_min",
					"cq_disdain.usr_atk_usrx_max",
					"cq_disdain.usr_atk_usrx_overadj",
					"cq_disdain.usrx_atk_usr_min",
					"cq_disdain.usrx_atk_usr_max",
					"cq_disdain.usrx_atk_usr_overadj",
					"cq_disdain.usrx_atk_usrx_min",
					"cq_disdain.usrx_atk_usrx_max",
					"cq_disdain.usrx_atk_usrx_overadj",
					"cq_disdain.Df_pk_expend_adj",
					"cq_disdain.df_pk_dmg_min_adj",
					"cq_disdain.df_pk_dmg_max_adj"
				)
				.ForPage(this.current_page.Value,this.page_size.Value)
                ;
				this.paging.total = context.db
                        .From("cq_disdain")
                        .Select("cq_disdain.id")
                        .Result<dynamic>()
                        .Count
                        ;
			if(this.id != null)
			{
				result = result.WhereLike("cq_disdain.id","%" + this.id.ToString() + "%");
			}
			if(this.type != null)
			{
				result = result.WhereLike("cq_disdain.type","%" + this.type.ToString() + "%");
			}
			if(this.Level_difference1 != null)
			{
				result = result.WhereLike("cq_disdain.Level_difference1","%" + this.Level_difference1.ToString() + "%");
			}
			if(this.userAtk_monter != null)
			{
				result = result.WhereLike("cq_disdain.userAtk_monter","%" + this.userAtk_monter.ToString() + "%");
			}
			if(this.userAtk_user != null)
			{
				result = result.WhereLike("cq_disdain.userAtk_user","%" + this.userAtk_user.ToString() + "%");
			}
			if(this.userAtk_usergod != null)
			{
				result = result.WhereLike("cq_disdain.userAtk_usergod","%" + this.userAtk_usergod.ToString() + "%");
			}
			if(this.usergodAtk_user != null)
			{
				result = result.WhereLike("cq_disdain.usergodAtk_user","%" + this.usergodAtk_user.ToString() + "%");
			}
			if(this.usergodAtk_usergod != null)
			{
				result = result.WhereLike("cq_disdain.usergodAtk_usergod","%" + this.usergodAtk_usergod.ToString() + "%");
			}
			if(this.monsterAtk_add != null)
			{
				result = result.WhereLike("cq_disdain.monsterAtk_add","%" + this.monsterAtk_add.ToString() + "%");
			}
			if(this.Atk_max_percent != null)
			{
				result = result.WhereLike("cq_disdain.Atk_max_percent","%" + this.Atk_max_percent.ToString() + "%");
			}
			if(this.xpatk_max_percent != null)
			{
				result = result.WhereLike("cq_disdain.xpatk_max_percent","%" + this.xpatk_max_percent.ToString() + "%");
			}
			if(this.Dexterity_factor != null)
			{
				result = result.WhereLike("cq_disdain.Dexterity_factor","%" + this.Dexterity_factor.ToString() + "%");
			}
			if(this.PKDexterity_factor != null)
			{
				result = result.WhereLike("cq_disdain.PKDexterity_factor","%" + this.PKDexterity_factor.ToString() + "%");
			}
			if(this.Exp_factor != null)
			{
				result = result.WhereLike("cq_disdain.Exp_factor","%" + this.Exp_factor.ToString() + "%");
			}
			if(this.xpExp_factor != null)
			{
				result = result.WhereLike("cq_disdain.xpExp_factor","%" + this.xpExp_factor.ToString() + "%");
			}
			if(this.usr_atk_usr_min != null)
			{
				result = result.WhereLike("cq_disdain.usr_atk_usr_min","%" + this.usr_atk_usr_min.ToString() + "%");
			}
			if(this.usr_atk_usr_max != null)
			{
				result = result.WhereLike("cq_disdain.usr_atk_usr_max","%" + this.usr_atk_usr_max.ToString() + "%");
			}
			if(this.usr_atk_usr_overadj != null)
			{
				result = result.WhereLike("cq_disdain.usr_atk_usr_overadj","%" + this.usr_atk_usr_overadj.ToString() + "%");
			}
			if(this.usr_atk_usrx_min != null)
			{
				result = result.WhereLike("cq_disdain.usr_atk_usrx_min","%" + this.usr_atk_usrx_min.ToString() + "%");
			}
			if(this.usr_atk_usrx_max != null)
			{
				result = result.WhereLike("cq_disdain.usr_atk_usrx_max","%" + this.usr_atk_usrx_max.ToString() + "%");
			}
			if(this.usr_atk_usrx_overadj != null)
			{
				result = result.WhereLike("cq_disdain.usr_atk_usrx_overadj","%" + this.usr_atk_usrx_overadj.ToString() + "%");
			}
			if(this.usrx_atk_usr_min != null)
			{
				result = result.WhereLike("cq_disdain.usrx_atk_usr_min","%" + this.usrx_atk_usr_min.ToString() + "%");
			}
			if(this.usrx_atk_usr_max != null)
			{
				result = result.WhereLike("cq_disdain.usrx_atk_usr_max","%" + this.usrx_atk_usr_max.ToString() + "%");
			}
			if(this.usrx_atk_usr_overadj != null)
			{
				result = result.WhereLike("cq_disdain.usrx_atk_usr_overadj","%" + this.usrx_atk_usr_overadj.ToString() + "%");
			}
			if(this.usrx_atk_usrx_min != null)
			{
				result = result.WhereLike("cq_disdain.usrx_atk_usrx_min","%" + this.usrx_atk_usrx_min.ToString() + "%");
			}
			if(this.usrx_atk_usrx_max != null)
			{
				result = result.WhereLike("cq_disdain.usrx_atk_usrx_max","%" + this.usrx_atk_usrx_max.ToString() + "%");
			}
			if(this.usrx_atk_usrx_overadj != null)
			{
				result = result.WhereLike("cq_disdain.usrx_atk_usrx_overadj","%" + this.usrx_atk_usrx_overadj.ToString() + "%");
			}
			if(this.Df_pk_expend_adj != null)
			{
				result = result.WhereLike("cq_disdain.Df_pk_expend_adj","%" + this.Df_pk_expend_adj.ToString() + "%");
			}
			if(this.df_pk_dmg_min_adj != null)
			{
				result = result.WhereLike("cq_disdain.df_pk_dmg_min_adj","%" + this.df_pk_dmg_min_adj.ToString() + "%");
			}
			if(this.df_pk_dmg_max_adj != null)
			{
				result = result.WhereLike("cq_disdain.df_pk_dmg_max_adj","%" + this.df_pk_dmg_max_adj.ToString() + "%");
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