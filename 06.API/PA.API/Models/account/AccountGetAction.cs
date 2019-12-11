using Entities;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.API.Models
{
    public class AccountGetAction : CommandBase<dynamic>
    {
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            return Success(context.GetAccount);
        }
    }
}