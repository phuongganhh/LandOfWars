using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDisdainGetByIdRepository<T> : CommandBase<T> where T : class,new()
    {
        public int? id { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.id == null)
            {
                throw new BusinessException("id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("cq_disdain")
                .Where("cq_disdain.id",this.id)
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
                .Result<T>()
                .FirstOrDefault()
                ;
        }
        protected override Result<T> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetData(context));
        }
    }
}