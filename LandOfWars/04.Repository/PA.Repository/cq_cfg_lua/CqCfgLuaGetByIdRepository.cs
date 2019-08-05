using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqCfgLuaGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_cfg_lua")
                .Where("cq_cfg_lua.id",this.id)
				.Select(
					"cq_cfg_lua.id",
					"cq_cfg_lua.block",
					"cq_cfg_lua.name"
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