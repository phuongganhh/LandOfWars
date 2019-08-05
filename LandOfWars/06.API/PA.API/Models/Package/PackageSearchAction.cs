using PA.Common;
using PA.Entities;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.API.Models
{
    public class PackageSearchAction : CommandBase<List<package>>
    {
        private List<package> GetPackages(ObjectContext context)
        {
            return context.sql.From("package").Fetch<package>();
        }
        protected override Result<List<package>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetPackages(context).Select(x=> {
                x.currency = x.Currency();
                return x;
            }).ToList());
        }
    }
}