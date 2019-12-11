using Entities;
using PA.Entities;
using PA.Extensions;
using PA.Framework;
using PA.Repository; using System.Net;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PA.API.Models.Authorize
{
    public class ValidateAction : CommandBase
    {
        public string token { get; set; }
        private mail_queue GetData(ObjectContext context)
        {
            return context.sql.From("mail_queue").Where("mail_queue.token", this.token).Fetch<mail_queue>().FirstOrDefault();
        }
        private Result UpdateMail(ObjectContext context,mail_queue mail)
        {
            var result = context.sql.From("mail_queue").Where("mail_queue.id",mail.id).Update(mail).Execute();
            if(result == 0)
            {
                throw new BusinessException("Có lỗi xảy ra!");
            }
            return Success();
        }
        private Result<account> GetAccount(ObjectContext context,int? acc_id)
        {
            using(var cmd = new AccountGetByIdRepository<account>())
            {
                cmd.id = acc_id;
                return cmd.Execute(context);
            }
        }
        private Result UpdateAccount(ObjectContext context,int? acc_id)
        {
            var acc = this.GetAccount(context, acc_id).ThrowIfFail().data;
            if(acc != null)
            {
                acc.online = 0;
                context.db.From("jz_acc.account").Where("jz_acc.account.id",acc_id).Update(acc).ExecuteNotResult();
                return Success();
            }
            throw new BusinessException("Không tìm thấy tài khoản!",HttpStatusCode.NotFound);
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            var mail = this.GetData(context);
            if(mail == null)
            {
                throw new BusinessException("Không tìm thấy token!",HttpStatusCode.NotFound);
            }
            if(mail.sent == true && mail.active == false && mail.token == this.token)
            {
                mail.active = true;
                this.UpdateMail(context, mail).ThrowIfFail();
                this.UpdateAccount(context, Convert.ToInt32(mail.id));
                return Success("Kích hoạt tài khoản thành công!");
            }
            throw new BusinessException("Token này không tồn tại!", HttpStatusCode.NotFound);

        }
    }
}