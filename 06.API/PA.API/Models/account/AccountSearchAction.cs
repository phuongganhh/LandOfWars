using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PA.Repository; using System.Net;
using Entities;

namespace PA.API.Models.Account
{
    public class AccountSearchAction : CommandBase<List<dynamic>>
    {
        private List<dynamic> GetAccounts(ObjectContext context)
        {
            return context.db.From("jz_acc.account").Result<dynamic>();
        }
        protected override Result<List<dynamic>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetAccounts(context));
        }
    }
}