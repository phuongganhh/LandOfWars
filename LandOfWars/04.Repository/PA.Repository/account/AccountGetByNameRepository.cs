using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class AccountGetByNameRepository<T> : CommandBase<T> where T : class,new()
    {
        public string name { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
           if(this.name == null)
            {
                throw new BusinessException("id is not nullable", System.Net.HttpStatusCode.BadRequest);
            }
        }
        private T GetData(ObjectContext context)
        {
            return context.db
                .From("jz_acc.account")
                .Where("jz_acc.account.name", this.name)
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