using Entities;
using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PA.API.Models
{
    public class AccountGetChartAction : CommandBase<IEnumerable<dynamic>>
    {
        public class cquser_dto : cq_user
        {
            public DateTime? CreateTime { get; set; }
        }
        protected override Result<IEnumerable<dynamic>> ExecuteCore(ObjectContext context)
        {
            return Success(this.GetUsers(context).Select(x=> {
                return new
                {
                    zps = x.Emoney,
                    zp_free = x.Emoney3,
                    gold = x.money,
                    friend_share = x.friend_share,
                    create_time = x.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                };
            }));
        }

        private List<cquser_dto> GetUsers(ObjectContext context)
        {
            return context.sql.From("cq_user").Where("cq_user.id", context.GetUser.id).Fetch<cquser_dto>();
        }
    }
}