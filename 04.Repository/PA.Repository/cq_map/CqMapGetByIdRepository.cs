using PA;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA.Repository
{
    public class CqMapGetByIdRepository<T> : CommandBase<T> where T : class,new()
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
                .From("cq_map")
                .Where("cq_map.id",this.id)
				.Select(
					"cq_map.id",
					"cq_map.name",
					"cq_map.describe_text",
					"cq_map.mapdoc",
					"cq_map.type",
					"cq_map.owner_id",
					"cq_map.mapgroup",
					"cq_map.idxserver",
					"cq_map.weather",
					"cq_map.bgmusic",
					"cq_map.bgmusic_show",
					"cq_map.portal0_x",
					"cq_map.portal0_y",
					"cq_map.reborn_mapid",
					"cq_map.reborn_portal",
					"cq_map.res_lev",
					"cq_map.owner_type",
					"cq_map.link_map",
					"cq_map.link_x",
					"cq_map.link_y",
					"cq_map.del_flag",
					"cq_map.req_maxlv",
					"cq_map.req_minlv",
					"cq_map.room1",
					"cq_map.room2",
					"cq_map.room3",
					"cq_map.room4",
					"cq_map.room5",
					"cq_map.room6",
					"cq_map.Province_id"
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