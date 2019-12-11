using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqDynamapGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_dynamap")
                .Where("cq_dynamap.id",this.id)
				.Select(
					"cq_dynamap.id",
					"cq_dynamap.name",
					"cq_dynamap.describe_text",
					"cq_dynamap.mapdoc",
					"cq_dynamap.type",
					"cq_dynamap.owner_id",
					"cq_dynamap.mapgroup",
					"cq_dynamap.idxserver",
					"cq_dynamap.weather",
					"cq_dynamap.bgmusic",
					"cq_dynamap.bgmusic_show",
					"cq_dynamap.portal0_x",
					"cq_dynamap.portal0_y",
					"cq_dynamap.reborn_mapid",
					"cq_dynamap.reborn_portal",
					"cq_dynamap.res_lev",
					"cq_dynamap.owner_type",
					"cq_dynamap.link_map",
					"cq_dynamap.link_x",
					"cq_dynamap.link_y",
					"cq_dynamap.del_flag",
					"cq_dynamap.req_maxlv",
					"cq_dynamap.req_minlv",
					"cq_dynamap.room1",
					"cq_dynamap.room2",
					"cq_dynamap.room3",
					"cq_dynamap.room4",
					"cq_dynamap.room5",
					"cq_dynamap.room6"
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