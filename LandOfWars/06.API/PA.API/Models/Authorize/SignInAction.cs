using Entities;
using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace UI.PA.Areas.Api.Models.Authorize
{
    public class SignInAction : CommandBase<dynamic>
    {
        public string username { get; set; }
        public string password { get; set; }
        private account GetAccount(ObjectContext context)
        {
            return context.db
                .From("jz_acc.account")
                .Where("jz_acc.account.name", this.username)
                .Where("jz_acc.account.password", this.password)
                .Result<account>()
                .FirstOrDefault()
                ;
        }
        private cq_user GetUser(ObjectContext context,long id)
        {
            return context.db
                .From("jz.cq_user")
                .Where("jz.cq_user.account_id", id)
                .Result<cq_user>()
                .FirstOrDefault()
                ;
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            var acc = this.GetAccount(context);
            if(acc == null)
            {
                throw new BusinessException("Tài khoản hoặc mật khẩu không đúng!", HttpStatusCode.NotFound);
            }
            if(acc.online == 1)
            {
                throw new BusinessException("Tài khoản này đang bị khóa!", HttpStatusCode.Forbidden);
            }
            var user = this.GetUser(context, acc.id.Value);
            if(user == null)
            {
                throw new BusinessException("Không tìm thấy nhân vật, vui lòng tạo nhân vật trước!", HttpStatusCode.NotFound);
            }
            return Success(new
            {
                jtoken = context.GenerateJWT(acc.id.ToString())
            });
        }
    }
}