using Entities;
using PA.Extensions;
using PA.Repository; using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.API.Models.Authorize
{
    public class LoginAction : CommandBase<dynamic>
    {
        public string username { get; set; }
        public string password { get; set; }
        private account GetUser(ObjectContext context)
        {
            return context.db.From("jz_acc.account")
                    .Select("jz_acc.account.name","jz_acc.account.password","jz_acc.account.id")
                    .Where("jz_acc.account.name", this.username)
                    .Where("jz_acc.account.password", this.password)
                    .Result<account>()
                    .FirstOrDefault()
                    ;
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            var user = this.GetUser(context);
            if(user == null)
            {
                throw new BusinessException("Tài khoản hoặc mật khẩu không đúng!",HttpStatusCode.NotFound);
            }
            if(user.online == 1)
            {
                throw new BusinessException("Tài khoản của bạn đang bị khóa!", HttpStatusCode.NotFound);
            }
            return Success(new
            {
                jtoken = context.GenerateJWT(user.id.ToString())
            });
        }
    }
}