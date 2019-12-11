using Entities;
using PA;
using PA.Entities;
using PA.Extensions;
using PA.Framework;
using PA.Framework.Extensions;
using PA.Repository;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace UI.PA.Areas.Api.Models.Authorize
{
    public class SignUpAction : CommandBase
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string MailContent { get; set; }
        private dynamic GetAccount(ObjectContext context)
        {
            return context.db.From("jz_acc.account").Where("jz_acc.account.name", this.username).Result<dynamic>().FirstOrDefault();
        }
        private Result MailQueue(ObjectContext context)
        {

            var token = context.Object_ID();
            var isSusccess = context.sql.From("mail_queue").Insert(new mail_queue
            {
                create_time = DateTime.Now,
                email = this.email,
                sent = false,
                token = token,
                id = context.MaxId("jz_acc.account"),
                text = this.GetMail(context, this.username, token),
                active = false
            }).Execute();
            if (isSusccess == 0)
                throw new BusinessException("Xảy ra lỗi bất ngờ, vui lòng thử lại sau!");
            return Success();
        }
        private mail_queue GetMail(ObjectContext context)
        {
            return context.sql.From("mail_queue").Where("mail_queue.email", this.email.ToLower()).Fetch<mail_queue>().FirstOrDefault();
        }
        private Result InsertAccount(ObjectContext context)
        {
            using (var cmd = new AccountInsertRepository())
            {
                cmd.data = new account
                {
                    name = this.username,
                    password = this.password,
                    online = 1,
                    reg_date = DateTime.Now,
                    permission_id = PermissionType.Guest,
                    netbar_ip = context.ClientIp,
                    ip_mask = context.ServerIp,
                    VIP = 1,
                    email = this.email,
                    money = 0
                };
                return cmd.Execute(context);
            }
        }
        protected override void ValidateCore(ObjectContext context)
        {
            if (this.username == null || this.password == null)
            {
                throw new BusinessException("Tài khoản hoặc mật khẩu không được bỏ trống!", HttpStatusCode.NotFound);
            }
            else
            {
                this.username = this.username.ToLower();
                if (this.username.Count() < 4 || this.username.Count() > 16)
                    throw new BusinessException("Tên tài khoản phải có độ dài từ 4 đến 16 kí tự!");
                this.password = this.password.ToLower();
            }
            if (this.email == null || !this.email.ToLower().EndsWith("@gmail.com"))
            {
                throw new BusinessException("Email phải kết thúc bằng @gmail.com");
            }
            var avai = this.GetMail(context);
            if (avai != null)
            {
                throw new BusinessException("Email này đã được sử dụng!", HttpStatusCode.Conflict);
            }
        }
        private string GetMail(ObjectContext context, string name, string token)
        {
            var text = File.ReadAllText(this.MailContent);
            text = text.Replace("{token}", token).Replace("{name}", name);
            return text;
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            var account = this.GetAccount(context);
            if (account != null)
            {
                throw new BusinessException("Tài khoản đã tồn tại!", HttpStatusCode.Conflict);
            }
            this.InsertAccount(context).ThrowIfFail();
            this.MailQueue(context).ThrowIfFail();
            return Success($"Chào {this.username}!\nCảm ơn bạn đã đăng kí, vui lòng kiểm tra Email để xác thực tài khoản!\nNếu không thấy Email nào vui lòng kiểm tra hòm thư Spam hoặc liên hệ với quản trị!");
        }
    }
}