using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqSynwarCfgGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_synwar_cfg")
                .Where("cq_synwar_cfg.id",this.id)
				.Select(
					"cq_synwar_cfg.id",
					"cq_synwar_cfg.mapid",
					"cq_synwar_cfg.type",
					"cq_synwar_cfg.number",
					"cq_synwar_cfg.coordx",
					"cq_synwar_cfg.coordy",
					"cq_synwar_cfg.cx",
					"cq_synwar_cfg.cy"
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