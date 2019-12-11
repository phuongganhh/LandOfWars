using Entities;
using PA.Common;
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

namespace PA.API.Models.Package
{
    public class PackageBuyAction : CommandBase
    {
        public long? id { get; set; }
        private package package { get; set; }
        private package GetPackage(ObjectContext context)
        {
            return context.sql.From("package").Where("package.id", this.id).Fetch<package>().FirstOrDefault();
        }
        private Result UpdateAccount(ObjectContext context,account account)
        {
            context.db.From("jz_acc.account").Where("jz_acc.account.id", account.id).Update(account).Execute();
            return Success();
        }
        private Result Transfer(ObjectContext context)
        {
            using(var cmd = new CqBonusInsertRepository())
            {
                cmd.data = new cq_bonus
                {
                    action = Convert.ToInt32(this.package.package_id),
                    id_account = context.GetUser.account_id
                };
                return cmd.Execute(context);
            }
        }
        private Result Normal(ObjectContext context)
        {
            var acc = context.GetAccount;
            if(acc.money < this.package.price)
            {
                throw new BusinessException("Bạn không đủ tiền, hãy nạp thêm!", HttpStatusCode.NotAcceptable);
            }
            acc.money -= this.package.price.Value;
            if(acc.money < 0)
            {
                throw new BusinessException("Tài khoản của bạn không đủ tiền!", HttpStatusCode.NotAcceptable);
            }
            this.UpdateAccount(context, acc).ThrowIfFail();
            return this.Transfer(context);
        }
        protected override void ValidateCore(ObjectContext context)
        {
            this.package = this.GetPackage(context);
            if(this.package == null)
            {
                throw new BusinessException("Không tìm thấy gói này!", HttpStatusCode.NotFound);
            }
            else if(this.package.price == null)
            {
                throw new BusinessException("Gói này hiện không khả dụng!", HttpStatusCode.NotImplemented);
            }
        }
        private Result UpdateUser(ObjectContext context,cq_user user)
        {
            using(var cmd = new CqUserUpdateByIdRepository())
            {
                cmd.data = user;
                return cmd.Execute(context);
            }
        }
        private Result Zp_free(ObjectContext context)
        {
            var user = context.GetUser;
            if(user == null)
            {
                throw new BusinessException("Không tìm thấy tài khoản!", HttpStatusCode.NotFound);
            }
            if(user.Emoney3 < this.package.price)
            {
                throw new BusinessException("Tài khoản không đủ tiền!", HttpStatusCode.NotAcceptable);
            }
            user.Emoney3 -= Convert.ToInt32(this.package.price.Value);
            if(user.Emoney3 < 0)
            {
                throw new BusinessException("Tài khoản của bạn không đủ tiền!", HttpStatusCode.NotAcceptable);
            }
            this.UpdateUser(context, user).ThrowIfFail();
            return this.Transfer(context);
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            //this.package = this.GetPackage(context);
            if(this.package.type == PackageType.Normal)
            {
                return this.Normal(context);
            }
            else if(this.package.type == PackageType.Zp_free)
            {
                return this.Zp_free(context);
            }
            throw new BusinessException("Gói này hiện không khả dụng!", HttpStatusCode.NotImplemented);
        }
    }
}